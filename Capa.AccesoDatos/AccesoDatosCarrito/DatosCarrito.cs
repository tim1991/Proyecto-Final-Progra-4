using Capa.AccesoDatos.SQLLinqCarritoCompras;
using Capa.Entidades;
using Capa.Utilidades.GuardaErrores;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Capa.AccesoDatos.AccesoDatosCarrito
{
    public class DatosCarrito
    {
        /// <summary>
        /// Inserta el carrito por Cliente
        /// </summary>
        /// <param name="IdUsuario"></param>
        /// <param name="IdProducto"></param>
        /// <param name="Cantidad"></param>
        /// <returns></returns>
        public int InsertarCarritoPorCliente(int IdUsuario, int IdProducto, int Cantidad)
        {

            int resultado = 0;
            try
            {
                using (CarritoDataContext CarritoBD = new CarritoDataContext())
                {
                    CarritoBD.sp_InsertarCarritoPorCliente(IdUsuario, IdProducto, Cantidad);
                    resultado = 1;
                    return resultado;
                }
            }
            catch (Exception ex)
            {
                GuardaErrores ErroresLog = new GuardaErrores();
                string NombreMetodo = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErroresLog.InsertarErrores(NombreMetodo, "DatosCarrito", ex.Message, ex.StackTrace);
                return resultado;
            }
        }

        /// <summary>
        /// Actualiza los datos del carrito por cliente
        /// </summary>
        /// <param name="IdUsuario"></param>
        /// <param name="IdProducto"></param>
        /// <param name="Cantidad"></param>
        /// <returns></returns>
        public int ActualizarCarritoPorCliente(int IdUsuario, int IdProducto, int Cantidad)
        {

            int resultado = 0;
            try
            {
                using (CarritoDataContext CarritoBD = new CarritoDataContext())
                {
                    CarritoBD.sp_ActualizarCarritoPorCliente(IdUsuario, IdProducto, Cantidad);
                    resultado = 1;
                    return resultado;
                }
            }
            catch (Exception ex)
            {
                GuardaErrores ErroresLog = new GuardaErrores();
                string NombreMetodo = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErroresLog.InsertarErrores(NombreMetodo, "DatosCarrito", ex.Message, ex.StackTrace);
                return resultado;
            }
        }

        /// <summary>
        /// Elimina el carrito por cliente
        /// </summary>
        /// <param name="IdUsuario"></param>
        /// <returns></returns>
        public int EliminarCarritoPorCliente(int IdUsuario)
        {

            int resultado = 0;
            try
            {
                using (CarritoDataContext CarritoBD = new CarritoDataContext())
                {
                    CarritoBD.sp_EliminarCarritoPorCliente(IdUsuario);
                    resultado = 1;
                    return resultado;
                }
            }
            catch (Exception ex)
            {
                GuardaErrores ErroresLog = new GuardaErrores();
                string NombreMetodo = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErroresLog.InsertarErrores(NombreMetodo, "DatosCarrito", ex.Message, ex.StackTrace);
                return resultado;
            }
        }

        /// <summary>
        /// Obtiene el carrito por cliente
        /// </summary>
        /// <param name="IdUsuario"></param>
        /// <returns></returns>
        public List<Carrito> ObtenerCarritoPorCliente(int IdUsuario)
        {
            Carrito objCarrito = new Carrito();
            List<Carrito> listaCarrito = new List<Carrito>();
            try
            {

                using (CarritoDataContext CarritoBD = new CarritoDataContext())
                {
                    List<sp_ObtieneCarritoPorClienteResult> list = CarritoBD.sp_ObtieneCarritoPorCliente(IdUsuario).ToList();


                    foreach (var item in list)
                    {
                        objCarrito.IdUsuario = item.IdCliente;
                        objCarrito.NombreCliente = item.Nombre;
                        objCarrito.ApellidoCliente = item.Apellido;
                        objCarrito.IdProducto = item.IdProducto;
                        objCarrito.NombreProducto = item.NombreProducto;
                        objCarrito.ImagenProducto = item.ImagenProducto;
                        objCarrito.DescripcionProducto = item.DescripcionProducto;
                        objCarrito.IdCategoria = item.IdCategoria;
                        objCarrito.PrecioProducto = item.PrecioProducto;

                        listaCarrito.Add(objCarrito);
                    }
                    return listaCarrito;
                }
            }
            catch (Exception ex)
            {
                GuardaErrores ErroresLog = new GuardaErrores();
                string NombreMetodo = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErroresLog.InsertarErrores(NombreMetodo, "DatosCarrito", ex.Message, ex.StackTrace);
                return listaCarrito;
            }
        }
    }
}
