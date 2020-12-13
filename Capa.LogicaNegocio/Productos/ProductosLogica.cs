using Capa.Entidades;
using System;
using System.Collections.Generic;
using Capa.Utilidades.GuardaErrores;

namespace Capa.LogicaNegocio.Productos
{
    public class ProductosLogica
    {

        public List<Producto> objProduc = new List<Producto>();

        /// <summary>
        /// Logica para obtener los productos x categoria
        /// </summary>
        /// <param name="IdCategoria"></param>
        /// <returns></returns>
        public List<Producto> ObtieneProductosXCategoria(int IdCategoria)
        {
            try
            {
                Capa.AccesoDatos.AccesoDatos Producto = new Capa.AccesoDatos.AccesoDatos();
                objProduc = Producto.ObtenerProductosXCategoria(IdCategoria);
                return objProduc;
            }
            catch (Exception ex)
            {
                GuardaErrores ErroresLog = new GuardaErrores();
                string NombreMetodo = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErroresLog.InsertarErrores(NombreMetodo, "LogicaProducto", ex.Message, ex.StackTrace);
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
                Capa.AccesoDatos.AccesoDatos Producto = new Capa.AccesoDatos.AccesoDatos();
                objProduc = Producto.ObtenerProductos();
                return objProduc;
            }
            catch (Exception ex)
            {
                GuardaErrores ErroresLog = new GuardaErrores();
                string NombreMetodo = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErroresLog.InsertarErrores(NombreMetodo, "LogicaProducto", ex.Message, ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Obtiene y retorna la cantidad disponible de productos
        /// </summary>
        /// <param name="IdProducto"></param>
        /// <returns></returns>
        public int ObtieneCantidadSisponibleProductos(int IdProducto)
        {
            int CantidadDisponible = 0;
            try
            {
                Capa.AccesoDatos.AccesoDatos Producto = new Capa.AccesoDatos.AccesoDatos();
                CantidadDisponible = Producto.ObtieneCantidadProductos(IdProducto);
                return CantidadDisponible;
            }
            catch (Exception ex)
            {
                GuardaErrores ErroresLog = new GuardaErrores();
                string NombreMetodo = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErroresLog.InsertarErrores(NombreMetodo, "LogicaProducto", ex.Message, ex.StackTrace);
                return CantidadDisponible;
            }
        }
    }
}
