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
            // Validar selección
            if (string.IsNullOrWhiteSpace(DDLArticulo.SelectedValue) || string.IsNullOrWhiteSpace(DDLPedido.SelectedValue))
            {
                LblMensaje.Text = "Debe seleccionar un artículo y un pedido.";
                return;
            }

            // Validar cantidad
            if (!int.TryParse(TBCantidad.Text, out int cantidad) || cantidad <= 0)
            {
                LblMensaje.Text = "La cantidad debe ser un número mayor que 0.";
                return;
            }

            // Crear objeto ArticuloPedido
            ArticuloPedido nuevo = new ArticuloPedido
            {
                IdArticulo = int.Parse(DDLArticulo.SelectedValue),
                IdPedido = int.Parse(DDLPedido.SelectedValue),
                cantidadArticuloPedido = cantidad
            };

            // Guardar en la base de datos
            bool exito = objArticuloPedido.saveArticuloPedido(nuevo);
            if (exito)
            {                
                LimpiarFormulario();
                ObtenerArticuloPedido();
                LblMensaje.Text = "Registro guardado correctamente.";
            }
            else
            {
                LblMensaje.Text = "Error al guardar el registro.";
            }
        }

        protected void BtnActualizar_Click(object sender, EventArgs e)
        {
            // Validar ID
            if (string.IsNullOrWhiteSpace(TBIdArtPed.Text))
            {
                LblMensaje.Text = "Debe seleccionar un registro para actualizar.";
                return;
            }

            // Validar selección
            if (string.IsNullOrWhiteSpace(DDLArticulo.SelectedValue) || string.IsNullOrWhiteSpace(DDLPedido.SelectedValue))
            {
                LblMensaje.Text = "Debe seleccionar un artículo y un pedido.";
                return;
            }

            // Validar cantidad
            if (!int.TryParse(TBCantidad.Text, out int cantidad) || cantidad <= 0)
            {
                LblMensaje.Text = "La cantidad debe ser un número mayor que 0.";
                return;
            }

            // Crear objeto para actualizar
            ArticuloPedido actualizado = new ArticuloPedido
            {
                IdpedidoArticulo = int.Parse(TBIdArtPed.Text),
                IdArticulo = int.Parse(DDLArticulo.SelectedValue),
                IdPedido = int.Parse(DDLPedido.SelectedValue),
                cantidadArticuloPedido = cantidad
            };

            bool exito = objArticuloPedido.updateArticuloPedido(actualizado);
            if (exito)
            {                
                LimpiarFormulario();
                ObtenerArticuloPedido();
                BtnGuardar.Visible = true;
                BtnActualizar.Visible = false;
                LblMensaje.Text = "Registro actualizado correctamente.";
            }
            else
            {
                LblMensaje.Text = "Error al actualizar el registro.";
            }
        }

        private void LimpiarFormulario()
        {
            TBIdArtPed.Text = "";
            DDLArticulo.SelectedIndex = 0;
            DDLPedido.SelectedIndex = 0;
            TBCantidad.Text = "";
            LblMensaje.Text = "";
            BtnGuardar.Visible = true;
            BtnActualizar.Visible = false;
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