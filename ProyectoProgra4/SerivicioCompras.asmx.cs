using Capa.LogicaNegocio.Productos;
using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;
using Capa.Entidades;

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
        /// Obtiene los datos del empleado
        /// </summary>
        /// <param name="IdProducto"></param>
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void ObtieneProductosXCategoria(int IdProducto)
        {
            try
            {
                JavaScriptSerializer JSSDatos = new JavaScriptSerializer();
                ProductosLogica ObtieneProductos = new ProductosLogica();
                string JSONRespuesta = String.Empty;
                var Respuesta = ObtieneProductos.ObtieneProductosXCategoria(IdProducto);
                JSONRespuesta = JSSDatos.Serialize(Respuesta);
                Context.Response.Write(JSONRespuesta);
            }
            catch (Exception)
            {
                Context.Response.Write("Un error ha ocurrido por favor verifique los datos");
            }
        }

        /// <summary>
        /// Obtiene los datos del empleado
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
    }
}
