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
    public partial class AltaMarcaProducto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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

                    MarcaArticuloNegocio negocio = new MarcaArticuloNegocio();
                    MarcaArticulo nuevaMarProducto = new MarcaArticulo();

                    nuevaMarProducto.codigo = TxtCodigo.Text;
                    nuevaMarProducto.descripcion = TxtDescripcion.Text;

                    negocio.Agregar(nuevaMarProducto);
                    Response.Redirect("ListaMarcaProductos.aspx", false);

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}