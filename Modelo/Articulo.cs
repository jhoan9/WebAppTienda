using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Modelo
{
    public class Articulo
    {
        public int IdArticulo { get; set; }
        public string nombreArticulo { get; set; }
        public string marcaArticulo { get; set; }
        public decimal precioArticulo { get; set; }
        public string estadoArticulo { get; set; }
        public int idCategoria { get; set; }
        public string nombreCategoria { get; set; }
    }
}