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
    public partial class ListacategoriaProducto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GridViewCategoria.DataSource = new CategoriaArticuloNegocio().Listar();

            if(!IsPostBack)
            {
                DataBind();
            }
        }

        protected void GridViewCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = GridViewCategoria.SelectedDataKey.Value.ToString();
            Response.Redirect("AltaCategoriaProducto.aspx" + id);
        }
    }
}