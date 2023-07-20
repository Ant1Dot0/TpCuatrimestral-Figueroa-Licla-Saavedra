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
    public partial class ListaClientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["User"] == null)
                {
                    Response.Redirect("InicioSesion.aspx", false);
                }

                ClientesNegocio negocio = new ClientesNegocio();
                GridViewClientes.DataSource = negocio.Listar();
                DataBind();
            }
            catch (Exception ex)
            {

                Session.Add("Error.aspx", ex.Message);
            }


        }

        protected void GridViewClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = GridViewClientes.SelectedDataKey.Value.ToString();
            Response.Redirect("AltaCategoriaProveedor?id=" + id, false);
        }
    }
}