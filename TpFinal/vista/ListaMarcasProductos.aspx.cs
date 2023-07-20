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
    public partial class ListaMarcasProductos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("InicioSesion.aspx", false);
            }

            List<MarcaArticulo> marcas = new MarcaArticuloNegocio().Listar();

            GridViewMarca.DataSource = marcas;

            if(!IsPostBack)
            {
                DataBind();
            }
        }

        protected void GridViewMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = GridViewMarca.SelectedDataKey.Value.ToString();
            Response.Redirect("AltaMarcaProducto.aspx?id=" + id, false);
        }
    }
}