using Capa.AccesoDatos.SQLLinqCarritoCompras;
using Capa.Entidades;
using Capa.Entidades.EnumResultados;
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
                    resultado = (int)EnumResultadoOperacion.Exito;
                    return resultado;
                }
            }
            catch (Exception ex)
            {
                GuardaErrores ErroresLog = new GuardaErrores();
                string NombreMetodo = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErroresLog.InsertarErrores(NombreMetodo, "DatosCarrito", ex.Message, ex.StackTrace);
                return (int)EnumResultadoOperacion.Error;
            }
        }

        /// <summary>
        /// Actualiza los datos del carrito por cliente
        /// </summary>
        /// <param name="IdCarrito"></param>
        /// <param name="IdProducto"></param>
        /// <param name="Cantidad"></param>
        /// <returns></returns>
        public int ActualizarCarritoPorCliente(int IdCarrito, int IdProducto, int Cantidad)
        {

            int resultado = 0;
            try
            {
                using (CarritoDataContext CarritoBD = new CarritoDataContext())
                {
                    CarritoBD.sp_ActualizarCarritoPorCliente(IdCarrito, IdProducto, Cantidad);
                    resultado = (int)EnumResultadoOperacion.Exito;
                    return resultado;
                }
            }
            catch (Exception ex)
            {
                GuardaErrores ErroresLog = new GuardaErrores();
                string NombreMetodo = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErroresLog.InsertarErrores(NombreMetodo, "DatosCarrito", ex.Message, ex.StackTrace);
                return resultado = (int)EnumResultadoOperacion.Error;
            }
        }

        /// <summary>
        /// Elimina el carrito por cliente
        /// </summary>
        /// <param name="IDCarrito"></param>
        /// <returns></returns>
        public int EliminarCarritoPorCliente(int IDCarrito)
        {

            int resultado = 0;
            try
            {
                using (CarritoDataContext CarritoBD = new CarritoDataContext())
                {
                    CarritoBD.sp_EliminarCarritoPorCliente(IDCarrito);
                    resultado = (int)EnumResultadoOperacion.Exito;
                    return resultado;
                }
            }
            catch (Exception ex)
            {
                GuardaErrores ErroresLog = new GuardaErrores();
                string NombreMetodo = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErroresLog.InsertarErrores(NombreMetodo, "DatosCarrito", ex.Message, ex.StackTrace);
                return resultado = (int)EnumResultadoOperacion.Error;
            }
        }

        /// <summary>
        /// Obtiene el carrito por cliente
        /// </summary>
        /// <param name="IdUsuario"></param>
        /// <returns></returns>
        public List<Carrito> ObtenerCarritoPorCliente(int IdUsuario)
        {

            List<Carrito> listaCarrito = new List<Carrito>();
            try
            {

                using (CarritoDataContext CarritoBD = new CarritoDataContext())
                {
                    List<sp_ObtieneCarritoPorClienteResult> list = CarritoBD.sp_ObtieneCarritoPorCliente(IdUsuario).ToList();


                    foreach (var item in list)
                    {
                        Carrito objCarrito = new Carrito();
                        objCarrito.IdCarrito = item.IdCarrito;
                        objCarrito.IdUsuario = item.IdCliente;
                        objCarrito.NombreCliente = item.Nombre;
                        objCarrito.ApellidoCliente = item.Apellido;
                        objCarrito.IdProducto = item.IdProducto;
                        objCarrito.NombreProducto = item.NombreProducto;
                        objCarrito.ImagenProducto = item.ImagenProducto;
                        objCarrito.DescripcionProducto = item.DescripcionProducto;
                        objCarrito.IdCategoria = item.IdCategoria;
                        objCarrito.Cantidad = item.Cantidad;
                        objCarrito.CantidadDisponible = item.CantidadDisponibles;
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