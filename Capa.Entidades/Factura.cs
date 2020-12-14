using System;

namespace Capa.Entidades
{
    public class Factura
    {
        public int IdFactura { get; set; }
        public int IdCliente { get; set; }
        public DateTime FechaFactura { get; set; }
        public decimal Total { get; set; }
    }
}
