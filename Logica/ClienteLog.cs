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

        public bool saveCliente(Cliente cliente)
        {
            return objCliente.saveCliente(cliente);
        }

        public bool updateCliente(Cliente cliente)
        {
            return objCliente.updateCliente(cliente);
        }
    }
}