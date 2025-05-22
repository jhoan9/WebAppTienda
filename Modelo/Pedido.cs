using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Modelo
{
    public class Pedido
    {
        public int IdPedido { get; set; }
        public DateTime fechaPedido { get; set; }
        public string descripcionPedido { get; set; }
        public int IdCliente { get; set; }
        public string tipoCliente { get; set; }
    }
}