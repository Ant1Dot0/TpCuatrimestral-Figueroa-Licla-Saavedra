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
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnIngreso_Click(object sender, EventArgs e)
        {
            UsuarioNegocio datosUsuarios = new UsuarioNegocio();
            Usuario Log = new Usuario();

            try
            {
                Log.email = TxtEmail.ToString();
                Log.password = TxtPass.ToString();
                if (datosUsuarios.Logueo(Log) == true)
                {
                    Session.Add("User", Log);
                    Response.Redirect("Default.aspx");
                }
                else
                {
                    Response.Redirect("About.aspx");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}