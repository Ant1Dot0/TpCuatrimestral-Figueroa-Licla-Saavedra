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
    public partial class InicioSesion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnIngreso_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtEmail.Text) || string.IsNullOrEmpty(TxtPass.Text))
            {
                return;
            }


            UsuarioNegocio negocio = new UsuarioNegocio();
            Usuario Log = new Usuario();

            try
            {
                Log.email = TxtEmail.Text;
                Log.password = TxtPass.Text;
                if (negocio.Logueo(Log) == true)
                {
                    Log = new UsuarioNegocio().Listar().Find(x => x.id == Log.id);

                    Session.Add("User", Log);
                    Response.Redirect("Default.aspx", false);
                }
                else
                {
                    Session.Add("error", "CREDENCIALES INCORRECTAS");
                    Response.Redirect("error.aspx", false);
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("error.aspx", false);
            }
        }
    }
}