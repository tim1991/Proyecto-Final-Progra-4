using Capa.AccesoDatos.AccesoDatosCarrito;
using Capa.Entidades.EnumResultados;
using Capa.Utilidades.GuardaErrores;
using System;
using System.Collections.Generic;
using System.Linq;

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
        public int InsertarCarrito(int IdUsuario, int IdProducto, int Cantidad, int IdCarrito)
        {
            int ResultadoOperacion = 0;
            try
            {
                DatosCarrito CarritoDatos = new DatosCarrito();
                List<Capa.Entidades.Carrito> objCarrito = new List<Capa.Entidades.Carrito>();
                objCarrito = CarritoDatos.ObtenerCarritoPorCliente(IdUsuario);
                Capa.AccesoDatos.AccesoDatos Producto = new Capa.AccesoDatos.AccesoDatos();


                int CantidadDisponible = Producto.ObtieneCantidadProductos(IdProducto);


                var item = objCarrito.FirstOrDefault(i => i.IdProducto == IdProducto);

                if (CantidadDisponible > Cantidad)
                {
                    if (objCarrito.Count != 0)
                    {
                        if (item != null)
                        {
                            if (item.IdProducto == IdProducto)
                            {
                                int nuevaCantidad = (int)(item.Cantidad + Cantidad);
                                CarritoDatos.ActualizarCarritoPorCliente(item.IdCarrito, IdProducto, nuevaCantidad);
                                ResultadoOperacion = (int)EnumResultadoOperacion.Exito;
                            }
                            

                        }
                        else
                        {
                            ResultadoOperacion = CarritoDatos.InsertarCarritoPorCliente(IdUsuario, IdProducto, Cantidad);
                            ResultadoOperacion = (int)EnumResultadoOperacion.Exito;
                        }

                    }
                    else
                    {
                        ResultadoOperacion = CarritoDatos.InsertarCarritoPorCliente(IdUsuario, IdProducto, Cantidad);
                        ResultadoOperacion = (int)EnumResultadoOperacion.Exito;
                    }
                    
                }
                else
                {
                    return (int)EnumResultadoOperacion.NoDisponibles;
                }

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
        /// <param name="IdCarrito"></param>
        /// <param name="IdProducto"></param>
        /// <param name="Cantidad"></param>
        /// <returns></returns>
        public int ActualizarCarritoPorCliente(int IdCarrito, int IdProducto, int Cantidad)
        {
            int ResultadoOperacion = 0;
            try
            {
                DatosCarrito CarritoDatos = new DatosCarrito();
                ResultadoOperacion = CarritoDatos.ActualizarCarritoPorCliente(IdCarrito, IdProducto, Cantidad);
                return (int)EnumResultadoOperacion.Exito;
            }
            catch (Exception ex)
            {
                GuardaErrores ErroresLog = new GuardaErrores();
                string NombreMetodo = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErroresLog.InsertarErrores(NombreMetodo, "LogicaDatosCarrito", ex.Message, ex.StackTrace);
                return (int)EnumResultadoOperacion.Error;
            }
        }

        /// <summary>
        /// Eliminar el carrito del cliente
        /// </summary>
        /// <param name="IdCarrito"></param>
        /// <returns></returns>
        public int EliminarCarritoPorCliente(int IdCarrito)
        {
            int ResultadoOperacion = 0;
            try
            {
                DatosCarrito CarritoDatos = new DatosCarrito();
                ResultadoOperacion = CarritoDatos.EliminarCarritoPorCliente(IdCarrito);
                return (int)EnumResultadoOperacion.Exito;
            }
            catch (Exception ex)
            {
                GuardaErrores ErroresLog = new GuardaErrores();
                string NombreMetodo = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErroresLog.InsertarErrores(NombreMetodo, "LogicaDatosCarrito", ex.Message, ex.StackTrace);
                return (int)EnumResultadoOperacion.Error;
            }
        }

        public List<Capa.Entidades.Carrito> ObtenerCarritoPorCliente(int IdUsuario)
        {
            List<Capa.Entidades.Carrito> objCarrito = new List<Capa.Entidades.Carrito>();
            try
            {
                DatosCarrito CarritoDatos = new DatosCarrito();
                objCarrito = CarritoDatos.ObtenerCarritoPorCliente(IdUsuario);
                return objCarrito;
            }
            catch (Exception ex)
            {
                GuardaErrores ErroresLog = new GuardaErrores();
                string NombreMetodo = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErroresLog.InsertarErrores(NombreMetodo, "LogicaDatosCarrito", ex.Message, ex.StackTrace);
                return objCarrito;
            }
        }
    }
}
