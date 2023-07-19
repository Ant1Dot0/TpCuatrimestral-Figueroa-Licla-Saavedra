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
    public partial class ListaProductos : System.Web.UI.Page
    {
        public List<Producto> productos;
        public bool prueba = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            int idProducto = 0;

            if (Request.QueryString["id"] != null)
            {
                idProducto = int.Parse(Request.QueryString["id"].ToString());
            }


            if (idProducto >= 1)
            {
                new ProductoNegocio().Eliminar(idProducto);
                Response.Redirect("ListaProductos.aspx");
            }

            productos = new ProductoNegocio().listar();

            if(!IsPostBack)
            {
                repProductos.DataSource = productos;
                DataBind();
            }
            


        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            Session.Add("AccionProducto", 1); // 0 para alta, 1 para editar.
            string valor = (((Button)sender).CommandArgument); // capturo código de articulo del btn que clickearon
            Producto aux = productos.Find(a => a.codigo == valor); // busco por código de artículo en la lista productos, me devuelve un obj clase Producto
            Session.Add("ProductoSelected",aux); // comparto el producto en la session para usarlo en la ventana AltaArticulo
            Response.RedirectPermanent("AltaArticulo.aspx"); // me dirijo a Alta Articulo
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Session.Add("AccionProducto", 0); // 0 para alta, 1 para editar.
            Session.Add("ProductoSelected", null);
            Session.Add("ProveedoresSelected", null);
            Response.RedirectPermanent("AltaArticulo.aspx", false);
        }
    }
}