using Capa.AccesoDatos.SQLLinqCarritoCompras;
using Capa.Utilidades.GuardaErrores;
using System;

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
                    resultado = CarritoBD.sp_InsertarCarritoPorCliente(IdUsuario, IdProducto, Cantidad);
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
                    resultado = CarritoBD.sp_ActualizarCarritoPorCliente(IdUsuario, IdProducto, Cantidad);
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
    }
}
