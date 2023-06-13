using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    class Producto
    {
        public int id { get; set; }

        public string codigo { get; set; }

        public string descripcion { get; set; }

        public MarcaArticulo marca { get; set; }

        public CategoriaArticulo categoria { get; set; }

        public decimal precioCompra { get; set; }

        public decimal ganacia { get; set; }

        public int stockActual { get; set; }

        public int stockMinimo { get; set; }
    }
}
