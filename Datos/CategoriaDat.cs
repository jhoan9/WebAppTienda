using Modelo;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Datos
{
    public class CategoriaDat
    {
        // Se crea una instancia de la clase Persistence para manejar la conexión a la base de datos.
        Persistencia persistencia = new Persistencia();

        // Método para mostrar los productos desde la base de datos.
        public List<Categoria> obtenerCategoria()
        {
            // Se crea una Lista para almacenar los resultados del procedimiento almacenado.
            List<Categoria> lista = new List<Categoria>();

            // Se crea un adaptador de datos para MySQL.
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();

            // Se crea un comando MySQL para seleccionar los productos utilizando un procedimiento almacenado.
            MySqlCommand objSelectCmd = new MySqlCommand();

            // Se establece la conexión del comando utilizando en el método openConnection() de la Clase Persistencia.
            objSelectCmd.Connection = persistencia.openConnection();

            // Se especifica el nombre del procedimiento almacenado a ejecutar.
            objSelectCmd.CommandText = "spSelectCategory";

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
                Categoria categoria = new Categoria
                {
                    IdCategoria = reader.GetInt32("idcategoria"),
                    nombreCategoria = reader.GetString("cat_nombre"),
                    descripcionCategoria = reader.GetString("cat_descripcion")
                };

                // Agregar el producto a la lista
                lista.Add(categoria);
            }
            // Se cierra la conexión después de obtener los datos.
            persistencia.closeConnection();

            // Devuelve la lista de productos
            return lista;
        }

        public bool saveCategory(String _nombre,String _description)
        {
            bool executed = false;
            int row;

            MySqlCommand objectSelectCmd = new MySqlCommand();
            objectSelectCmd.Connection = persistencia.openConnection();
            objectSelectCmd.CommandText = "spInsertCategory";
            objectSelectCmd.CommandType = CommandType.StoredProcedure;
            objectSelectCmd.Parameters.Add("p_name", MySqlDbType.VarString).Value = _nombre;
            objectSelectCmd.Parameters.Add("p_description", MySqlDbType.VarString).Value = _description;

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

        public bool updateCategory(int _idCategory, string _name, String _description)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = persistencia.openConnection();
            objSelectCmd.CommandText = "spUpdateCategory";
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("p_id", MySqlDbType.Int32).Value = _idCategory;
            objSelectCmd.Parameters.Add("p_name", MySqlDbType.VarString).Value = _name;
            objSelectCmd.Parameters.Add("p_description", MySqlDbType.VarString).Value = _description;

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