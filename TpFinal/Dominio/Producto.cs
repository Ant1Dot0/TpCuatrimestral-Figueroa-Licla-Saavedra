using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Producto
    {
        public int id { get; set; }

        public string codigo { get; set; }

        public string descripcion { get; set; }

        public MarcaArticulo marca { get; set; }

        public CategoriaArticulo categoria { get; set; }

        public decimal precioCompra { get; set; }

        public decimal ganacia { get; set; }

        public decimal stockActual { get; set; }

        public decimal stockMinimo { get; set; }

        public bool estado { get; set; }

        public Producto()
        {
            this.marca = new MarcaArticulo();
            this.categoria = new CategoriaArticulo();
        }
    }
}
