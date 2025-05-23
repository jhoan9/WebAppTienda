using Modelo;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Datos
{
    public class ProveedorDat
    {
        // Se crea una instancia de la clase Persistence para manejar la conexión a la base de datos.
        Persistencia persistencia = new Persistencia();

        // Método para mostrar los Proveedores desde la base de datos.
        public List<Proveedor> obtenerProveedor()
        {
            // Se crea una Lista para almacenar los resultados del procedimiento almacenado.
            List<Proveedor> lista = new List<Proveedor>();

            // Se crea un adaptador de datos para MySQL.
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();

            // Se crea un comando MySQL para seleccionar los productos utilizando un procedimiento almacenado.
            MySqlCommand objSelectCmd = new MySqlCommand();

            // Se establece la conexión del comando utilizando en el método openConnection() de la Clase Persistencia.
            objSelectCmd.Connection = persistencia.openConnection();

            // Se especifica el nombre del procedimiento almacenado a ejecutar.
            objSelectCmd.CommandText = "spSelectProveedorAll";

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
                Proveedor proveedor = new Proveedor
                {
                    IdProveedor = reader.GetInt32("idproveedor"),
                    estadoProveedor = reader.GetString("pro_estado"),
                    IdPersona = reader.GetInt32("persona_idpersona"),
                    per_telefono = reader.GetString("per_telefono"),
                    per_direccion = reader.GetString("per_direccion"),
                    per_correo = reader.GetString("per_correo"),
                    pro_estado = reader.GetString("pro_estado"),
                    per_nombre = reader.GetString("per_nombre")
                };

                // Agregar el producto a la lista
                lista.Add(proveedor);
            }
            // Se cierra la conexión después de obtener los datos.
            persistencia.closeConnection();

            // Devuelve la lista de productos
            return lista;
        }

        public bool saveProveedor(Proveedor proveedor)
        {
            bool executed = false;
            int row;

            MySqlCommand objectSelectCmd = new MySqlCommand();
            objectSelectCmd.Connection = persistencia.openConnection();
            objectSelectCmd.CommandText = "spInsertProveedor";
            objectSelectCmd.CommandType = CommandType.StoredProcedure;
            objectSelectCmd.Parameters.Add("p_estado", MySqlDbType.VarString).Value = proveedor.estadoProveedor;
            objectSelectCmd.Parameters.Add("p_idpersona", MySqlDbType.VarString).Value = proveedor.IdPersona;

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
        
        public bool updateProveedor(Proveedor proveedorActualizado)
        {
            bool executed = false;
            int row;
            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = persistencia.openConnection();
            objSelectCmd.CommandText = "spUpdateProveedor";
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("p_id", MySqlDbType.Int32).Value = proveedorActualizado.IdProveedor;
            objSelectCmd.Parameters.Add("p_estado", MySqlDbType.VarString).Value = proveedorActualizado.estadoProveedor;
            objSelectCmd.Parameters.Add("p_idPersona", MySqlDbType.Int32).Value = proveedorActualizado.IdPersona;


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