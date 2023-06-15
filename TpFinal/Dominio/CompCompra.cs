using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class CompCompra
    {

        public int id { get; set; }

        public string codigo { get; set; }

        public string puntoVenta { get; set; }

        public string numero { get; set; }

        public Proveedor proveedor { get; set; }

        public DateTime fechaComp { get; set; }

        public Usuario vendedor { get; set; }

        public decimal subtotal { get; set; }

        public decimal totalDescuento { get; set; }

        public decimal descuentoComp { get; set; }

        public decimal totalComprobante { get; set; }

    }
}
