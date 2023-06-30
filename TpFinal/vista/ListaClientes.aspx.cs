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
    public partial class ListaClientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ClientesNegocio negocio = new ClientesNegocio();
                GridViewClientes.DataSource = negocio.Listar();
                DataBind();

                CategoriasClienteNegocio categoriaCliente = new CategoriasClienteNegocio();
                List<CategoriaCliente> Lista = categoriaCliente.Listar();

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


        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            ClientesNegocio Negocio = new ClientesNegocio();

            try
            {
                Cliente Nuevo = new Cliente();
                Nuevo.codigo = int.Parse(TxtCodigo.Text);
                Nuevo.nombre = TxtNombre.Text;
                Nuevo.apellido = TxtApellido.Text;
                Nuevo.categoria = new CategoriaCliente();
                Nuevo.categoria.id = int.Parse(ddlCategoria.SelectedValue);
                Nuevo.nDocumento = TxtDNI.Text;
                Nuevo.telefono = TxtTelefono.Text;
                Nuevo.email = TxtEmail.Text;
                Nuevo.direccion = TxtDireccion.Text;

                Negocio.Agregar(Nuevo);
                Response.Redirect("ListaClientes.aspx", false);

            }
            catch (Exception ex)
            {

                throw ex;
            }




        }

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListaClientes.aspx", false);
        }
    }
}