using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPWebForm_equipo_5
{
    public partial class MiMaster : System.Web.UI.MasterPage
    {
        public int cantidad;
        string busqueda;
        List<Articulo> listaDeCompras;
        public string cantidadItems
        {
            get { return cantidadItems; }
            set { Contador.Text = value; }
        }

        protected bool ValidarTextBox(string busqueda)
        {
            if (string.IsNullOrEmpty(busqueda)) { return false; }
            else { return true; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
            
            if (Session["listaArticulosEnCarrito"] == null)
            {
                Contador.Text = "0";
            }
            else
            {
                listaDeCompras = (List<Articulo>)Session["listaArticulosEnCarrito"];
                cantidad = listaDeCompras.Count();
                Contador.Text = cantidad.ToString();

            }
        }

        protected void btnBusqueda_Click(object sender, EventArgs e)
        {
            busqueda = txtBusqueda.Text;
            if (ValidarTextBox(busqueda))
            {
                //caso en el que tiene que iniciar la busqueda
                Response.Redirect("default.aspx?busqueda=" + busqueda, false);
            }
            else
            {
                //caso en el que tiene que mostrar todo
                Response.Redirect("default.aspx", false);
            }
        }
    }
}