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
    public partial class ListaProveedores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                CategoriasProveedorNegocio categoriaProveedor = new CategoriasProveedorNegocio();

                List<CategoriaProveedor> Lista = categoriaProveedor.Listar();

                ddlCategoria.DataSource = Lista;
                ddlCategoria.DataValueField = "id";
                ddlCategoria.DataTextField = "descripcion";
                DataBind();


            }
            catch (Exception ex)
            {

                throw ex;
            }




        }

        
        /*CONFIGURAR BOTON AGREGAR PROVEEDOR*/
        
        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            ProveedorNegocio Negocio = new ProveedorNegocio();

            try
            {
                Proveedor Nuevo = new Proveedor();
                Nuevo.codigo = (string)(TxtCodigo.Text);
                Nuevo.razonSocial = TxtRazonSocial.Text;
                Nuevo.cuit = TxtCuit.Text;
                Nuevo.categoria = new CategoriaProveedor();
                Nuevo.telefono = TxtTelefono.Text;
                Nuevo.email = TxtEmail.Text;
                Nuevo.direccion = TxtDireccion.Text;
                
               

                Negocio.Agregar(Nuevo);

            }
            catch (Exception ex)
            {

                throw ex;
            }




        }
        
        
        /*---------------------------------------------*/
    }
}