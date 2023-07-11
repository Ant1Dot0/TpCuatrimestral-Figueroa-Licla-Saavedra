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
    public partial class AltaVenta : System.Web.UI.Page
    {
        public Cliente ClienteCompVenta = new Cliente();
        public List<DetalleProducto> detProductosVenta = new List<DetalleProducto>();
        public int totalCantidad = 0;
        public decimal total = 0;
        public int totalItems = 0;


        public DateTime hoy = DateTime.Today;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["ClienteCompVenta"] != null)
            {
                ClienteCompVenta = (Cliente)Session["ClienteCompVenta"];
            }

            if(!IsPostBack)
            {
                cargarForm();
            }

            if(Session["DetProductosVenta"] != null)
            {
                detProductosVenta = (List<DetalleProducto>)Session["DetProductosVenta"];
            }

            totalCantidad = 0;
            total = 0;
            totalItems = 0;

            foreach (DetalleProducto x in detProductosVenta)
            {
                totalCantidad += x.cantidad;
                total += x.monto;
                totalItems++;
            }

            txtTotalCantidad.Text = ""+totalCantidad;
            TxtTotalItems.Text = "" + totalItems;
            
            

        }

        protected void cargarForm()
        {
            TxtCliente.Text = ClienteCompVenta.codigo + " - " + ClienteCompVenta.nombre + " " + ClienteCompVenta.apellido;
        }
    }
}