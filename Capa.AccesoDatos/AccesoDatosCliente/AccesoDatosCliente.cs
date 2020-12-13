using Capa.AccesoDatos.SQLLinqCarritoCompras;
using Capa.Entidades;
using Capa.Utilidades.GuardaErrores;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Capa.AccesoDatos.AccesoDatosCliente
{
    public class AccesoDatosCliente
    {
        /// <summary>
        /// Obtiene los datos cliente por su ID
        /// </summary>
        /// <param name="IdCliente"></param>
        /// <returns></returns>
        ///
        public Cliente Login(string Email, string Contrasena)
        {
            Cliente cliente = new Cliente();
            try
            {

                using (CarritoDataContext CarritoBD = new CarritoDataContext())
                {
                    sp_LoginClienteResult result = CarritoBD.sp_LoginCliente(Email,Contrasena).FirstOrDefault();

                    cliente.IdCliente = result.IdCliente;
                    cliente.Nombre = result.Nombre;
                    cliente.Apellido = result.Apellido;
                    cliente.Email = result.Email;
                    cliente.Telefono = result.Telefono;
                    return cliente;
                }
            }
            catch (Exception ex)
            {
                GuardaErrores ErroresLog = new GuardaErrores();
                string NombreMetodo = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErroresLog.InsertarErrores(NombreMetodo, "DatosCliente", ex.Message, ex.StackTrace);
                return cliente;
            }
        }
        public List<Cliente> ObtenerDatosCliente(int IdCliente)
        {

            List<Cliente> listaCarrito = new List<Cliente>();
            try
            {

                using (CarritoDataContext CarritoBD = new CarritoDataContext())
                {
                    List<sp_ObtieneDatosClientePorClienteResult> list = CarritoBD.sp_ObtieneDatosClientePorCliente(IdCliente).ToList();

                    foreach (var item in list)
                    {
                        Cliente objCarrito = new Cliente();
                        objCarrito.IdCliente = item.IdCliente;
                        objCarrito.Nombre = item.Nombre;
                        objCarrito.Email = item.Email;
                        objCarrito.Apellido = item.Apellido;
                        objCarrito.Telefono = item.Telefono;
                        objCarrito.Direccion = item.Direccion;
                        objCarrito.Contrasena = item.Contrasena;


                        listaCarrito.Add(objCarrito);
                    }
                    return listaCarrito;
                }
            }
            catch (Exception ex)
            {
                GuardaErrores ErroresLog = new GuardaErrores();
                string NombreMetodo = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErroresLog.InsertarErrores(NombreMetodo, "DatosCliente", ex.Message, ex.StackTrace);
                return listaCarrito;
            }
        }

        /// <summary>
        /// Inserta los datos del cliente
        /// </summary>
        /// <param name="objCliente"></param>
        /// <returns></returns>
        public int InsertarDatosCliente(Cliente objCliente)
        {

            int resultado = 0;
            try
            {
                using (CarritoDataContext CarritoBD = new CarritoDataContext())
                {
                    CarritoBD.sp_InsertarDatosCliente(objCliente.Nombre, objCliente.Apellido, objCliente.Email, objCliente.Telefono, objCliente.Direccion, objCliente.Contrasena);
                    resultado = 1;
                    return resultado;
                }
            }
            catch (Exception ex)
            {
                GuardaErrores ErroresLog = new GuardaErrores();
                string NombreMetodo = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErroresLog.InsertarErrores(NombreMetodo, "DatosCliente", ex.Message, ex.StackTrace);
                return resultado;
            }
        }

        /// <summary>
        /// Actualiza los datos del cliente
        /// </summary>
        /// <param name="objCliente"></param>
        /// <returns></returns>
        public int ActualizarDatosCliente(Cliente objCliente)
        {

            int resultado = 0;
            try
            {
                using (CarritoDataContext CarritoBD = new CarritoDataContext())
                {
                    CarritoBD.sp_ActualizarDatosCliente(objCliente.IdCliente, objCliente.Nombre, objCliente.Apellido, objCliente.Email, objCliente.Telefono, objCliente.Direccion, objCliente.Contrasena);
                    resultado = 1;
                    return resultado;
                }
            }
            catch (Exception ex)
            {
                GuardaErrores ErroresLog = new GuardaErrores();
                string NombreMetodo = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErroresLog.InsertarErrores(NombreMetodo, "DatosCliente", ex.Message, ex.StackTrace);
                return resultado;
            }
        }
    }
}
