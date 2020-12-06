using Capa.AccesoDatos.AccesoDatosCliente;
using Capa.Utilidades.GuardaErrores;
using System;
using System.Collections.Generic;

namespace Capa.LogicaNegocio.Cliente
{

    public class ClienteLogica
    {
        /// <summary>
        /// Obtiene los datos de los clientes
        /// </summary>
        /// <param name="IdCliente"></param>
        /// <returns></returns>
        public List<Entidades.Cliente> ObtenerClientePorIdCliente(int IdCliente)
        {
            try
            {
                List<Entidades.Cliente> objCarrito = new List<Entidades.Cliente>();
                AccesoDatosCliente CarritoDatos = new AccesoDatosCliente();
                objCarrito = CarritoDatos.ObtenerDatosCliente(IdCliente);
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

        /// <summary>
        /// Inserta los datos del cliente 
        /// </summary>
        /// <param name="objCliente"></param>
        /// <returns></returns>
        public int InsertarDatosCliente(Entidades.Cliente objCliente)
        {
            int resultado = 0;
            try
            {
                List<Entidades.Cliente> objCarrito = new List<Entidades.Cliente>();
                AccesoDatosCliente CarritoDatos = new AccesoDatosCliente();
                resultado = CarritoDatos.InsertarDatosCliente(objCliente);
                return resultado;
            }
            catch (Exception ex)
            {
                GuardaErrores ErroresLog = new GuardaErrores();
                string NombreMetodo = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErroresLog.InsertarErrores(NombreMetodo, "LogicaDatosCarrito", ex.Message, ex.StackTrace);
                return resultado;
            }
        }

        /// <summary>
        /// Actualiza los datos del cliente 
        /// </summary>
        /// <param name="objCliente"></param>
        /// <returns></returns>
        public int ActualizarDatosCliente(Entidades.Cliente objCliente)
        {
            int resultado = 0;
            try
            {
                List<Entidades.Cliente> objCarrito = new List<Entidades.Cliente>();
                AccesoDatosCliente CarritoDatos = new AccesoDatosCliente();
                resultado = CarritoDatos.InsertarDatosCliente(objCliente);
                return resultado;
            }
            catch (Exception ex)
            {
                GuardaErrores ErroresLog = new GuardaErrores();
                string NombreMetodo = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErroresLog.InsertarErrores(NombreMetodo, "LogicaDatosCarrito", ex.Message, ex.StackTrace);
                return resultado;
            }
        }
    }
}
