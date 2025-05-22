using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Modelo
{
    public class Proveedor
    {
        public int IdProveedor { get; set; }
        public string estadoProveedor { get; set; }
        public string per_nombre { get; set; }
        public string per_apellido { get; set; }
        public string per_telefono { get; set; }
        public int IdPersona { get; set; }
        public string per_direccion {  get; set; }
        public string per_correo { get; set; }
        public string pro_estado { get; set; }
    }
}