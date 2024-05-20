using Dominio;
using LecturaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPWebForm_equipo_5
{
    public partial class VentanaProductos : System.Web.UI.Page
    {
        //Variables
        public List<Articulo> listaLecturaArticulos;
        public Articulo artseleccionado;
        public string busqueda = null;
        public bool listaMostrable;

        //Page Load
        protected void Page_Load(object sender, EventArgs e)
        {
                Session["ArticulosEnCarrito"] = null;
                cargardatos();
                busqueda = Request.QueryString["busqueda"];
                if (busqueda != null) filtrarArticulo(busqueda);
                validarListaMostrable();
            if (!IsPostBack)
            {
                cargarddl();
                repRepetidor.DataSource = listaLecturaArticulos;
                repRepetidor.DataBind();
            }
            
        }

        //Metodo para validar lista y mostrar
        public void validarListaMostrable()
        {
            int cantidadRegistros = listaLecturaArticulos.Count();
            listaMostrable = true;
            if (cantidadRegistros < 1)
            {
                listaMostrable=false;
            }
        }

        //Metodo que filtra y ordena las cards
        protected void DdlOrden_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Articulo> listaFiltrada;
            
            if (DdlOrden.SelectedValue == "Precio Mayor")
            {
                listaFiltrada = listaLecturaArticulos.OrderByDescending(x => x.Precio).ToList();
            }
            else if (DdlOrden.SelectedValue == "Precio Menor")
            {
                listaFiltrada = listaLecturaArticulos.OrderBy(x => x.Precio).ToList();
            }
            else { listaFiltrada = listaLecturaArticulos.OrderBy(x => x.Nombre).ToList(); }
            listaLecturaArticulos = listaFiltrada;
            repRepetidor.DataSource = listaLecturaArticulos;
            repRepetidor.DataBind();
        }
        //Filtra los articulos y los ordena
        private void filtrarArticulo(string filtro)
        {
            List<Articulo> listaFiltrada;
            listaFiltrada = listaLecturaArticulos.FindAll(x => x.Nombre.ToUpper().Contains(filtro.ToUpper()));
            listaLecturaArticulos = listaFiltrada;
        }
        public void cargardatos()
        {
            LecturaArticulo lecturaArticulo = new LecturaArticulo();
            listaLecturaArticulos = lecturaArticulo.listar();
        }
        public void ordenarpag(int value)
        {
            if (value == 0) { }
        }

        //Metodo para inyectar valor a la dbl
        public void cargarddl()
        {
            DdlOrden.Items.Add("Orden alfabetico");
            DdlOrden.Items.Add("Precio Mayor");
            DdlOrden.Items.Add("Precio Menor");
        }

        //Evento "Comprar Ahora"
        protected void btnComprarAhora_Click(object sender, EventArgs e)
        {
            int id = int.Parse(((Button)sender).CommandArgument);
            foreach (var item in listaLecturaArticulos)
            {
                if (id == item.Id)
                {
                    artseleccionado = item;
                }
            }

            Session.Add("ArticulosEnCarrito", artseleccionado);

            Response.Redirect("VentanaCarrito.aspx", false);
        }

        //Evento "Detalle"
        protected void Btndetalle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(((Button)sender).CommandArgument);
            foreach (var item in listaLecturaArticulos)
            {
                if (id == item.Id)
                {
                    artseleccionado = item;
                }

            }
            
            Session.Add("ArticulosEnCarrito", artseleccionado);

            Response.Redirect("VentanaDetalle.aspx", false);
        }

    }
}