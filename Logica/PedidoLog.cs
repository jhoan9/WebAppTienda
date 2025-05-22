using Datos;
using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Logica
{
    public class PedidoLog
    {
        /* Se crean instancia de la clase PedidoLog 
         * para interactuar con la lógica de negocio.
         */
        PedidoDat objPedido = new PedidoDat();
        public List<Pedido> obtenerPedido()
        {
            return objPedido.obtenerPedido();
        }
    }
}