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
    public partial class AltaUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(TxtNombre.Text) || string.IsNullOrEmpty(TxtApellido.Text) || string.IsNullOrEmpty(TxtEmail.Text) || string.IsNullOrEmpty(TxtPassword.Text) || string.IsNullOrEmpty(TxtDireccion.Text))
                {
                    return;
                }
                else
                {
                    Usuario nuevoUsuario = new Usuario();
                    UsuarioNegocio negocio = new UsuarioNegocio();

                    nuevoUsuario.nombre = TxtNombre.Text;
                    nuevoUsuario.apellido = TxtApellido.Text;
                    nuevoUsuario.telefono = TxtTelefono.Text;
                    nuevoUsuario.movil = TxtMovil.Text;
                    nuevoUsuario.direccion = TxtDireccion.Text;
                    nuevoUsuario.email = TxtEmail.Text;
                    nuevoUsuario.password = TxtPassword.Text;
                    

                    negocio.Agregar(nuevoUsuario);
                    
                    Response.Redirect("InicioSesion.aspx", false);

                }
            }
            catch (Exception ex)
            {

                Session.Add("Error.aspx", ex.Message);
            }

        }


    }
}