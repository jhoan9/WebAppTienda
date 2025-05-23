using Modelo;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace Datos
{
    public class PersonaDat
    {
        // Se crea una instancia de la clase Persistence para manejar la conexión a la base de datos.
        Persistencia persistencia = new Persistencia();

        // Método para mostrar los Clientes desde la base de datos.
        public List<Persona> obtenerPersona()
        {
            // Se crea una Lista para almacenar los resultados del procedimiento almacenado.
            List<Persona> lista = new List<Persona>();

            // Se crea un adaptador de datos para MySQL.
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();

            // Se crea un comando MySQL para seleccionar los productos utilizando un procedimiento almacenado.
            MySqlCommand objSelectCmd = new MySqlCommand();

            // Se establece la conexión del comando utilizando en el método openConnection() de la Clase Persistencia.
            objSelectCmd.Connection = persistencia.openConnection();

            // Se especifica el nombre del procedimiento almacenado a ejecutar.
            objSelectCmd.CommandText = "spSelectPersona";

            // Se indica el tipo de comando (en este caso un procedimiento almacenado).
            objSelectCmd.CommandType = CommandType.StoredProcedure;

            // Se establece el comando de selección del adaptador de datos.
            objAdapter.SelectCommand = objSelectCmd;

            // Ejecuta el comando y obtiene el lector de datos
            MySqlDataReader reader = objSelectCmd.ExecuteReader();

            // Recorrer los registros devueltos por el procedimiento almacenado
            while (reader.Read())
            {
                // Crear un objeto Producto y asignarle los valores obtenidos
                Persona persona = new Persona
                {
                    IdPersona = reader.GetInt32("idpersona"),
                    nombrePersona = reader.GetString("per_nombre"),
                    apellidoPersona = reader.GetString("per_apellido"),
                    telefonoPersona = reader.GetString("per_telefono"),
                    direccionPersona = reader.GetString("per_direccion"),
                    correoPersona = reader.GetString("per_correo")
                };

                // Agregar el producto a la lista
                lista.Add(persona);
            }
            // Se cierra la conexión después de obtener los datos.
            persistencia.closeConnection();

            // Devuelve la lista de productos
            return lista;
        }

        public bool savePersona(Persona persona)
        {
            bool executed = false;
            int row;

            MySqlCommand objectSelectCmd = new MySqlCommand();
            objectSelectCmd.Connection = persistencia.openConnection();
            objectSelectCmd.CommandText = "spInsertPerson";
            objectSelectCmd.CommandType = CommandType.StoredProcedure;
            objectSelectCmd.Parameters.Add("p_name", MySqlDbType.VarString).Value = persona.nombrePersona;
            objectSelectCmd.Parameters.Add("p_lastName", MySqlDbType.VarString).Value = persona.apellidoPersona;
            objectSelectCmd.Parameters.Add("p_phone", MySqlDbType.VarString).Value = persona.telefonoPersona;
            objectSelectCmd.Parameters.Add("p_addres", MySqlDbType.VarString).Value = persona.direccionPersona;
            objectSelectCmd.Parameters.Add("p_email", MySqlDbType.VarString).Value = persona.correoPersona;

            try
            {
                row = objectSelectCmd.ExecuteNonQuery();
                if (row == 1)
                {
                    executed = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error " + e.ToString());
            }
            persistencia.closeConnection();
            return executed;

        }

        public bool updatePersona(Persona personaActualizado)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = persistencia.openConnection();
            objSelectCmd.CommandText = "spUpdatePerson";
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("p_id", MySqlDbType.Int32).Value = personaActualizado.IdPersona;
            objSelectCmd.Parameters.Add("p_name", MySqlDbType.VarChar).Value = personaActualizado.nombrePersona;
            objSelectCmd.Parameters.Add("p_lastName", MySqlDbType.VarChar).Value = personaActualizado.apellidoPersona;
            objSelectCmd.Parameters.Add("p_phone", MySqlDbType.VarChar).Value = personaActualizado.telefonoPersona;
            objSelectCmd.Parameters.Add("p_address", MySqlDbType.VarChar).Value = personaActualizado.direccionPersona;
            objSelectCmd.Parameters.Add("p_email", MySqlDbType.VarChar).Value = personaActualizado.correoPersona;

            try
            {
                row = objSelectCmd.ExecuteNonQuery();
                if (row == 1)
                {
                    executed = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error " + e.ToString());
            }
            persistencia.closeConnection();
            return executed;
        }
    }
}