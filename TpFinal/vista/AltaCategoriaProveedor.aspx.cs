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
    public partial class AltaCategoriaProveedor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        /*-----------------------------------------------------------------*/
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            CategoriasProveedorNegocio negocio = new CategoriasProveedorNegocio();
            CategoriaProveedor nuevaCatProveedor = new CategoriaProveedor();

            nuevaCatProveedor.codigo = TxtCodigo.Text;
            nuevaCatProveedor.descripcion = TxtDescripcion.Text;

            negocio.Agregar(nuevaCatProveedor);
            Response.Redirect("ListaCategoriaProveedor.aspx", false);

        }


        /*------------------------------------------------------------------*/
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            CategoriasProveedorNegocio negocio = new CategoriasProveedorNegocio();
            int Aux = int.Parse(Request.QueryString["Id"].ToString());

            negocio.Eliminar(Aux);
            Response.Redirect("ListaCategoriaProveedor.aspx", false);
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {

        }
    }
}