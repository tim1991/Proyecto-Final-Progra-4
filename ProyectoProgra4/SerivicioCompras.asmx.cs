using Capa.LogicaNegocio.Productos;
using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;
using Capa.Entidades;
using Capa.LogicaNegocio.Carrito;

namespace ProyectoProgra4
{
    /// <summary>
    /// Summary description for SerivicioCompras
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class SerivicioCompras : System.Web.Services.WebService
    {
        #region Productos

        /// <summary>
        /// Obtiene los datos del producto por categoria
        /// </summary>
        /// <param name="IdCategoria"></param>
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void ObtieneProductosXCategoria(int IdCategoria)
        {
            try
            {
                JavaScriptSerializer JSSDatos = new JavaScriptSerializer();
                ProductosLogica ObtieneProductos = new ProductosLogica();
                string JSONRespuesta = String.Empty;
                var Respuesta = ObtieneProductos.ObtieneProductosXCategoria(IdCategoria);
                JSONRespuesta = JSSDatos.Serialize(Respuesta);
                Context.Response.Write(JSONRespuesta);
            }
            catch (Exception)
            {
                Context.Response.Write("Un error ha ocurrido por favor verifique los datos");
            }
        }

        /// <summary>
        /// Obtiene los datos del producto
        /// </summary>
        /// <param name="IdProducto"></param>
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void ObtieneProductos()
        {
            try
            {

                JavaScriptSerializer js = new JavaScriptSerializer();
                Context.Response.Clear();
                Context.Response.ContentType = "application/json";
                ProductosLogica ObtieneProductos = new ProductosLogica();
                List<Producto> Respuesta = ObtieneProductos.ObtieneProductos();
                Context.Response.Write(js.Serialize(Respuesta));

            }
            catch (Exception)
            {
                Context.Response.Write("Un error ha ocurrido por favor verifique los datos");
            }
        }

        #endregion Productos

        #region Carrito

        /// <summary>
        /// Obtiene el carrito por cliente
        /// </summary>
        /// <param name="IdCliente"></param>
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void ObtenerCarritoPorCliente(int IdCliente)
        {
            try
            {

                JavaScriptSerializer js = new JavaScriptSerializer();
                Context.Response.Clear();
                Context.Response.ContentType = "application/json";
                CarritoLogica ObtieneCarrito = new CarritoLogica();
                List<Carrito> Respuesta = ObtieneCarrito.ObtenerCarritoPorCliente(IdCliente);
                Context.Response.Write(js.Serialize(Respuesta));

            }
            catch (Exception)
            {
                Context.Response.Write("Un error ha ocurrido por favor verifique los datos");
            }
        }


        /// <summary>
        /// Actualizar Carrito por cliente
        /// </summary>
        /// <param name="IdCliente"></param>
        /// <param name="IdProducto"></param>
        /// <param name="Cantidad"></param>
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void ActualizarCarritoPorCliente(int IdCliente, int IdProducto, int Cantidad)
        {
            try
            {

                JavaScriptSerializer js = new JavaScriptSerializer();
                Context.Response.Clear();
                Context.Response.ContentType = "application/json";
                CarritoLogica ObtieneCarrito = new CarritoLogica();
                int Respuesta = ObtieneCarrito.ActualizarCarritoPorCliente(IdCliente, IdProducto, Cantidad);
                Context.Response.Write(js.Serialize(Respuesta));

            }
            catch (Exception)
            {
                Context.Response.Write("Un error ha ocurrido por favor verifique los datos");
            }
        }

        /// <summary>
        /// Elimina el carrito por cliente
        /// </summary>
        /// <param name="IdCliente"></param>
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void EliminarCarritoPorCliente(int IdCliente)
        {
            try
            {

                JavaScriptSerializer js = new JavaScriptSerializer();
                Context.Response.Clear();
                Context.Response.ContentType = "application/json";
                CarritoLogica ObtieneCarrito = new CarritoLogica();
                int Respuesta = ObtieneCarrito.EliminarCarritoPorCliente(IdCliente);
                Context.Response.Write(js.Serialize(Respuesta));

            }
            catch (Exception)
            {
                Context.Response.Write("Un error ha ocurrido por favor verifique los datos");
            }
        }

        /// <summary>
        /// Inserta el carrito por cliente
        /// </summary>
        /// <param name="IdCliente"></param>
        /// <param name="IdProducto"></param>
        /// <param name="Cantidad"></param>
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void InsertarCarritoPorCliente(int IdCliente, int IdProducto, int Cantidad)
        {
            try
            {

                JavaScriptSerializer js = new JavaScriptSerializer();
                Context.Response.Clear();
                Context.Response.ContentType = "application/json";
                CarritoLogica ObtieneCarrito = new CarritoLogica();
                int Respuesta = ObtieneCarrito.InsertarCarrito(IdCliente, IdProducto, Cantidad);
                Context.Response.Write(js.Serialize(Respuesta));

            }
            catch (Exception)
            {
                Context.Response.Write("Un error ha ocurrido por favor verifique los datos");
            }
        }

        #endregion Carrito

        #region Usuarios
        
        #endregion Usuarios


    }
}
