using Modelo;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Datos
{
    public class PedidoDat
    {
        // Se crea una instancia de la clase Persistence para manejar la conexión a la base de datos.
        Persistencia persistencia = new Persistencia();

        // Método para mostrar los productos desde la base de datos.
        public List<Pedido> obtenerPedido()
        {
            // Se crea una Lista para almacenar los resultados del procedimiento almacenado.
            List<Pedido> lista = new List<Pedido>();

            // Se crea un adaptador de datos para MySQL.
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();

            // Se crea un comando MySQL para seleccionar los productos utilizando un procedimiento almacenado.
            MySqlCommand objSelectCmd = new MySqlCommand();

            // Se establece la conexión del comando utilizando en el método openConnection() de la Clase Persistencia.
            objSelectCmd.Connection = persistencia.openConnection();

            // Se especifica el nombre del procedimiento almacenado a ejecutar.
            objSelectCmd.CommandText = "spSelectPedido";

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
                Pedido pedido = new Pedido
                {
                    IdPedido = reader.GetInt32("idpedido"),
                    fechaPedido = reader.GetDateTime("ped_fecha"),
                    descripcionPedido = reader.GetString("ped_descripcion"),
                    IdCliente = reader.GetInt32("cliente_dni")
                };

                // Agregar el producto a la lista
                lista.Add(pedido);
            }
            // Se cierra la conexión después de obtener los datos.
            persistencia.closeConnection();

            // Devuelve la lista de productos
            return lista;
        }

        public bool savePedido(DateTime _p_ped_fecha, String _p_ped_descripcion, int _p_cliente_dni)
        {
            bool executed = false;
            int row;

            MySqlCommand objectSelectCmd = new MySqlCommand();
            objectSelectCmd.Connection = persistencia.openConnection();
            objectSelectCmd.CommandText = "spInsertPedido";
            objectSelectCmd.CommandType = CommandType.StoredProcedure;
            objectSelectCmd.Parameters.Add("p_ped_fecha", MySqlDbType.DateTime).Value = _p_ped_fecha;
            objectSelectCmd.Parameters.Add("p_ped_descripcion", MySqlDbType.VarString).Value = _p_ped_descripcion;
            objectSelectCmd.Parameters.Add("p_cliente_dni", MySqlDbType.Int24).Value = _p_cliente_dni;


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

        public bool updateArticulo(int _p_id, DateTime _p_ped_fecha, String _p_ped_descripcion, int _p_cliente_dni)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = persistencia.openConnection();
            objSelectCmd.CommandText = "spUpdatePedido";
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("p_id", MySqlDbType.Int32).Value = _p_id;
            objSelectCmd.Parameters.Add("p_ped_fecha", MySqlDbType.DateTime).Value = _p_ped_fecha;
            objSelectCmd.Parameters.Add("p_ped_descripcion", MySqlDbType.VarString).Value = _p_ped_descripcion;
            objSelectCmd.Parameters.Add("p_cliente_dni", MySqlDbType.Int32).Value = _p_cliente_dni;


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