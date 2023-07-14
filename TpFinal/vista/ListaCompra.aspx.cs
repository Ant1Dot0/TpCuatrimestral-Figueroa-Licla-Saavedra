using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace vista
{
    public partial class ListaCompra : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void borrarSession()
        {

        }

        protected void btnNuevaCompra_Click(object sender, EventArgs e)
        {
            Response.Redirect("AltaCompra.aspx");
        }
    }
}