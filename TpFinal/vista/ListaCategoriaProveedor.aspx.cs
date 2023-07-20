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
    public partial class ListaCategoriaProveedor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("InicioSesion.aspx", false);
            }

            CategoriasProveedorNegocio negocio = new CategoriasProveedorNegocio();
            GridViewCategoria.DataSource = negocio.Listar();
            DataBind();
        }


        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            CategoriasProveedorNegocio negocio = new CategoriasProveedorNegocio();
            int Aux = int.Parse(Request.QueryString["Id"].ToString());

            negocio.Eliminar(Aux);
            Response.Redirect("ListaCategoriaProveedor.aspx", false);
        }

        protected void GridViewCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = GridViewCategoria.SelectedDataKey.Value.ToString();
            Response.Redirect("AltaCategoriaProveedor?id=" + id, false);
        }


    }
}