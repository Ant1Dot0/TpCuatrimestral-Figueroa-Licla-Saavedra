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
        Cliente ClienteCompVenta = new Cliente();

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
        }


        protected void cargarForm()
        {
            TxtCliente.Text = ClienteCompVenta.codigo + " - " + ClienteCompVenta.nombre + " " + ClienteCompVenta.apellido;
        }
    }
}