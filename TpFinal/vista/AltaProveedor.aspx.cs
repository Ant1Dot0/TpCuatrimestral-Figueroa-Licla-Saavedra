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
    public partial class AltaProveedor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CategoriasProveedorNegocio categoriaProveedor = new CategoriasProveedorNegocio();
            List<CategoriaProveedor> Lista = categoriaProveedor.Listar();


            ddlCategoria.DataSource = Lista;
            ddlCategoria.DataValueField = "id";
            ddlCategoria.DataTextField = "descripcion";
            DataBind();

            if (Request.QueryString["id"] != null)
            {

                List<Proveedor> categorias = new List<Proveedor>();
                ProveedorNegocio proveedor = new ProveedorNegocio();

                categorias = proveedor.ListarProveedor();
                int id = int.Parse(Request.QueryString["id"]);

                Proveedor seleccionado = categorias.Find(x => x.id == id);


                TxtCodigo.Text = seleccionado.codigo;
                TxtCuit.Text = seleccionado.cuit;
                TxtDireccion.Text = seleccionado.direccion;
                TxtRazonSocial.Text = seleccionado.razonSocial;
                TxtEmail.Text = seleccionado.email;
                TxtDireccion.Text = seleccionado.direccion;
                TxtTelefono.Text = seleccionado.telefono;

            }



        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(TxtDireccion.Text) || string.IsNullOrEmpty(TxtCodigo.Text) || string.IsNullOrEmpty(TxtCuit.Text) || string.IsNullOrEmpty(TxtRazonSocial.Text) || string.IsNullOrEmpty(ddlCategoria.Text))
                {
                    return;
                }
                else
                {
                    Proveedor nuevoProveedor = new Proveedor();
                    ProveedorNegocio negocio = new ProveedorNegocio();

                    nuevoProveedor.codigo = TxtCodigo.Text;
                    nuevoProveedor.razonSocial = TxtRazonSocial.Text;
                    nuevoProveedor.cuit = TxtCuit.Text;
                    nuevoProveedor.telefono = TxtTelefono.Text;
                    nuevoProveedor.categoria = new CategoriaProveedor();
                    nuevoProveedor.categoria.id = int.Parse(ddlCategoria.SelectedValue);
                    nuevoProveedor.email = TxtEmail.Text;
                    nuevoProveedor.direccion = TxtDireccion.Text;

                    negocio.Agregar(nuevoProveedor);
                    Response.Redirect("ListaProveedor.aspx", false);

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            ProveedorNegocio negocio = new ProveedorNegocio();
            int Aux = int.Parse(Request.QueryString["Id"].ToString());

            negocio.Eliminar(Aux);
            Response.Redirect("ListaProveedor.aspx", false);

        }
    }
}