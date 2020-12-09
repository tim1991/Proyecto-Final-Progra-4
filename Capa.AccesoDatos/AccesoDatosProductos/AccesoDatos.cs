using Capa.Utilidades.GuardaErrores;
using Capa.Entidades;
using System;
using System.Collections.Generic;
using Capa.AccesoDatos.SQLLinqCarritoCompras;
using System.Linq;

namespace Capa.AccesoDatos
{
    public class AccesoDatos
    {

        

        /// <summary>
        /// Obtiene la todos los productos por categoria
        /// </summary>
        /// <returns></returns>
        public List<Producto> ObtenerProductos()
        {
            List<Producto> listaProductos = new List<Producto>();
            try
            {
               
                
                using (CarritoDataContext Carrito = new CarritoDataContext())
                {
                    List<sp_ObtieneProductosResult> list = Carrito.sp_ObtieneProductos().ToList();


                    foreach (var item in list)
                    {
                        Producto objProducto = new Producto();
                        objProducto.IdProducto = item.IdProducto;
                        objProducto.NombreProducto = item.NombreProducto;
                        objProducto.PrecioProducto = item.PrecioProducto;
                        objProducto.DescripcionProducto = item.DescripcionProducto;
                        objProducto.IdCategoria = item.IdCategoria;
                        objProducto.ImagenProducto = item.ImagenProducto;

                        listaProductos.Add(objProducto);
                    }
                    return listaProductos;
                }


            }
            catch (Exception ex)
            {
                GuardaErrores ErroresLog = new GuardaErrores();
                string NombreMetodo = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErroresLog.InsertarErrores(NombreMetodo, "AccesoDatosProducto", ex.Message, ex.StackTrace);
                return listaProductos;
            }
        }

        /// <summary>
        /// Obtiene la todos los productos por categoria
        /// </summary>
        /// <param name="IdCategoria"></param>
        /// <returns></returns>
        public List<Producto> ObtenerProductosXCategoria(int IdCategoria)
        {
            List<Producto> listaProductos = new List<Producto>();
            try
            {
                
                using (CarritoDataContext Carrito = new CarritoDataContext())
                {
                    List<sp_ObtieneProductosPorCategoriaResult> list = Carrito.sp_ObtieneProductosPorCategoria(IdCategoria).ToList();


                    foreach (var item in list)
                    {
                        Producto objProducto = new Producto();
                        objProducto.IdProducto = item.IdProducto;
                        objProducto.NombreProducto = item.NombreProducto;
                        objProducto.PrecioProducto = item.PrecioProducto;
                        objProducto.DescripcionProducto = item.DescripcionProducto;
                        objProducto.IdCategoria = item.IdCategoria;
                        objProducto.ImagenProducto = item.ImagenProducto;

                        listaProductos.Add(objProducto);
                    }
                    return listaProductos;
                }
            }

            catch (Exception ex)
            {
                GuardaErrores ErroresLog = new GuardaErrores();
                string NombreMetodo = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErroresLog.InsertarErrores(NombreMetodo, "AccesoDatosProducto", ex.Message, ex.StackTrace);
                return listaProductos;
            }
        }
    }
}
