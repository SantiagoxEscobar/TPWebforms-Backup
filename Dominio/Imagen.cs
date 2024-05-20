using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Imagen
    {
        public Imagen()
        {
            IdArticulo = 0;
            ImagenUrl = "";
        }
        public int IdArticulo { get; set; }
        public string ImagenUrl { get; set; }
    }
}
