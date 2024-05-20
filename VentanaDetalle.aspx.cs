using Dominio;
using LecturaDatos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPWebForm_equipo_5
{
    public partial class VentanaDetalle : System.Web.UI.Page
    {
        //Variables
        public List<Articulo> listacarrito;
        public List<Imagen> listaImagenes;
        private Articulo seleccionado = null;
        int indiceMaximo = 0;
        int indiceActual = 0;
        public bool masImagenes = false;
        
        //Pageload
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                masImagenes = false;


                if (Session["ArticulosEnCarrito"] != null) //Revisar como es enviado el id (de VentanaProductos)
                {
                    seleccionado = (Articulo)Session["ArticulosEnCarrito"];
                    lblNombreArticulo.Text = seleccionado.Nombre;
                    lblPrecio.Text = seleccionado.Precio.ToString("F2");
                    lblDescripcion.Text = seleccionado.Descripcion;
                    lblCategoria.Text = seleccionado.Categoria.Descripcion.ToString();
                    lblMarca.Text = seleccionado.Marca.Descripcion.ToString();

                    LecturaImagen lecturaImagen = new LecturaImagen();
                    indiceMaximo = lecturaImagen.maximoImagen(seleccionado.Id);
                    cargarImagen(seleccionado.Id);
                    Session.Add("ProductoEndetalle", seleccionado);
                    if (Session["listaArticulosEnCarrito"] != null)
                    {
                        listacarrito = (List<Articulo>)Session["listaArticulosEnCarrito"];
                    }
                    else
                    {
                        listacarrito = new List<Articulo>();
                        listacarrito.Add(seleccionado );
                    }
                    

                    Session["ArticulosEnCarrito"]=null;

                }
                else
                {
                    seleccionado = (Articulo)Session["ProductoEndetalle"];
                    lblNombreArticulo.Text = seleccionado.Nombre;
                    lblPrecio.Text = seleccionado.Precio.ToString("F2");
                    lblDescripcion.Text = seleccionado.Descripcion;
                    lblCategoria.Text = seleccionado.Categoria.Descripcion.ToString();
                    lblMarca.Text = seleccionado.Marca.Descripcion.ToString();

                    LecturaImagen lecturaImagen = new LecturaImagen();
                    indiceMaximo = lecturaImagen.maximoImagen(seleccionado.Id);
                    cargarImagen(seleccionado.Id);
                    Session.Add("ProductoEndetalle", seleccionado);
                }
            }

        }
        //No se uso
       /* public void cargarCarrito()
        {
            if (seleccionado != null)
            {
                Session.Add("ArticulosEnCarrito", seleccionado);
            }
        }*/
       
        //Metodo Cargar Img
        private void cargarImagen(int Id)
        {
            try
            {
                LecturaImagen lecturaImagen = new LecturaImagen();
                listaImagenes = lecturaImagen.listar(Id);

                //imgUrlArticulo.ImageUrl = listaImagenes[indiceActual].ImagenUrl;
            }
            catch (Exception)
            {
                //imgUrlArticulo.ImageUrl = "https://storage.googleapis.com/proudcity/mebanenc/uploads/2021/03/placeholder-image.png";
            }
        }

        //Evento click "Comprar Ahora"
        protected void btnComprarAhora_Click(object sender, EventArgs e)
        {
            seleccionado = (Articulo)Session["ProductoEndetalle"];
                        
            Session.Add("ArticulosEnCarrito", seleccionado);

            Response.Redirect("VentanaCarrito.aspx");
        }
        
        //Evento click "Agregar Carrito"
        protected void btnAgregarCarrito_Click(object sender, EventArgs e)
        {
            seleccionado = (Articulo)Session["ProductoEndetalle"];
            if (Session["listaArticulosEnCarrito"] != null)
            {
                listacarrito = (List<Articulo>)Session["listaArticulosEnCarrito"];
            }
            else
            {
                listacarrito = new List<Articulo>();
            }
            listacarrito.Add(seleccionado);           

            Session.Add("listaArticulosEnCarrito", listacarrito);

            Response.Redirect("default.aspx");

            //agregar ventana de confirmacion
        }

        //Metodo para enviar una consulta via mail (Falta das funcionalidad)

        //Metodo img click
        protected void BtnImagenes_Click(object sender, EventArgs e)
        {
            masImagenes = true;
        }
    }
}