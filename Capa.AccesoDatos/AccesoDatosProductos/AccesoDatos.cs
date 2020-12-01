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
        ///
        ///

        private List<Producto> listaProductos = new List<Producto>();
        public List<Producto> ObtenerProductos()
        {
            try
            {
                Producto objProducto = new Producto();
                using (CarritoDataContext Carrito = new CarritoDataContext())
                {
                     List<sp_ObtieneProductosResult> list = Carrito.sp_ObtieneProductos().ToList();


                     foreach (var item in list)
                     {

                         objProducto.IdProducto = item.IdProducto;
                         objProducto.NombreProducto  = item.NombreProducto;
                         objProducto.PrecioProducto  = item.PrecioProducto;
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
                return null;
            }
        }

        /// <summary>
        /// Obtiene la todos los productos por categoria
        /// </summary>
        /// <param name="IdCategoria"></param>
        /// <returns></returns>
        public Producto ObtenerProductosXCategoria(int IdCategoria)
        {
            try
            {
                Producto objProducto = new Producto();
                using (CarritoDataContext Carrito = new CarritoDataContext())
                {
                    var list = Carrito.sp_ObtieneProductosPorCategoria(IdCategoria).ToList().FirstOrDefault();

                    objProducto.IdProducto = list.IdProducto;
                    objProducto.NombreProducto = list.NombreProducto;
                    objProducto.DescripcionProducto = list.DescripcionProducto;
                    objProducto.PrecioProducto = list.PrecioProducto;
                    objProducto.ImagenProducto = list.ImagenProducto;
                    objProducto.IdCategoria = list.IdCategoria;
                }

                return objProducto;
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
