using Modelo;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Datos
{
    public class ArticuloPedidoDat
    {
        // Se crea una instancia de la clase Persistence para manejar la conexión a la base de datos.
        Persistencia persistencia = new Persistencia();

        // Método para mostrar los Clientes desde la base de datos.
        public List<ArticuloPedido> obtenerArticuloPedido()
        {
            // Se crea una Lista para almacenar los resultados del procedimiento almacenado.
            List<ArticuloPedido> lista = new List<ArticuloPedido>();

            // Se crea un adaptador de datos para MySQL.
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();

            // Se crea un comando MySQL para seleccionar los productos utilizando un procedimiento almacenado.
            MySqlCommand objSelectCmd = new MySqlCommand();

            // Se establece la conexión del comando utilizando en el método openConnection() de la Clase Persistencia.
            objSelectCmd.Connection = persistencia.openConnection();

            // Se especifica el nombre del procedimiento almacenado a ejecutar.
            objSelectCmd.CommandText = "spSelectArticuloPedidoAll";

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
                ArticuloPedido articuloPedido = new ArticuloPedido
                {
                    IdpedidoArticulo = reader.GetInt32("id_art_ped"),
                    IdArticulo = reader.GetInt32("articulo_id_articulo"),
                    IdPedido = reader.GetInt32("pedido_idpedido"),
                    cantidadArticuloPedido = reader.GetInt32("art_ped_cantidad"),
                    nombreArticulo = reader.GetString("art_nombre"),
                    marcaArticulo = reader.GetString("art_marca"),
                    pedidoDescripcion = reader.GetString("ped_descripcion"),
                    fecha = reader.GetDateTime("ped_fecha"),
                    precioArticulo = reader.GetDecimal("art_precio")

                };

                // Agregar el producto a la lista
                lista.Add(articuloPedido);
            }
            // Se cierra la conexión después de obtener los datos.
            persistencia.closeConnection();

            // Devuelve la lista de productos
            return lista;
        }

        public bool saveArticuloPedido(ArticuloPedido articuloPedido)
        {
            bool executed = false;
            int row;

            MySqlCommand objectSelectCmd = new MySqlCommand();
            objectSelectCmd.Connection = persistencia.openConnection();
            objectSelectCmd.CommandText = "spInsertArticuloPedido";
            objectSelectCmd.CommandType = CommandType.StoredProcedure;
            objectSelectCmd.Parameters.Add("p_articulo_id_articulo", MySqlDbType.Int32).Value = articuloPedido.IdArticulo;
            objectSelectCmd.Parameters.Add("p_pedido_idpedido", MySqlDbType.Int32).Value = articuloPedido.IdPedido;
            objectSelectCmd.Parameters.Add("p_art_pedido_cantidad", MySqlDbType.Int32).Value = articuloPedido.cantidadArticuloPedido;

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

        public bool updateArticuloPedido(ArticuloPedido articuloPedidoActualizado)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = persistencia.openConnection();
            objSelectCmd.CommandText = "spUpdateArticuloPedido";
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("p_id", MySqlDbType.Int32).Value = articuloPedidoActualizado.IdpedidoArticulo;
            objSelectCmd.Parameters.Add("p_articulo_id_articulo", MySqlDbType.Int32).Value = articuloPedidoActualizado.IdArticulo;
            objSelectCmd.Parameters.Add("p_pedido_idpedido", MySqlDbType.Int32).Value = articuloPedidoActualizado.IdArticulo;
            objSelectCmd.Parameters.Add("p_art_pedido_cantidad", MySqlDbType.Int32).Value = articuloPedidoActualizado.cantidadArticuloPedido;

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