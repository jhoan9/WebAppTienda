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
        ClienteLog objCliente = new ClienteLog();
        protected void Page_Load(object sender, EventArgs e)
        {
            /* Se verifica si la página se está cargando por primera vez o 
             * si es una devolución de datos del servidor.
             */
            if (!IsPostBack)
            {
                ObtenerPedido();
                cargarCliente();
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

        private void cargarCliente()
        {
            List<Cliente> cliente = objCliente.obtenerCliente();
            ddlCliente.DataSource = cliente;
            ddlCliente.DataTextField = "nombrePersona";
            ddlCliente.DataValueField = "IdCliente";
            ddlCliente.DataBind();

            ddlCliente.Items.Insert(0, new ListItem("Seleccionar", ""));
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            // Validaciones básicas
            if (string.IsNullOrWhiteSpace(TBFecha.Text) ||
                string.IsNullOrWhiteSpace(TBDescripcion.Text) ||
                string.IsNullOrWhiteSpace(ddlCliente.SelectedValue))
            {
                LblMensaje.Text = "Todos los campos son obligatorios.";
                return;
            }

            DateTime fecha;
            if (DateTime.TryParse(TBFecha.Text, out fecha))
            {
                // Crear objeto Pedido
                Pedido nuevoPedido = new Pedido
                {
                    fechaPedido = fecha, 
                    descripcionPedido = TBDescripcion.Text.Trim(),
                    IdCliente = int.Parse(ddlCliente.SelectedValue)
                };

                // Guardar en base de datos
                bool exito = objPedido.savePedido(nuevoPedido);
                if (exito)
                {
                    LimpiarFormulario();
                    ObtenerPedido();
                    LblMensaje.Text = "Pedido guardado correctamente.";
                }
                else
                {
                    LblMensaje.Text = "Hubo un error al guardar el pedido.";
                }
            }
            else
            {
                // Mostrar un mensaje de error si la fecha no es válida
                LblMensaje.Text = "La fecha ingresada no es válida.";
            }
        }

        private void LimpiarFormulario()
        {
            TBIdPedido.Text = "";
            TBDescripcion.Text = "";
            TBFecha.Text = "";
            ddlCliente.Text = "";
            LblMensaje.Text = "";
        }


        protected void BtnActualizar_Click(object sender, EventArgs e)
        {
            // Validación básica
            if (string.IsNullOrWhiteSpace(TBIdPedido.Text) ||
                string.IsNullOrWhiteSpace(TBFecha.Text) ||
                string.IsNullOrWhiteSpace(TBDescripcion.Text) ||
                string.IsNullOrWhiteSpace(ddlCliente.SelectedValue))
            {
                LblMensaje.Text = "Todos los campos son obligatorios.";
                return;
            }

            DateTime fecha;
            if (!DateTime.TryParse(TBFecha.Text, out fecha))
            {
                LblMensaje.Text = "La fecha ingresada no es válida.";
                return;
            }

            Pedido pedidoActualizado = new Pedido
            {
                IdPedido = int.Parse(TBIdPedido.Text),
                fechaPedido = fecha,
                descripcionPedido = TBDescripcion.Text.Trim(),
                IdCliente = int.Parse(ddlCliente.SelectedValue)
            };

            bool exito = objPedido.updatePedido(pedidoActualizado);
            if (exito)
            {
                LblMensaje.Text = "Pedido actualizado correctamente.";
                LimpiarFormulario();
                ObtenerPedido();
                BtnActualizar.Visible = false;
                BtnGuardar.Visible = true;
            }
            else
            {
                LblMensaje.Text = "Error al actualizar el pedido.";
            }
        }


        protected void GVPedido_SelectedIndexChanged(object sender, EventArgs e)
        {
            // La fila seleccionada está en GVCategoria.SelectedRow
            GridViewRow fila = GVPedido.SelectedRow;
            // Asumiendo que tienes 3 columnas: ID, Nombre, Descripción
            TBIdPedido.Text = fila.Cells[0].Text;
            DateTime fecha;
            if (DateTime.TryParse(fila.Cells[1].Text, out fecha))
            {
                TBFecha.Text = fecha.ToString("yyyy-MM-dd");
            }
            TBDescripcion.Text = fila.Cells[2].Text;
            ddlCliente.Text = fila.Cells[3].Text;

            BtnGuardar.Visible = false;
            BtnActualizar.Visible = true;
        }

        protected void GVPedido_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["ondblclick"] = Page.ClientScript.GetPostBackClientHyperlink(GVPedido, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Doble clic para editar este Articulo";
            }
        }
    }
}