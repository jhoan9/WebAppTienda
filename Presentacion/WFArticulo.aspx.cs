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
    public partial class WFArticulo : System.Web.UI.Page
    {

        ArticuloLog objArticulo = new ArticuloLog();
        CategoriaLog objCategoria = new CategoriaLog();
        protected void Page_Load(object sender, EventArgs e)
        {
            /* Se verifica si la página se está cargando por primera vez o 
             * si es una devolución de datos del servidor.
             */
            if (!IsPostBack)
            {
                ObtenerArticulos();
                CargarCategorias();
            }
        }

        private void CargarCategorias()
        {
            List<Categoria> categorias = objCategoria.obtenerCategoria();
            DDLCategoria.DataSource = categorias;
            DDLCategoria.DataTextField = "nombreCategoria";
            DDLCategoria.DataValueField = "IdCategoria";
            DDLCategoria.DataBind();

            DDLCategoria.Items.Insert(0, new ListItem("Seleccionar", ""));
        }
        private void ObtenerArticulos()
        {
            // Se crea un objeto DataSet para almacenar los datos de los productos.
            List<Articulo> listaArticulos = new List<Articulo>();

            // Se obtienen los datos de los productos utilizando el método showProducts de la instancia objProd de la clase ProductsLog.
            listaArticulos = objArticulo.obtenerArticulo();

            // Se asigna el origen de datos al GridView GVArticulo.
            GVArticulo.DataSource = listaArticulos;

            // Se enlazan los datos con el GridView.
            GVArticulo.DataBind();
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            // Validaciones básicas
            if (string.IsNullOrWhiteSpace(TBNombre.Text) ||
                string.IsNullOrWhiteSpace(TBMarca.Text) ||
                string.IsNullOrWhiteSpace(TBPrecio.Text) ||
                string.IsNullOrWhiteSpace(DDLEstado.SelectedValue) ||
                string.IsNullOrWhiteSpace(DDLCategoria.SelectedValue))
            {
                LblMensaje.Text = "Todos los campos son obligatorios.";
                return;
            }

            if (!decimal.TryParse(TBPrecio.Text, out decimal precio))
            {
                LblMensaje.Text = "El precio debe ser un número válido.";
                return;
            }

            // Crear objeto artículo
            Articulo nuevoArticulo = new Articulo
            {
                nombreArticulo = TBNombre.Text.Trim(),
                marcaArticulo = TBMarca.Text.Trim(),
                precioArticulo = precio,
                estadoArticulo = DDLEstado.SelectedValue,
                idCategoria = int.Parse(DDLCategoria.SelectedValue)
            };

            // Guardar en base de datos
            bool exito = objArticulo.saveArticulo(nuevoArticulo);
            if (exito)
            {
                LblMensaje.Text = "Artículo guardado correctamente.";
                LimpiarFormulario();
                ObtenerArticulos();
            }
            else
            {
                LblMensaje.Text = "Hubo un error al guardar el artículo.";
            }
        }

        protected void BtnActualizar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TBIdArticulo.Text))
            {
                LblMensaje.Text = "No se ha seleccionado ningún artículo para actualizar.";
                return;
            }

            if (string.IsNullOrWhiteSpace(TBNombre.Text) ||
                string.IsNullOrWhiteSpace(TBMarca.Text) ||
                string.IsNullOrWhiteSpace(TBPrecio.Text) ||
                string.IsNullOrWhiteSpace(DDLEstado.SelectedValue) ||
                string.IsNullOrWhiteSpace(DDLCategoria.SelectedValue))
            {
                LblMensaje.Text = "Todos los campos son obligatorios.";
                return;
            }

            if (!decimal.TryParse(TBPrecio.Text, out decimal precio))
            {
                LblMensaje.Text = "El precio debe ser un número válido.";
                return;
            }

            Articulo articuloActualizado = new Articulo
            {
                IdArticulo = int.Parse(TBIdArticulo.Text),
                nombreArticulo = TBNombre.Text.Trim(),
                marcaArticulo = TBMarca.Text.Trim(),
                precioArticulo = precio,
                estadoArticulo = DDLEstado.SelectedValue,
                idCategoria = int.Parse(DDLCategoria.SelectedValue)
            };

            bool exito = objArticulo.updateArticulo(articuloActualizado);
            if (exito)
            {
                LblMensaje.Text = "Artículo actualizado correctamente.";
                LimpiarFormulario();
                ObtenerArticulos();
                BtnGuardar.Visible = true;
                BtnActualizar.Visible = false;
            }
            else
            {
                LblMensaje.Text = "Hubo un error al actualizar el artículo.";
            }
        }

        private void LimpiarFormulario()
        {
            TBIdArticulo.Text = "";
            TBNombre.Text = "";
            TBMarca.Text = "";
            TBPrecio.Text = "";
            DDLEstado.SelectedIndex = 0;
            DDLCategoria.SelectedIndex = 0;
            LblMensaje.Text = "";
        }

        protected void GVArticulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            // La fila seleccionada está en GVCategoria.SelectedRow
            GridViewRow fila = GVArticulo.SelectedRow;
            // Asumiendo que tienes 3 columnas: ID, Nombre, Descripción
            TBIdArticulo.Text = fila.Cells[0].Text;
            TBNombre.Text = fila.Cells[1].Text;
            TBMarca.Text = fila.Cells[2].Text;
            TBPrecio.Text = fila.Cells[3].Text;
            DDLEstado.Text = fila.Cells[4].Text;
            DDLCategoria.Text = fila.Cells[5].Text;

            BtnGuardar.Visible = false;
            BtnActualizar.Visible = true;
        }

        protected void GVArticulo_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["ondblclick"] = Page.ClientScript.GetPostBackClientHyperlink(GVArticulo, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Doble clic para editar este Articulo";
            }
        }
    }
}