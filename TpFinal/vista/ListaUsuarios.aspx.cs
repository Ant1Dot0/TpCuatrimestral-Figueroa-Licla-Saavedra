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
    public partial class ListaUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("InicioSesion.aspx", false);
            }


            UsuarioNegocio negocio = new UsuarioNegocio();
            GridViewUsuarios.DataSource = negocio.Listar();
            DataBind();
            
        }

        protected void GridViewUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}