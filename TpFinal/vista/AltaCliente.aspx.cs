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

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
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