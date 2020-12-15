using Capa.AccesoDatos.AccesoFactura;
using Capa.Entidades;
using Capa.Utilidades.GuardaErrores;
using System;
using System.Collections.Generic;
using Capa.AccesoDatos.AccesoDatosCarrito;
using Capa.AccesoDatos.SQLLinqCarritoCompras;
using System.Net.Mail;
using System.Configuration;
using System.Net.Configuration;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using Capa.AccesoDatos.AccesoDatosCliente;

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

        /// <summary>
        /// Obtiene las facturas del cliente
        /// </summary>
        /// <param name="IdCliente"></param>
        /// <returns></returns>
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

        public sp_ObtieneFacturaIdResult ObtenerFacturaCliente(int IdFactura)
        {
            sp_ObtieneFacturaIdResult factura = new sp_ObtieneFacturaIdResult();
            try
            {
                AccesoDatosFactura accionesFactura = new AccesoDatosFactura();
                factura = accionesFactura.ObtieneFactura(IdFactura);
                return factura;
            }
            catch (Exception ex)
            {
                GuardaErrores ErroresLog = new GuardaErrores();
                string NombreMetodo = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErroresLog.InsertarErrores(NombreMetodo, "LogicaFactura", ex.Message, ex.StackTrace);
                return factura;
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
            bool insertarItemsFactura = accionesFactura.InsertarItemsFactura(objCarrito, consecutivoFactura);

            List<Entidades.Cliente> objDatoosCliente = new List<Entidades.Cliente>();
            AccesoDatosCliente ClienteDatos = new AccesoDatosCliente();
            objDatoosCliente = ClienteDatos.ObtenerDatosCliente(IdCliente);

            EnviaFactura(objDatoosCliente[0].Email, objCarrito, total);

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

        /// <summary>
        /// Calcula el total de la factura
        /// </summary>
        /// <param name="Carrito"></param>
        /// <returns></returns>
        private decimal calcularTotalFactura(List<Capa.Entidades.Carrito> Carrito)
        {
            decimal total = 0;
            foreach (var item in Carrito)
            {
                total = (decimal)(total + (item.PrecioProducto * item.Cantidad));
            }
            return total;
        }

        public bool EnviaFactura(string correodestino, List<Capa.Entidades.Carrito> objCarrito, decimal monto)
        {
            try
            {
                MailMessage correo = new MailMessage();
                correo.From = new MailAddress("comprasprogra4@gmail.com", "Comprasenlinea.com", System.Text.Encoding.UTF8);//Correo de salida
                correo.To.Add(correodestino); //Correo destino?
                correo.Subject = "Compra Realizada"; //Asunto
                List<Entidades.Carrito> listaMetodosPago = new List<Entidades.Carrito>();
                string[] Producto;
                foreach (var item in objCarrito)
                {
                    Entidades.Carrito test = new Entidades.Carrito();

                    test.NombreProducto = item.NombreProducto;

                    listaMetodosPago.Add(test);
                }

                correo.Body = "Su compra se realizo exitosamente " + "y el monto total de su compra fue: " + monto;
                correo.IsBodyHtml = true;
                correo.Priority = MailPriority.Normal;
                SmtpClient smtp = new SmtpClient();
                smtp.UseDefaultCredentials = false;
                smtp.Host = "smtp.gmail.com"; //Host del servidor de correo
                smtp.Port = 587; //Puerto de salida
                smtp.Credentials = new System.Net.NetworkCredential("comprasprogra4@gmail.com", "ArturoPrograma4");//Cuenta de correo
                ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
                smtp.EnableSsl = true;//True si el servidor de correo permite ssl
                smtp.Send(correo);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
