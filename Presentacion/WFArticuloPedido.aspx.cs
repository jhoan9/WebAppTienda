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
    public partial class WFArticuloPedido : System.Web.UI.Page
    {
        ArticuloPedidoLog objArticuloPedido = new ArticuloPedidoLog();
        protected void Page_Load(object sender, EventArgs e)
        {
            /* Se verifica si la página se está cargando por primera vez o 
             * si es una devolución de datos del servidor.
             */
            if (!IsPostBack)
            {
                ObtenerArticuloPedido();
            }
        }

        private void ObtenerArticuloPedido()
        {
            // Se crea un objeto DataSet para almacenar los datos de los productos.
            List<ArticuloPedido> listaArticulos = new List<ArticuloPedido>();

            // Se obtienen los datos de los productos utilizando el método showProducts de la instancia objProd de la clase ProductsLog.
            listaArticulos = objArticuloPedido.obtenerArticuloPedido();

            // Se asigna el origen de datos al GridView GVArticulo.
            GVArticuloPedido.DataSource = listaArticulos;

            // Se enlazan los datos con el GridView.
            GVArticuloPedido.DataBind();
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {

        }

        protected void BtnActualizar_Click(object sender, EventArgs e)
        {

        }

        protected void GVArticuloPedido_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}