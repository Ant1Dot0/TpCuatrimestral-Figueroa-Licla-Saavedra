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
        public List<Cliente> clientes = new List<Cliente>();
        public Cliente clienteSelected = new Cliente();
        protected void Page_Load(object sender, EventArgs e)
        {
            clienteSelected.codigo = "-1";
            string pruval = "prueba2";
            if (Session["PRUEBA"] != null)
            {
                clienteSelected.codigo = Session["PRUEBA"].ToString();
            }
            else
            {
                Session.Add("PRUEBA", pruval);
               
            }


            cargaProducto();

            try
            {
                ClientesNegocio negocio = new ClientesNegocio();

                CategoriasClienteNegocio categoriaCliente = new CategoriasClienteNegocio();
                List<CategoriaCliente> Lista = categoriaCliente.Listar();

                ddlCategoria.DataSource = Lista;
                ddlCategoria.DataValueField = "id";
                ddlCategoria.DataTextField = "descripcion";
                DataBind();


                clientes = negocio.Listar();


                repClientes.DataSource = clientes;
                repClientes.DataBind();
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
                Nuevo.codigo = (string)(TxtCodigo.Text);
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



        protected void prueba_Click(object sender, EventArgs e)
        {
            string valor = ((LinkButton)sender).CommandArgument;
            Session.Add("PRUEBA", valor);
            Response.Redirect("ListaClientes.aspx");

        }

        public void cargaProducto()
        {
            TxtCodigo.Text = clienteSelected.codigo;
        }
    }
}