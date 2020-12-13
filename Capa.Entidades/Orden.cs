namespace Capa.Entidades
{
    public class Orden
    {
        public int IdOrden { get; set; }
        public int IdCliente { get; set; }
        public int IdMetodoPago { get; set; }
        public decimal Total { get; set; }
    }
}
