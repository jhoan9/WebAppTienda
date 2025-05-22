using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Modelo
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string tipoCliente { get; set; }
        public int IdPersona { get; set; }
        public string nombrePersona { get; set; }
    }
}