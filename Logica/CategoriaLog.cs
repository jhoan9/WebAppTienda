using Datos;
using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Logica
{
    public class CategoriaLog
    {
        CategoriaDat objCategoria = new CategoriaDat();
        public List<Categoria> obtenerCategoria()
        {
            return objCategoria.obtenerCategoria();
        }

        public bool saveCategory(string nombre, string descripcion)
        {
            return objCategoria.saveCategory(nombre, descripcion);
        }

        public bool updateCategory(int id, string nombre, string descripcion)
        {
            return objCategoria.updateCategory(id, nombre, descripcion);
        }
    }
}