using Datos;
using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Logica
{
    public class ArticuloLog
    {
        /* Se crean instancia de la clase ProductsLog 
         * para interactuar con la lógica de negocio.
         */
        ArticuloDat objArticulo = new ArticuloDat();
        public List<Articulo> obtenerArticulo()
        {
            return objArticulo.obtenerArticulo();
        }

        public bool saveArticulo(Articulo articulo)
        {
            return objArticulo.saveArticulo(articulo);
        }

        /*public bool saveArticuloCopy(String nombre, String marca, Decimal precio, String estado, int idCategoria)
        {
            return objArticulo.saveArticulo(nombre, marca, precio, estado, idCategoria);
        }*/

        public bool updateArticulo(Articulo articuloActualizado)
        {
            return objArticulo.updateArticulo(articuloActualizado);
        }
    }
}