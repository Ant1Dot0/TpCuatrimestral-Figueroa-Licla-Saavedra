using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public enum TipoRol
    {

        ADMIN = 1,
        VISTA = 2

    }


    public class Rol
    {
        public int id { get; set; }

        public string codigo { get; set; }

        public string descripcion { get; set; }

        public bool estado { get; set; }
    }
}
