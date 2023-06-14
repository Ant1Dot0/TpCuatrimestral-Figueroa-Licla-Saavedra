using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    class Proveedor
    {
        public int id { get; set; }

        public string razonSocial { get; set; }

        public string cuit { get; set; }

        public CategoriaProveedor categoria { get; set; }

        public string telefono { get; set; }

        public string email { get; set; }

        public string direccion { get; set; }
    }
}
