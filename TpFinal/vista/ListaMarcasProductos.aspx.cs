using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace vista
{
    public partial class ListaMarcasProductos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridViewMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = GridViewMarca.SelectedDataKey.Value.ToString();
            Response.Redirect("AltaMarcaProducto.aspx" + id);
        }
    }
}