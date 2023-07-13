using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Talonario
    {
        public int id { get; set; }
        public string descripcion { get; set; }
        public string codigo { get; set; }
        public int tipoComprobante { get; set; }
        public int pdv { get; set; }
        public int ultNumero { get; set; }
        public bool estado { get; set; }
    }
}
