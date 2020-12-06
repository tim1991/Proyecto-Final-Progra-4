namespace Capa.Entidades
{
    public class Carrito: Producto
    {
        public int IdUsuario { get; set; }
        public int Cantidad { get; set; }
        public string NombreCliente { get; set; }
        public string ApellidoCliente { get; set; }
    }
}
