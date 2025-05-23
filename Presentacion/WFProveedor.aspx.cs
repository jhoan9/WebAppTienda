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
    public partial class WFProveedor : System.Web.UI.Page
    {
        ProveedorLog objProveedor = new ProveedorLog();
        PersonaLog objPersona = new PersonaLog();
        protected void Page_Load(object sender, EventArgs e)
        {
            /* Se verifica si la página se está cargando por primera vez o 
                        * si es una devolución de datos del servidor.
                        */
            if (!IsPostBack)
            {
                obtenerProveedor();
                CargarPersonas();
            }
        }

        private void obtenerProveedor()
        {
            // Se crea un objeto DataSet para almacenar los datos de los productos.
            List<Proveedor> listaProveedor = new List<Proveedor>();

            // Se obtienen los datos de los productos utilizando el método showProducts de la instancia objProd de la clase ProductsLog.
            listaProveedor = objProveedor.obtenerProveedor();

            // Se asigna el origen de datos al GridView GVArticulo.
            GVProveedor.DataSource = listaProveedor;

            // Se enlazan los datos con el GridView.
            GVProveedor.DataBind();
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

        protected void GVProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
               // La fila seleccionada está en GVCategoria.SelectedRow
            GridViewRow fila = GVProveedor.SelectedRow;
            // Asumiendo que tienes 3 columnas: ID, Nombre, Descripción
            TBIdProveedor.Text = fila.Cells[0].Text;
            ddlEstado.Text = fila.Cells[5].Text;
            ddlPersona.Text = fila.Cells[6].Text;

            BtnGuardar.Visible = false;
            BtnActualizar.Visible = true;
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            // Validaciones básicas
            if (string.IsNullOrWhiteSpace(ddlPersona.Text) ||
                string.IsNullOrWhiteSpace(ddlEstado.Text))
            {
                LblMensaje.Text = "Todos los campos son obligatorios.";
                return;
            }

            // Crear objeto artículo
            Proveedor nuevoProveedor = new Proveedor
            {
                IdPersona = int.Parse(ddlPersona.SelectedValue),
                estadoProveedor = ddlEstado.SelectedValue,
            };

            // Guardar en base de datos
            bool exito = objProveedor.saveProveedor(nuevoProveedor);
            if (exito)
            {
                LblMensaje.Text = "Proveedor guardado correctamente.";
                LimpiarFormulario();
                obtenerProveedor();
            }
            else
            {
                LblMensaje.Text = "Hubo un error al guardar el artículo.";
            }
        }

        private void LimpiarFormulario()
        {
            ddlEstado.SelectedIndex = 0;
            ddlPersona.SelectedIndex = 0;
        }

        protected void BtnActualizar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TBIdProveedor.Text))
            {
                LblMensaje.Text = "No se ha seleccionado ningún artículo para actualizar.";
                return;
            }

            if (string.IsNullOrWhiteSpace(ddlEstado.SelectedValue) ||
                string.IsNullOrWhiteSpace(ddlPersona.SelectedValue))
            {
                LblMensaje.Text = "Todos los campos son obligatorios.";
                return;
            }

            Proveedor proveedorActualizado = new Proveedor
            {
                IdProveedor = int.Parse(TBIdProveedor.Text),
                IdPersona = int.Parse(ddlPersona.SelectedValue),
                estadoProveedor = ddlEstado.SelectedValue
            };

            bool exito = objProveedor.updateProveedor(proveedorActualizado);
            if (exito)
            {
                LblMensaje.Text = "Artículo actualizado correctamente.";
                LimpiarFormulario();
                obtenerProveedor();
                BtnGuardar.Visible = true;
                BtnActualizar.Visible = false;
            }
            else
            {
                LblMensaje.Text = "Hubo un error al actualizar el artículo.";
            }
        }

        protected void GVProveedor_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["ondblclick"] = Page.ClientScript.GetPostBackClientHyperlink(GVProveedor, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Doble clic para editar este Articulo";
            }
        }
    }
}