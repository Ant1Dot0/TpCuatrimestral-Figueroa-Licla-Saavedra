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
    public partial class AltaCategoriaProducto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["User"] == null)
                {
                    Response.Redirect("InicioSesion.aspx", false);
                }

                if (Request.QueryString["id"] != null)
                {
                    List<CategoriaArticulo> categorias = new List<CategoriaArticulo>();
                    CategoriaArticuloNegocio negocio = new CategoriaArticuloNegocio();

                    categorias = negocio.Listar();
                    int id = int.Parse(Request.QueryString["id"]);

                    CategoriaArticulo seleccionado = categorias.Find(x => x.id == id);

                    TxtCodigo.Text = seleccionado.codigo;
                    TxtDescripcion.Text = seleccionado.descripcion;


                }
            }
            catch (Exception ex)
            {

                Session.Add("Error.aspx", ex.Message);
            }

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if(string.IsNullOrEmpty(TxtCodigo.Text) || string.IsNullOrEmpty(TxtDescripcion.Text))
                {
                    return;
                }
                else
                {

                    CategoriaArticuloNegocio negocio = new CategoriaArticuloNegocio();
                    CategoriaArticulo nuevaCatProducto = new CategoriaArticulo();

                    nuevaCatProducto.codigo = TxtCodigo.Text;
                    nuevaCatProducto.descripcion = TxtDescripcion.Text;

                    negocio.Agregar(nuevaCatProducto);
                    Response.Redirect("ListaCategoriaProducto.aspx",false);

                }
            }
            catch (Exception ex)
            {

                Session.Add("Error.aspx", ex.Message);
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                CategoriaArticuloNegocio negocio = new CategoriaArticuloNegocio();
                int Aux = int.Parse(Request.QueryString["Id"].ToString());

                negocio.Eliminar(Aux);
                Response.Redirect("ListaCategoriaProducto.aspx", false);
            }
            catch (Exception ex)
            {

                Session.Add("Error.aspx", ex.Message);
            }

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {

        }
    }
}