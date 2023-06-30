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
    public partial class AltaCategoriaCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            CategoriasClienteNegocio negocio = new CategoriasClienteNegocio();
            CategoriaCliente nuevaCatCliente = new CategoriaCliente();

            nuevaCatCliente.codigo = TxtCodigo.Text;
            nuevaCatCliente.descripcion = TxtDescripcion.Text;

            negocio.Agregar(nuevaCatCliente);
            Response.Redirect("ListaCategoriaCliente.aspx", false);

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            CategoriasClienteNegocio negocio = new CategoriasClienteNegocio();
            int Aux = int.Parse(Request.QueryString["Id"].ToString());

            negocio.Eliminar(Aux);
            Response.Redirect("ListaCategoriaCliente.aspx", false);
        }
    }
}