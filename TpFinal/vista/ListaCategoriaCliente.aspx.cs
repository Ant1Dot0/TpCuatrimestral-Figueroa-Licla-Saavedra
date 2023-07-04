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
            CategoriasClienteNegocio negocio = new CategoriasClienteNegocio();
            GridViewCategoria.DataSource = negocio.Listar();
            DataBind();
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            CategoriasClienteNegocio negocio = new CategoriasClienteNegocio();
            CategoriaCliente nuevaCatCliente = new CategoriaCliente();

            nuevaCatCliente.codigo = TxtCodigo.Text;
            nuevaCatCliente.descripcion = TxtDescripcion.Text;

            negocio.Agregar(nuevaCatCliente);
            Response.Redirect("ListaCategoriaCliente.aspx", false);
        }

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            CategoriasClienteNegocio negocio = new CategoriasClienteNegocio();
            int Aux = int.Parse(Request.QueryString["Id"].ToString());

            negocio.Eliminar(Aux);
            Response.Redirect("ListaCategoriaCliente.aspx", false);
        }

        protected void GridViewCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}