using Capa.AccesoDatos.AccesoDatosCarrito;
using Capa.Utilidades.GuardaErrores;
using System;
using System.Collections.Generic;

namespace Capa.LogicaNegocio.Carrito
{
    public class CarritoLogica
    {
        /// <summary>
        /// Logica para la insercion del carrito
        /// </summary>
        /// <param name="IdUsuario"></param>
        /// <param name="IdProducto"></param>
        /// <param name="Cantidad"></param>
        /// <returns></returns>
        public int InsertarCarrito(int IdUsuario, int IdProducto, int Cantidad)
        {
            int ResultadoOperacion = 0;
            try
            {
                DatosCarrito CarritoDatos = new DatosCarrito();
                ResultadoOperacion = CarritoDatos.InsertarCarritoPorCliente(IdUsuario, IdProducto, Cantidad);
                return ResultadoOperacion;
            }
            catch (Exception ex)
            {
                GuardaErrores ErroresLog = new GuardaErrores();
                string NombreMetodo = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErroresLog.InsertarErrores(NombreMetodo, "LogicaDatosCarrito", ex.Message, ex.StackTrace);
                return ResultadoOperacion;
            }
        }


        /// <summary>
        /// Logica para actualizar el Carrito
        /// </summary>
        /// <param name="IdUsuario"></param>
        /// <param name="IdProducto"></param>
        /// <param name="Cantidad"></param>
        /// <returns></returns>
        public int ActualizarCarritoPorCliente(int IdUsuario, int IdProducto, int Cantidad)
        {
            int ResultadoOperacion = 0;
            try
            {
                DatosCarrito CarritoDatos = new DatosCarrito();
                ResultadoOperacion = CarritoDatos.ActualizarCarritoPorCliente(IdUsuario, IdProducto, Cantidad);
                return ResultadoOperacion;
            }
            catch (Exception ex)
            {
                GuardaErrores ErroresLog = new GuardaErrores();
                string NombreMetodo = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErroresLog.InsertarErrores(NombreMetodo, "LogicaDatosCarrito", ex.Message, ex.StackTrace);
                return ResultadoOperacion;
            }
        }

        /// <summary>
        /// Eliminar el carrito del cliente
        /// </summary>
        /// <param name="IdUsuario"></param>
        /// <returns></returns>
        public int EliminarCarritoPorCliente(int IdUsuario)
        {
            int ResultadoOperacion = 0;
            try
            {
                DatosCarrito CarritoDatos = new DatosCarrito();
                ResultadoOperacion = CarritoDatos.EliminarCarritoPorCliente(IdUsuario);
                return ResultadoOperacion;
            }
            catch (Exception ex)
            {
                GuardaErrores ErroresLog = new GuardaErrores();
                string NombreMetodo = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErroresLog.InsertarErrores(NombreMetodo, "LogicaDatosCarrito", ex.Message, ex.StackTrace);
                return ResultadoOperacion;
            }
        }

        public List<Capa.Entidades.Carrito> ObtenerCarritoPorCliente(int IdUsuario)
        {
            try
            {
                List<Capa.Entidades.Carrito> objCarrito = new List<Capa.Entidades.Carrito>();
                DatosCarrito CarritoDatos = new DatosCarrito();
                objCarrito = CarritoDatos.ObtenerCarritoPorCliente(IdUsuario);
                return objCarrito;
            }
            catch (Exception ex)
            {
                GuardaErrores ErroresLog = new GuardaErrores();
                string NombreMetodo = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErroresLog.InsertarErrores(NombreMetodo, "LogicaDatosCarrito", ex.Message, ex.StackTrace);
                return null;
            }
        }
    }
}
