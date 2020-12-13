using Capa.AccesoDatos.AccesoFactura;
using Capa.Entidades;
using Capa.Utilidades.GuardaErrores;
using System;
using System.Collections.Generic;

namespace Capa.LogicaNegocio.Factura
{
    public class LogicaFactura
    {
        /// <summary>
        /// Obtiene los metodos de pago
        /// </summary>
        /// <returns></returns>
        public List<MetodoPago> ObtenerMetodoPago()
        {
            List<MetodoPago> objMetodoPago = new List<MetodoPago>();
            try
            {
                AccesoDatosFactura MetodoPagoDatos = new AccesoDatosFactura();
                objMetodoPago = MetodoPagoDatos.ObtieneMetodosPago();
                return objMetodoPago;
            }
            catch (Exception ex)
            {
                GuardaErrores ErroresLog = new GuardaErrores();
                string NombreMetodo = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErroresLog.InsertarErrores(NombreMetodo, "LogicaFactura", ex.Message, ex.StackTrace);
                return objMetodoPago;
            }
        }
    }
}
