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
    public partial class ListaCategoriaCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["User"] == null)
                {
                    Response.Redirect("InicioSesion.aspx", false);
                }

                CategoriasClienteNegocio negocio = new CategoriasClienteNegocio();
                GridViewCategoria.DataSource = negocio.Listar();
                DataBind();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


        protected void GridViewCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
           var id = GridViewCategoria.SelectedDataKey.Value.ToString();
           Response.Redirect("AltaCategoriaCliente.aspx?id=" + id, false);
        }
    }
}