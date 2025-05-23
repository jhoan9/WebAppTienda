using Modelo;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Datos
{
    public class ClienteDat
    {
        // Se crea una instancia de la clase Persistence para manejar la conexión a la base de datos.
        Persistencia persistencia = new Persistencia();

        // Método para mostrar los Clientes desde la base de datos.
        public List<Cliente> obtenerCliente()
        {
            // Se crea una Lista para almacenar los resultados del procedimiento almacenado.
            List<Cliente> lista = new List<Cliente>();

            // Se crea un adaptador de datos para MySQL.
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();

            // Se crea un comando MySQL para seleccionar los productos utilizando un procedimiento almacenado.
            MySqlCommand objSelectCmd = new MySqlCommand();

            // Se establece la conexión del comando utilizando en el método openConnection() de la Clase Persistencia.
            objSelectCmd.Connection = persistencia.openConnection();

            // Se especifica el nombre del procedimiento almacenado a ejecutar.
            objSelectCmd.CommandText = "spSelectCliente";

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
                Cliente cliente = new Cliente
                {
                    IdCliente = reader.GetInt32("dni"),
                    tipoCliente = reader.GetString("cli_tipo"),
                    IdPersona = reader.GetInt32("persona_idpersona"),
                    nombrePersona = reader.GetString("per_nombre")
                   
                };

                // Agregar el producto a la lista
                lista.Add(cliente);
            }
            // Se cierra la conexión después de obtener los datos.
            persistencia.closeConnection();

            // Devuelve la lista de productos
            return lista;
        }

        public bool saveCliente(Cliente cliente)
        {
            bool executed = false;
            int row;

            MySqlCommand objectSelectCmd = new MySqlCommand();
            objectSelectCmd.Connection = persistencia.openConnection();
            objectSelectCmd.CommandText = "spInsertCliente";
            objectSelectCmd.CommandType = CommandType.StoredProcedure;
            objectSelectCmd.Parameters.Add("p_cli_tipo", MySqlDbType.VarString).Value = cliente.tipoCliente;
            objectSelectCmd.Parameters.Add("p_persona_id_persona", MySqlDbType.Int32).Value = cliente.IdPersona;

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
        
        public bool updateCliente(Cliente cliente)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = persistencia.openConnection();
            objSelectCmd.CommandText = "spUpdateCliente";
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("p_id", MySqlDbType.Int32).Value = cliente.IdCliente;
            objSelectCmd.Parameters.Add("p_cli_tipo", MySqlDbType.VarString).Value = cliente.tipoCliente;
            objSelectCmd.Parameters.Add("p_persona_id_persona", MySqlDbType.VarString).Value = cliente.IdPersona;

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