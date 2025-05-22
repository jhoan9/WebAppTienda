using Logica;
using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class WFPedido : System.Web.UI.Page
    {
        PedidoLog objPedido = new PedidoLog();
        protected void Page_Load(object sender, EventArgs e)
        {
            /* Se verifica si la página se está cargando por primera vez o 
             * si es una devolución de datos del servidor.
             */
            if (!IsPostBack)
            {
                ObtenerPedido();
            }
        }

        private void ObtenerPedido()
        {
            // Se crea un objeto DataSet para almacenar los datos de los productos.
            List<Pedido> listaArticulos = new List<Pedido>();

            // Se obtienen los datos de los productos utilizando el método showProducts de la instancia objProd de la clase ProductsLog.
            listaArticulos = objPedido.obtenerPedido();

            // Se asigna el origen de datos al GridView GVArticulo.
            GVPedido.DataSource = listaArticulos;

            // Se enlazan los datos con el GridView.
            GVPedido.DataBind();
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {

        }

        protected void BtnActualizar_Click(object sender, EventArgs e)
        {

        }

        protected void GVPedido_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}