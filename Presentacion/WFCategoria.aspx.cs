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
    public partial class WFCategoria : System.Web.UI.Page
    {

        CategoriaLog objCategoria = new CategoriaLog();
        protected void Page_Load(object sender, EventArgs e)
        {
            /* Se verifica si la página se está cargando por primera vez o 
                        * si es una devolución de datos del servidor.
                        */            
            if (!IsPostBack)
            {
                ObtenerCategorias();
            }
        }

        private void ObtenerCategorias()
        {
            // Se crea un objeto DataSet para almacenar los datos de los productos.
            List<Categoria> listaCategorias = new List<Categoria>();

            // Se obtienen los datos de los productos utilizando el método showProducts de la instancia objProd de la clase ProductsLog.
            listaCategorias = objCategoria.obtenerCategoria();

            // Se asigna el origen de datos al GridView GVArticulo.
            GVCategoria.DataSource = listaCategorias;

            // Se enlazan los datos con el GridView.
            GVCategoria.DataBind();
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            string nombre = TBNombreCategoria.Text.Trim();
            string descripcion = TBDescripcionCategoria.Text.Trim();

            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(descripcion))
            {
                // Puedes usar un Label para mostrar el error
                LblMensaje.Text = "Debe completar todos los campos.";
                return;
            }

            bool resultado = objCategoria.saveCategory(nombre, descripcion);

            if (resultado)
            {
                TBNombreCategoria.Text = "";
                TBDescripcionCategoria.Text = "";
                ObtenerCategorias();
                LblMensaje.Text = "Datos Guardados correctamente";
            }
        }

        protected void BtnActualizar_Click(object sender, EventArgs e)
        {
            string id = TBId.Text;
            int idParse = int.Parse(id);
            string nombre = TBNombreCategoria.Text.Trim();
            string descripcion = TBDescripcionCategoria.Text.Trim();
            bool resultado = objCategoria.updateCategory(idParse, nombre, descripcion);

            TBNombreCategoria.Text = "";
            TBDescripcionCategoria.Text = "";
            ObtenerCategorias();
            BtnGuardar.Visible = true;
            BtnActualizar.Visible = false;

            if (resultado)
            {                
                ObtenerCategorias();
                LblMensaje.Text = "Datos Actualizados correctamente";
            }
            else
            {
                LblMensaje.Text = "Hubo un error al actualizar";
            }
        }

        protected void GVCategoria_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["ondblclick"] = Page.ClientScript.GetPostBackClientHyperlink(GVCategoria, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Doble clic para editar esta categoría";
            }
        }

        protected void GVCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            // La fila seleccionada está en GVCategoria.SelectedRow
            GridViewRow fila = GVCategoria.SelectedRow;
            // Asumiendo que tienes 3 columnas: ID, Nombre, Descripción
            TBId.Text = fila.Cells[0].Text;
            TBNombreCategoria.Text = fila.Cells[1].Text;
            TBDescripcionCategoria.Text = fila.Cells[2].Text;

            BtnGuardar.Visible = false;
            BtnActualizar.Visible = true;
        }
    }
}