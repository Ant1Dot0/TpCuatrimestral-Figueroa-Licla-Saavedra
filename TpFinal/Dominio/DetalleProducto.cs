using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class DetalleProducto
    {
        public int id { get; set; }

        public string codComprobante { get; set; }

        public string codProducto { get; set; }

        public string descripcion { get; set; }

        public int cantidad { get; set; }

        public decimal precioVenta { get; set; }

        public decimal montoDescuento { get; set; }

        public decimal monto { get; set; }
    }
}
