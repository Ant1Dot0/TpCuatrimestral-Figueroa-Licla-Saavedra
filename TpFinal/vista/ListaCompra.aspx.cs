using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace vista
{
    public partial class ListaCompra : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("InicioSesion.aspx", false);
            }

            List<CompCompra> compras = new CompraNegocio().Listar();

            List<Proveedor> proveedores = new ProveedorNegocio().ListarProveedor();

            foreach(CompCompra x in compras)
            {
                x.proveedor = proveedores.Find(a => a.id == x.proveedor.id);
            }

            gvCompras.DataSource = compras;

            

            if (!IsPostBack)
            {
                DataBind();
            }
        }

        protected void borrarSession()
        {
            Session.Add("ProveedorCompCompra", null);
            Session.Add("DetProductosCompra", null);
            Session.Add("ProductosSeleccionadosC", null);
            Session.Add("proveedorTemp", null);
            Session.Add("pdvTemp", null);
            Session.Add("pdv", null);
            Session.Add("NumeroTemp", null);
            Session.Add("Numero", null);
        }

        protected void btnNuevaCompra_Click(object sender, EventArgs e)
        {
            borrarSession();
            Response.Redirect("AltaCompra.aspx");
        }

        protected void gvCompras_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}