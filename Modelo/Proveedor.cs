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
        public int IdPersona { get; set; }
        public string nombrePersona { get; set; }
    }
}