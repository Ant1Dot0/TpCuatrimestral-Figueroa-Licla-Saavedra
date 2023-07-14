using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio; 

namespace vista
{
    public partial class AltaCompra : System.Web.UI.Page
    {
        public Proveedor ProveedorCompCompra = new Proveedor();
        public List<DetalleProducto> detProductosCompra = new List<DetalleProducto>();
        public Usuario vendedor = new Usuario();
        public int totalCantidad = 0;
        public decimal total = 0;
        public int totalItems = 0;


        public DateTime hoy = DateTime.Today;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {

        }
    }
}