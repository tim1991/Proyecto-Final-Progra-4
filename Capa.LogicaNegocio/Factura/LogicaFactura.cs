using Capa.AccesoDatos.AccesoFactura;
using Capa.Entidades;
using Capa.Utilidades.GuardaErrores;
using System;
using System.Collections.Generic;
using Capa.AccesoDatos.AccesoDatosCarrito;
using Capa.AccesoDatos.SQLLinqCarritoCompras;

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
        public List<sp_ObtieneFacturasClienteResult> ObtenerFacturasCliente(int IdCliente)
        {
            List<sp_ObtieneFacturasClienteResult> facturasLista = new List<sp_ObtieneFacturasClienteResult>();
            try
            {
                AccesoDatosFactura accionesFactura = new AccesoDatosFactura();
                facturasLista = accionesFactura.ObtieneFacturasCliente(IdCliente);
                return facturasLista;
            }
            catch (Exception ex)
            {
                GuardaErrores ErroresLog = new GuardaErrores();
                string NombreMetodo = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErroresLog.InsertarErrores(NombreMetodo, "LogicaFactura", ex.Message, ex.StackTrace);
                return facturasLista;
            }
        }

        public Boolean CrearFactura(int IdCliente)
        {
            DatosCarrito CarritoDatos = new DatosCarrito();
            List<Capa.Entidades.Carrito> objCarrito = new List<Capa.Entidades.Carrito>();
            objCarrito = CarritoDatos.ObtenerCarritoPorCliente(IdCliente);
            AccesoDatosFactura accionesFactura = new AccesoDatosFactura();

            decimal total = calcularTotalFactura(objCarrito);
            int consecutivoFactura = accionesFactura.CrearFactura(IdCliente, total);
            bool insertarItemsFactura = accionesFactura.InsertarItemsFactura(objCarrito,consecutivoFactura);

            if (insertarItemsFactura)
            {
                accionesFactura.VaciarCarrito(IdCliente);
                return true;
            }
            else
            {
                return false;
            }
            
        }

        private decimal calcularTotalFactura(List<Capa.Entidades.Carrito> Carrito)
        {
            decimal total = 0;
            foreach (var item in Carrito)
            {
                total = (decimal) (total + (item.PrecioProducto * item.Cantidad));
            }
            return total;
        }
    }
}
