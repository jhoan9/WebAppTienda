using Datos;
using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Logica
{
    public class PersonaLog
    {
        /* Se crean instancia de la clase ProductsLog 
         * para interactuar con la lógica de negocio.
         */
        PersonaDat objPersona = new PersonaDat();
        public List<Persona> obtenerPersona()
        {
            return objPersona.obtenerPersona();
        }
    }
}