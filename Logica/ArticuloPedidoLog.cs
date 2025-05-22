using Datos;
using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Logica
{
    public class ArticuloPedidoLog
    {
        ArticuloPedidoDat objArticuloPedido = new ArticuloPedidoDat();
        public List<ArticuloPedido> obtenerArticuloPedido()
        {
            return objArticuloPedido.obtenerArticuloPedido();
        }

        public bool saveArticuloPedido(ArticuloPedido articuloPedido)
        {
            return objArticuloPedido.saveArticuloPedido(articuloPedido);
        }

        public bool updateArticuloPedido(ArticuloPedido articuloPedidoUpdate)
        {
            return objArticuloPedido.updateArticuloPedido(articuloPedidoUpdate);
        }
    }
}