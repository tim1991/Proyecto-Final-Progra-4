namespace Capa.Utilidades.GuardaErrores
{
    public class GuardaErrores
    {
        /// <summary>
        /// Se encarga de insertar el detalle de los errores
        /// </summary>
        /// <param name="Metodo"></param>
        /// <param name="Clase"></param>
        /// <param name="Error"></param>
        /// <param name="LineaError"></param>
        public void InsertarErrores(string Metodo, string Clase, string Error, string LineaError)
        {
            using (ErroresDataContext Carrito = new ErroresDataContext())
            {
                Carrito.sp_InsertarErrorLog(Metodo, Clase, Error, LineaError);
            }
        }
    }
}
