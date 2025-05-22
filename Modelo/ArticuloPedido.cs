using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Modelo
{
    public class ArticuloPedido
    {
        public int IdpedidoArticulo { get; set; }
        public int IdArticulo { get; set; }
        public int IdPedido { get; set; }
        public int cantidadArticuloPedido { get; set; }
        public string nombreArticulo { get; set; }
        public string marcaArticulo { get; set; }
        public string pedidoDescripcion { get; set; }   
        public DateTime fecha { get; set; }
        public decimal precioArticulo { get; set; }

    }
}