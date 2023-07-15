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


            if (Request.QueryString["id"] != null)
            {
                List<CategoriaCliente> categorias = new List<CategoriaCliente>();
                CategoriasClienteNegocio negocio = new CategoriasClienteNegocio();

                categorias = negocio.Listar();
                int id = int.Parse(Request.QueryString["id"]);

                CategoriaCliente seleccionado = categorias.Find(x => x.id == id);

                TxtCodigo.Text = seleccionado.codigo;
                TxtDescripcion.Text = seleccionado.descripcion;
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {

                if (string.IsNullOrEmpty(TxtCodigo.Text) || string.IsNullOrEmpty(TxtDescripcion.Text))
                {
                    return;
                }
                else
                {

                    CategoriasClienteNegocio negocio = new CategoriasClienteNegocio();
                    CategoriaCliente nuevaCatCliente = new CategoriaCliente();

                    nuevaCatCliente.codigo = TxtCodigo.Text;
                    nuevaCatCliente.descripcion = TxtDescripcion.Text;

                    negocio.Agregar(nuevaCatCliente);
                    Response.Redirect("ListaCategoriaCliente.aspx", false);

                }
               

            }
            catch (Exception ex)
            {

                throw ex;
            }

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