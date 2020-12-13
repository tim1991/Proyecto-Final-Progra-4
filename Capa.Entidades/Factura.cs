namespace Capa.Entidades
{
    public class Factura
    {
        public int IdFactura { get; set; }
        public int IdOrden { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
    }
}
