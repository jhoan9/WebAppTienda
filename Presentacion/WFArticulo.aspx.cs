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
        protected void Page_Load(object sender, EventArgs e)
        {
            /* Se verifica si la página se está cargando por primera vez o 
             * si es una devolución de datos del servidor.
             */
            if (!IsPostBack)
            {
                ObtenerArticulos();
            }
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
    }
}