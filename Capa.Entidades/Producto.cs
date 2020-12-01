namespace Capa.Entidades
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public string DescripcionProducto { get; set; }
        public string ImagenProducto { get; set; }
        public int  IdCategoria { get; set; }
        public decimal  PrecioProducto { get; set; }
    }
}
