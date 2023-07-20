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
    public partial class ListaVentas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("InicioSesion.aspx", false);
            }

            List<CompVenta> ventas = new VentaNegocio().Listar();

            gvVentas.DataSource = ventas;

            if(!IsPostBack)
            {
                DataBind();
            }

        }
        protected void borrarSession()
        {
            Session.Add("ClienteCompVenta", null);
            Session.Add("DetProductosVenta", null);
            Session.Add("ProductosSeleccionados", null);
        }

        protected void btnNuevaVenta_Click(object sender, EventArgs e)
        {
            borrarSession();
            Response.Redirect("AltaVenta.aspx");
        }
    }
}