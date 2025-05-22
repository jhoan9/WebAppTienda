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
        ArticuloLog objArticulo = new ArticuloLog();
        PedidoLog objPedido = new PedidoLog();
        protected void Page_Load(object sender, EventArgs e)
        {
            /* Se verifica si la página se está cargando por primera vez o 
             * si es una devolución de datos del servidor.
             */
            if (!IsPostBack)
            {
                ObtenerArticuloPedido();
                ObtenerArticulos();
                ObtenerPedidos();
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

        private void ObtenerArticulos()
        {
            List<Articulo> articulos = objArticulo.obtenerArticulo();
            DDLArticulo.DataSource = articulos;
            DDLArticulo.DataTextField = "nombreArticulo";
            DDLArticulo.DataValueField = "IdArticulo";
            DDLArticulo.DataBind();

            DDLArticulo.Items.Insert(0, new ListItem("Seleccionar", ""));
        }

        private void ObtenerPedidos()
        {
            List<Pedido> pedidos = objPedido.obtenerPedido();
            DDLPedido.DataSource = pedidos;
            DDLPedido.DataTextField = "descripcionPedido";
            DDLPedido.DataValueField = "IdPedido";
            DDLPedido.DataBind();

            DDLPedido.Items.Insert(0, new ListItem("Seleccionar", ""));
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {

        }

        protected void BtnActualizar_Click(object sender, EventArgs e)
        {

        }

        protected void GVArticuloPedido_SelectedIndexChanged(object sender, EventArgs e)
        {
            // La fila seleccionada está en GVCategoria.SelectedRow
            GridViewRow fila = GVArticuloPedido.SelectedRow;
            // Asumiendo que tienes 3 columnas: ID, Nombre, Descripción
            TBIdArtPed.Text = fila.Cells[0].Text;
            DDLArticulo.Text = fila.Cells[1].Text;
            DDLPedido.Text = fila.Cells[2].Text;
            TBCantidad.Text = fila.Cells[3].Text;

            BtnGuardar.Visible = false;
            BtnActualizar.Visible = true;
        }

        protected void GVArticuloPedido_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["ondblclick"] = Page.ClientScript.GetPostBackClientHyperlink(GVArticuloPedido, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Doble clic para editar este Articulo";
            }
        }
    }
}