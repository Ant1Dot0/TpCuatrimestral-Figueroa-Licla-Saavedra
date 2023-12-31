﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Usuario
    {
        public int id { get; set; }

        public string idLogin { get; set; }

        public string password { get; set; }

        public string email { get; set; }

        public string nombre { get; set; }

        public string apellido { get; set; }

        public string telefono { get; set; }

        public string direccion { get; set; }

        public string movil { get; set; }

        public Rol rol { get; set; }

        public bool estado { get; set; }

        public Usuario()
        {
            this.rol = new Rol();
        }

        public override string ToString()
        {
            return "" + this.nombre + " " + this.apellido;
        }

    }
}
