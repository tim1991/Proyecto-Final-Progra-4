using Capa.Entidades;
using System;
using System.Collections.Generic;
using Capa.Utilidades.GuardaErrores;
;

namespace Capa.LogicaNegocio.Productos
{
    public class ProductosLogica
    {

        /// <summary>
        /// Logica para obtener los productos x categoria
        /// </summary>
        /// <param name="IdCategoria"></param>
        /// <returns></returns>
        public Producto ObtieneProductosXCategoria(int IdCategoria)
        {
            try
            {
                Producto objProduc = new Producto();
                Capa.AccesoDatos.AccesoDatos Producto = new Capa.AccesoDatos.AccesoDatos();
                objProduc = Producto.ObtenerProductosXCategoria(IdCategoria);
                return objProduc;
            }
            catch (Exception ex)
            {
                GuardaErrores ErroresLog = new GuardaErrores();
                string NombreMetodo = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErroresLog.InsertarErrores(NombreMetodo, "AccesoDatosProducto", ex.Message, ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Logica para obtener los productos
        /// </summary>
        /// <returns></returns>
        public List<Producto> ObtieneProductos()
        {
            try
            {
                List<Producto> objProduc = new List<Producto>();
                Capa.AccesoDatos.AccesoDatos Producto = new Capa.AccesoDatos.AccesoDatos();
                objProduc = Producto.ObtenerProductos();
                return objProduc;
            }
            catch (Exception ex)
            {
                GuardaErrores ErroresLog = new GuardaErrores();
                string NombreMetodo = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErroresLog.InsertarErrores(NombreMetodo, "AccesoDatosProducto", ex.Message, ex.StackTrace);
                return null;
            }
        }
    }
}
