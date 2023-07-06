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

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            CategoriaArticuloNegocio negocio = new CategoriaArticuloNegocio();
            CategoriaArticulo nuevaCatProducto = new CategoriaArticulo();

            nuevaCatProducto.codigo = TxtCodigo.Text;
            nuevaCatProducto.descripcion = TxtDescripcion.Text;

            negocio.Agregar(nuevaCatProducto);
            Response.Redirect("ListaCategoriaProduco.aspx",false);
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            CategoriaArticuloNegocio negocio = new CategoriaArticuloNegocio();
            int Aux = int.Parse(Request.QueryString["Id"].ToString());

            negocio.Eliminar(Aux);
            Response.Redirect("ListaCategoriaProducto.aspx", false);
        }
    }
}