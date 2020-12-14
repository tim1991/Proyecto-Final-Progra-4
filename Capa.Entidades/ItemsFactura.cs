using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa.Entidades
{
    public class ItemsFactura
    {
        public int IdItemFactura { get; set; }
        public int IdProducto { get; set; }
        public int IdFactura { get; set; }
        public int Cantidad { get; set; }
        public decimal SubTotal { get; set; }
    }
}
