    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Cliente
    {
        public int id{ get; set; }

        public string codigo { get; set; }

        public string nombre { get; set; }

        public string apellido { get; set; }

        public string nDocumento { get; set; }

        public CategoriaCliente categoria { get; set; }

        public string telefono { get; set; }

        public string email { get; set; }

        public string direccion { get; set; }

        public bool estado { get; set; }

        public Cliente()
        {
            this.categoria = new CategoriaCliente();
        }
        public override string ToString()
        {
            return "" + this.nombre + " " + this.apellido ;
        }
    }
}
