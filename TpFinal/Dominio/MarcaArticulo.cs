﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class MarcaArticulo
    {
        public int id { get; set; }

        public string codigo { get; set; }

        public string descripcion { get; set; }

        public bool estado { get; set; }

        public override string ToString()
        {
            return this.descripcion;
        }

    }
    
}
