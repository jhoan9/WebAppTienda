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
        protected void Page_Load(object sender, EventArgs e)
        {
            /* Se verifica si la página se está cargando por primera vez o 
                        * si es una devolución de datos del servidor.
                        */
            if (!IsPostBack)
            {
                obtenerProveedor();
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

        protected void GVProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {

        }

        protected void BtnActualizar_Click(object sender, EventArgs e)
        {

        }
    }
}