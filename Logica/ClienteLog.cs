using Datos;
using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Logica
{
    public class ClienteLog
    {
        ClienteDat objCliente = new ClienteDat();
        public List<Cliente> obtenerCliente()
        {
            return objCliente.obtenerCliente();
        }
    }
}