using Datos;
using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Logica
{
    public class ProveedorLog
    {
        /* Se crean instancia de la clase ProductsLog 
         * para interactuar con la lógica de negocio.
         */
        ProveedorDat objProveedor = new ProveedorDat();
        public List<Proveedor> obtenerProveedor()
        {
            return objProveedor.obtenerProveedor();
        }
    }
}