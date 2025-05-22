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
        protected void Page_Load(object sender, EventArgs e)
        {
            /* Se verifica si la página se está cargando por primera vez o 
             * si es una devolución de datos del servidor.
             */
            if (!IsPostBack)
            {
                ObtenerCliente();
            }
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
    }
}