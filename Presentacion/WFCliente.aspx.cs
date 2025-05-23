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
    public partial class WFCliente : System.Web.UI.Page
    {
        ClienteLog objCliente = new ClienteLog();
        PersonaLog objPersona = new PersonaLog();
        protected void Page_Load(object sender, EventArgs e)
        {
            /* Se verifica si la página se está cargando por primera vez o 
             * si es una devolución de datos del servidor.
             */
            if (!IsPostBack)
            {
                ObtenerCliente();
                CargarPersonas();
            }
        }

        private void CargarPersonas()
        {
            List<Persona> personas = objPersona.obtenerPersona();
            ddlPersona.DataSource = personas;
            ddlPersona.DataTextField = "nombrePersona";
            ddlPersona.DataValueField = "IdPersona";
            ddlPersona.DataBind();

            ddlPersona.Items.Insert(0, new ListItem("Seleccionar", ""));
        }

        private void ObtenerCliente()
        {
            // Se crea un objeto DataSet para almacenar los datos de los productos.
            List<Cliente> listaArticulos = new List<Cliente>();

            // Se obtienen los datos de los productos utilizando el método showProducts de la instancia objProd de la clase ProductsLog.
            listaArticulos = objCliente.obtenerCliente();

            // Se asigna el origen de datos al GridView GVArticulo.
            GVCliente.DataSource = listaArticulos;

            // Se enlazan los datos con el GridView.
            GVCliente.DataBind();
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            // Validaciones básicas
            if (string.IsNullOrWhiteSpace(ddlPersona.Text) ||
                string.IsNullOrWhiteSpace(ddlTipo.Text))
            {
                LblMensaje.Text = "Todos los campos son obligatorios.";
                return;
            }

            //Crear objeto artículo
            Cliente nuevoCliente = new Cliente
            {
                IdPersona = int.Parse(ddlPersona.SelectedValue),
                tipoCliente = ddlTipo.SelectedValue,
            };

            // Guardar en base de datos
            bool exito = objCliente.saveCliente(nuevoCliente);
            if (exito)
            {
                LimpiarFormulario();
                ObtenerCliente();
                LblMensaje.Text = "Cliente guardado correctamente.";
            }
            else
            {
                LblMensaje.Text = "Hubo un error al guardar el artículo.";
            }
        }

        private void LimpiarFormulario()
        {
            ddlTipo.SelectedIndex = 0;
            ddlPersona.SelectedIndex = 0;
        }

        protected void BtnActualizar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TBIdCliente.Text))
            {
                LblMensaje.Text = "No se ha seleccionado ningún artículo para actualizar.";
                return;
            }

            if (string.IsNullOrWhiteSpace(ddlTipo.SelectedValue) ||
                string.IsNullOrWhiteSpace(ddlPersona.SelectedValue))
            {
                LblMensaje.Text = "Todos los campos son obligatorios.";
                return;
            }

            Cliente clienteActualizado = new Cliente
            {
                IdCliente = int.Parse(TBIdCliente.Text),
                IdPersona = int.Parse(ddlPersona.SelectedValue),
                tipoCliente = ddlTipo.SelectedValue
            };

            bool exito = objCliente.updateCliente(clienteActualizado);
            if (exito)
            {
                LblMensaje.Text = "Cliente actualizado correctamente.";
                LimpiarFormulario();
                ObtenerCliente();
                BtnGuardar.Visible = true;
                BtnActualizar.Visible = false;
            }
            else
            {
                LblMensaje.Text = "Hubo un error al actualizar el artículo.";
            }
        }

        protected void GVCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            // La fila seleccionada está en GVCategoria.SelectedRow
            GridViewRow fila = GVCliente.SelectedRow;
            // Asumiendo que tienes 3 columnas: ID, Nombre, Descripción
            TBIdCliente.Text = fila.Cells[0].Text;
            ddlTipo.Text = fila.Cells[1].Text;
            ddlPersona.Text = fila.Cells[3].Text;

            BtnGuardar.Visible = false;
            BtnActualizar.Visible = true;
        }

        protected void GVCliente_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["ondblclick"] = Page.ClientScript.GetPostBackClientHyperlink(GVCliente, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Doble clic para editar esta categoría";
            }
        }
    }
}