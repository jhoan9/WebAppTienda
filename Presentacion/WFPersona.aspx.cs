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
    public partial class WFPersona : System.Web.UI.Page
    {
        PersonaLog objPersona = new PersonaLog();

        protected void Page_Load(object sender, EventArgs e)
        {
            /* Se verifica si la página se está cargando por primera vez o 
             * si es una devolución de datos del servidor.
             */
            if (!IsPostBack)
            {
                ObtenerPersona();
            }
        }

        private void ObtenerPersona()
        {
            // Se crea un objeto DataSet para almacenar los datos de los productos.
            List<Persona> listaPersona = new List<Persona>();

            // Se obtienen los datos de los productos utilizando el método showProducts de la instancia objProd de la clase ProductsLog.
            listaPersona = objPersona.obtenerPersona();

            // Se asigna el origen de datos al GridView GVPersona.
            GVPersona.DataSource = listaPersona;

            // Se enlazan los datos con el GridView.
            GVPersona.DataBind();
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TBNombre.Text) ||
                string.IsNullOrWhiteSpace(TBApellido.Text) ||
                string.IsNullOrWhiteSpace(TBTelefono.Text) ||
                string.IsNullOrWhiteSpace(TBDireccion.Text) ||
                string.IsNullOrWhiteSpace(TBEmail.Text))
            {
                LblMensaje.Text = "Todos los campos son obligatorios.";
                return;
            }

            // Crear objeto artículo 
            Persona nuevaPersona = new Persona
            {
                nombrePersona = TBNombre.Text.Trim(),
                apellidoPersona = TBApellido.Text.Trim(),
                telefonoPersona = TBTelefono.Text.Trim(),
                direccionPersona = TBDireccion.Text.Trim(),
                correoPersona = TBEmail.Text.Trim()
            };

            // Guardar en base de datos
            bool exito = objPersona.savePersona(nuevaPersona);
            if (exito)
            {
                LblMensaje.Text = "Persona guardada correctamente.";
                LimpiarFormulario();
                ObtenerPersona(); // Cargar GridView u otra vista
            }
            else
            {
                LblMensaje.Text = "Hubo un error al guardar los datos.";
            }
        }

        protected void BtnActualizar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TBIdPersona.Text))
            {
                LblMensaje.Text = "No se ha seleccionado ningún resgistro para actualizar.";
                return;
            }

            if (string.IsNullOrWhiteSpace(TBNombre.Text) ||
                string.IsNullOrWhiteSpace(TBApellido.Text) ||
                string.IsNullOrWhiteSpace(TBTelefono.Text) ||
                string.IsNullOrWhiteSpace(TBDireccion.Text) ||
                string.IsNullOrWhiteSpace(TBEmail.Text))
            {
                LblMensaje.Text = "Todos los campos son obligatorios.";
                return;
            }

            Persona personaActualizado = new Persona
            {
                IdPersona = int.Parse(TBIdPersona.Text),
                nombrePersona = TBNombre.Text.Trim(),
                apellidoPersona = TBApellido.Text.Trim(),
                telefonoPersona = TBTelefono.Text.Trim(),
                direccionPersona = TBDireccion.Text.Trim(),
                correoPersona = TBEmail.Text.Trim()
            };

            bool exito = objPersona.updatePersona(personaActualizado);
            if (exito)
            {
                LblMensaje.Text = "Persona actualizada correctamente.";
                ObtenerPersona();
                LimpiarFormulario();
                BtnActualizar.Visible = false;
                BtnGuardar.Visible = true;

            }
            else
            {
                LblMensaje.Text = "Hubo un error al actualizar los datos.";
            }
        }
        private void LimpiarFormulario()
        {
            TBNombre.Text = "";
            TBApellido.Text = "";
            TBTelefono.Text = "";
            TBDireccion.Text = "";
            TBEmail.Text = "";
        }

        protected void GVPersona_SelectedIndexChanged(object sender, EventArgs e)
        {

            GridViewRow fila = GVPersona.SelectedRow;
            TBIdPersona.Text = fila.Cells[0].Text;
            TBNombre.Text = fila.Cells[1].Text;
            TBApellido.Text = fila.Cells[2].Text;
            TBTelefono.Text = fila.Cells[3].Text;
            TBDireccion.Text = fila.Cells[4].Text;
            TBEmail.Text = fila.Cells[5].Text;

            BtnGuardar.Visible = false;
            BtnActualizar.Visible = true;


        }
        protected void GVPersona_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["ondblclick"] = Page.ClientScript.GetPostBackClientHyperlink(GVPersona, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Doble clic para editar los datos";


            }
        }
    }
}