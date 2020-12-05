using Capa.AccesoDatos.AccesoDatosCarrito;
using Capa.Utilidades.GuardaErrores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                ErroresLog.InsertarErrores(NombreMetodo, "AccesoDatosProducto", ex.Message, ex.StackTrace);
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
        public int ActualizarCarrito(int IdUsuario, int IdProducto, int Cantidad)
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
                ErroresLog.InsertarErrores(NombreMetodo, "AccesoDatosProducto", ex.Message, ex.StackTrace);
                return ResultadoOperacion;
            }
        }
    }
}
