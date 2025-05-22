using Modelo;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace Datos
{
    public class ArticuloDat
    {
        // Se crea una instancia de la clase Persistence para manejar la conexión a la base de datos.
        Persistencia persistencia = new Persistencia();

        // Método para mostrar los productos desde la base de datos.
        public List<Articulo> obtenerArticulo()
        {
            // Se crea una Lista para almacenar los resultados del procedimiento almacenado.
            List<Articulo> lista = new List<Articulo>();

            // Se crea un adaptador de datos para MySQL.
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();

            // Se crea un comando MySQL para seleccionar los productos utilizando un procedimiento almacenado.
            MySqlCommand objSelectCmd = new MySqlCommand();

            // Se establece la conexión del comando utilizando en el método openConnection() de la Clase Persistencia.
            objSelectCmd.Connection = persistencia.openConnection();

            // Se especifica el nombre del procedimiento almacenado a ejecutar.
            objSelectCmd.CommandText = "spSelectArticle";

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
                Articulo articulo = new Articulo
                {
                    IdArticulo = reader.GetInt32("id_articulo"),
                    nombreArticulo = reader.GetString("art_nombre"),
                    marcaArticulo = reader.GetString("art_marca"),
                    precioArticulo = reader.GetDecimal("art_precio"),
                    estadoArticulo = reader.GetString("art_estado"),
                    idCategoria = reader.GetInt32("categoria_idcategoria"),
                    //nombreCategoria = reader.GetString("cat_descripcion")
                };

                // Agregar el producto a la lista
                lista.Add(articulo);
            }
            // Se cierra la conexión después de obtener los datos.
            persistencia.closeConnection();

            // Devuelve la lista de productos
            return lista;
        }

        public bool saveArticulo(Articulo articulo)
        {
            bool executed = false;
            int row;

            MySqlCommand objectSelectCmd = new MySqlCommand();
            objectSelectCmd.Connection = persistencia.openConnection();
            objectSelectCmd.CommandText = "spInsertArticle";
            objectSelectCmd.CommandType = CommandType.StoredProcedure;
            objectSelectCmd.Parameters.Add("p_name", MySqlDbType.VarString).Value = articulo.nombreArticulo;
            objectSelectCmd.Parameters.Add("p_marca", MySqlDbType.VarString).Value = articulo.marcaArticulo;
            objectSelectCmd.Parameters.Add("p_precio", MySqlDbType.Decimal).Value = articulo.precioArticulo;
            objectSelectCmd.Parameters.Add("p_estado", MySqlDbType.VarString).Value = articulo.estadoArticulo;
            objectSelectCmd.Parameters.Add("p_categoria_id", MySqlDbType.Int24).Value = articulo.idCategoria;            


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

        public bool updateArticulo(Articulo articuloActualizado)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = persistencia.openConnection();
            objSelectCmd.CommandText = "spUpdateArticle";
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("p_id", MySqlDbType.Int32).Value = articuloActualizado.IdArticulo;
            objSelectCmd.Parameters.Add("p_name", MySqlDbType.VarString).Value = articuloActualizado.nombreArticulo;
            objSelectCmd.Parameters.Add("p_marca", MySqlDbType.VarString).Value = articuloActualizado.marcaArticulo;
            objSelectCmd.Parameters.Add("p_precio", MySqlDbType.Decimal).Value = articuloActualizado.precioArticulo;
            objSelectCmd.Parameters.Add("p_estado", MySqlDbType.VarString).Value = articuloActualizado.estadoArticulo;
            objSelectCmd.Parameters.Add("p_categoria_id", MySqlDbType.Int32).Value = articuloActualizado.idCategoria;


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