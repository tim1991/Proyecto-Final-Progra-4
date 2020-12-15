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
                    //List<sp_ObtieneMetodosPagoResult> list = MetodoPagoDB.sp_ObtieneMetodosPago().ToList();

                    //foreach (var item in list)
                    //{
                    //    MetodoPago objCarrito = new MetodoPago();
                    //    objCarrito.IdMetodoPago = item.IdMetodoPago;
                    //    objCarrito.NombreMetodoPAgo = item.NombreMetodoPAgo;

                    //    listaMetodosPago.Add(objCarrito);
                    //}
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

        public int CrearFactura(int IdCliente, decimal total)
        {

            try
            {
                using (CarritoDataContext FacturaDB = new CarritoDataContext())
                {

                    DateTime fechaFactura = DateTime.Now;
                    sp_CrearFacturaResult factura = FacturaDB.sp_CrearFactura(IdCliente, fechaFactura, total).FirstOrDefault();
                    return (int)factura.ID;
                }
            }
            catch (Exception ex)
            {
                GuardaErrores ErroresLog = new GuardaErrores();
                string NombreMetodo = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErroresLog.InsertarErrores(NombreMetodo, "DatosFactura", ex.Message, ex.StackTrace);
                return 0;
            }


        }

        public List<sp_ObtieneFacturasClienteResult> ObtieneFacturasCliente(int IdCliente)
        {
            List<sp_ObtieneFacturasClienteResult> listaFacturas = null;
            try
            {
                using (CarritoDataContext FacturaDB = new CarritoDataContext())
                {

                    listaFacturas = FacturaDB.sp_ObtieneFacturasCliente(IdCliente).ToList();
                    return (listaFacturas);
                }
            }
            catch (Exception ex)
            {
                GuardaErrores ErroresLog = new GuardaErrores();
                string NombreMetodo = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErroresLog.InsertarErrores(NombreMetodo, "DatosFactura", ex.Message, ex.StackTrace);
                return listaFacturas;
            }


        } 
        
        public sp_ObtieneFacturaIdResult ObtieneFactura(int IdFactura)
        {
            sp_ObtieneFacturaIdResult factura = null;
            try
            {
                using (CarritoDataContext FacturaDB = new CarritoDataContext())
                {

                    factura = FacturaDB.sp_ObtieneFacturaId(IdFactura).FirstOrDefault();
                    return (factura);
                }
            }
            catch (Exception ex)
            {
                GuardaErrores ErroresLog = new GuardaErrores();
                string NombreMetodo = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErroresLog.InsertarErrores(NombreMetodo, "DatosFactura", ex.Message, ex.StackTrace);
                return factura;
            }


        }

        public bool VaciarCarrito(int IdCliente)
        {
            try
            {
                using (CarritoDataContext FacturaDB = new CarritoDataContext())
                {
                   
                        FacturaDB.sp_VaciarCarrito(IdCliente);
                    
                    return true;

                }
            }
            catch (Exception ex)
            {
                GuardaErrores ErroresLog = new GuardaErrores();
                string NombreMetodo = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErroresLog.InsertarErrores(NombreMetodo, "DatosFactura", ex.Message, ex.StackTrace);
                return false;
            }
        }

        public bool InsertarItemsFactura(List<Carrito> Carrito,int IdFactura)
        {

            try
            {
                using (CarritoDataContext FacturaDB = new CarritoDataContext())
                {

                    foreach (var item in Carrito)
                    {
                        decimal subTotal = 0;
                        subTotal = (decimal)(subTotal + (item.PrecioProducto * item.Cantidad));
                        FacturaDB.sp_AgregarItemsFactura(item.IdProducto, IdFactura,item.Cantidad, subTotal);
                    }
                    return true;

                }
            }
            catch (Exception ex)
            {
                GuardaErrores ErroresLog = new GuardaErrores();
                string NombreMetodo = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErroresLog.InsertarErrores(NombreMetodo, "DatosFactura", ex.Message, ex.StackTrace);
                return false;
            }


        }
    }
}
