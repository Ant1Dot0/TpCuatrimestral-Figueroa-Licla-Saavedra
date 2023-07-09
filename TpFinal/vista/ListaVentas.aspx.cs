using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace vista
{
    public partial class ListaVentas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridViewClientes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnNuevaVenta_Click(object sender, EventArgs e)
        {
            Session.Add("ClienteCompVenta", null);
            Session.Add("ClienteTemp", null);
            Response.Redirect("AltaVenta.aspx");
        }
    }
}