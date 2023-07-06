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

            try
            {
                ClientesNegocio negocio = new ClientesNegocio();
                clientes = negocio.Listar();


                repClientes.DataSource = clientes;
                repClientes.DataBind();
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

    }
}