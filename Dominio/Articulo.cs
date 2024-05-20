using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Dominio
{
    public class Articulo
    {
        public Articulo()
        {
            Id = 0;
            Codigo = "";
            Nombre = "";
            Descripcion = "";
            Marca = new Marca();
            Categoria = new Categoria();
            ImagenUrl = "";
            Precio = 0;
        }
        public int Id { get; set; }
        [DisplayName("Código")]
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        [DisplayName("Descripción")]
        public string Descripcion { get; set; }
        public Marca Marca { get; set; }
        [DisplayName("Categoría")]
        public Categoria Categoria { get; set; }
        public string ImagenUrl { get; set; }
        public decimal Precio { get; set; }
    }
}
