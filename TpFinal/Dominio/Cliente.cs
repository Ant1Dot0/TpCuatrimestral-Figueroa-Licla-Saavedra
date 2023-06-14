﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    class Cliente
    {
        public int id{ get; set; }

        public int codigo { get; set; }

        public string nombre { get; set; }

        public string apellido { get; set; }

        public string nDocumento { get; set; }

        public CategoriaCliente categoria { get; set; }

        public string telefono { get; set; }

        public string email { get; set; }

        public string direccion { get; set; }
    }
}
