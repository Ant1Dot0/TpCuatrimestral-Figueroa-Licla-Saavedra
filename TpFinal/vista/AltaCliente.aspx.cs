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
    public partial class AltaCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            CategoriasClienteNegocio categoriaCliente = new CategoriasClienteNegocio();
            List<CategoriaCliente> Lista = categoriaCliente.Listar();


            ddlCategoria.DataSource = Lista;
            ddlCategoria.DataValueField = "id";
            ddlCategoria.DataTextField = "descripcion";
            DataBind();

            if (Request.QueryString["id"] != null)
            {

                List<Cliente> categorias = new List<Cliente>();
                ClientesNegocio negocio = new ClientesNegocio();

                categorias = negocio.Listar();
                int id = int.Parse(Request.QueryString["id"]);

                Cliente seleccionado = categorias.Find(x => x.id == id);

                TxtApellido.Text = seleccionado.apellido;
                TxtCodigo.Text = seleccionado.codigo;
                TxtDireccion.Text = seleccionado.direccion;
                TxtDNI.Text = seleccionado.nDocumento;
                TxtEmail.Text = seleccionado.email;
                TxtNombre.Text = seleccionado.nombre;
                TxtTelefono.Text = seleccionado.telefono;

            }


        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

            try
            {
                if (string.IsNullOrEmpty(TxtApellido.Text) || string.IsNullOrEmpty(TxtCodigo.Text) || string.IsNullOrEmpty(TxtDNI.Text) || string.IsNullOrEmpty(TxtNombre.Text) || string.IsNullOrEmpty(ddlCategoria.Text))
                {                   
                    return;
                }
                else
                {
                    Cliente nuevoCliente = new Cliente();
                    ClientesNegocio negocio = new ClientesNegocio();

                    nuevoCliente.nDocumento = TxtDNI.Text;
                    nuevoCliente.nombre = TxtNombre.Text;
                    nuevoCliente.apellido = TxtApellido.Text;
                    nuevoCliente.codigo = TxtCodigo.Text;
                    nuevoCliente.categoria = new CategoriaCliente();
                    nuevoCliente.categoria.id = int.Parse(ddlCategoria.SelectedValue);
                    nuevoCliente.telefono = TxtTelefono.Text;
                    nuevoCliente.email = TxtEmail.Text;
                    nuevoCliente.direccion = TxtDireccion.Text;

                    negocio.Agregar(nuevoCliente);
                    Response.Redirect("ListaClientes.aspx", false);

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            ClientesNegocio negocio = new ClientesNegocio();
            int Aux = int.Parse(Request.QueryString["Id"].ToString());

            negocio.Eliminar(Aux);
            Response.Redirect("ListaClientes.aspx", false);
        }

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {

        }
    }
}