using Capa.AccesoDatos.SQLLinqCarritoCompras;
using Capa.Entidades;
using Capa.Utilidades.GuardaErrores;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Capa.AccesoDatos.AccesoFactura
{
    public class AccesoDatosFactura
    {
        /// <summary>
        /// Obtiene los metodos de pago
        /// </summary>
        /// <returns></returns>
        public List<MetodoPago> ObtieneMetodosPago()
        {
            List<MetodoPago> listaMetodosPago = new List<MetodoPago>();
            try
            {
                using (CarritoDataContext MetodoPagoDB = new CarritoDataContext())
                {
                    List<sp_ObtieneMetodosPagoResult> list = MetodoPagoDB.sp_ObtieneMetodosPago().ToList();

                    foreach (var item in list)
                    {
                        MetodoPago objCarrito = new MetodoPago();
                        objCarrito.IdMetodoPago = item.IdMetodoPago;
                        objCarrito.NombreMetodoPAgo = item.NombreMetodoPAgo;

                        listaMetodosPago.Add(objCarrito);
                    }
                    return listaMetodosPago;
                }
            }
            catch (Exception ex)
            {
                GuardaErrores ErroresLog = new GuardaErrores();
                string NombreMetodo = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErroresLog.InsertarErrores(NombreMetodo, "DatosFactura", ex.Message, ex.StackTrace);
                return listaMetodosPago;
            }
        }

        //public int InsertarOrden 
    }
}
