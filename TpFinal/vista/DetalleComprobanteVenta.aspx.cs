﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace vista
{
    public partial class DetalleComprobanteVenta : System.Web.UI.Page
    {
        public DateTime hoy = DateTime.Today;
        public Cliente ClienteTemp = new Cliente();
        public List<Cliente> clientes = new List<Cliente>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["ClienteTemp"] != null)
            {
                ClienteTemp = (Cliente)Session["ClienteTemp"];
                
            }
            else if (Session["ClienteCompVenta"] != null)
            {
                ClienteTemp = (Cliente)Session["ClienteCompVenta"];
            }

            clientes = new ClientesNegocio().Listar();
            gvClientes.DataSource = clientes;

            ddlCategoria.DataSource = new CategoriasClienteNegocio().Listar();
            ddlCategoria.DataValueField = "id";
            ddlCategoria.DataTextField = "descripcion";

            if (!IsPostBack)
            {
                cargarForm();
                DataBind();
            }
        }

        protected void cargarForm()
        {

            txtCodigo.Text = ClienteTemp.codigo + " - " + ClienteTemp.nombre + " " + ClienteTemp.apellido;
        }
        protected void guardarSession()
        {
            Session.Add("ClienteTemp", ClienteTemp);
        }

        protected void borrarSession()
        {
            Session.Add("ClienteTemp", null);
        }

        protected void gvClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            string codigo = gvClientes.SelectedDataKey.Value.ToString();
            ClienteTemp = clientes.Find(x => x.codigo == codigo);
            guardarSession();
            Response.Redirect("DetalleComprobanteVenta.aspx");
        }

        protected void gvClientes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void TxtFiltro_TextChanged(object sender, EventArgs e)
        {
   
            List<Cliente> listaFiltrada = clientes.FindAll(x => x.apellido.ToUpper().Contains(TxtFiltro.Text.ToUpper()));
            gvClientes.DataSource = listaFiltrada;
            gvClientes.DataBind();
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            Session.Add("ClienteCompVenta", ClienteTemp);
            Response.Redirect("AltaVenta.aspx");
        }

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            borrarSession();
            Response.Redirect("AltaVenta.aspx");
        }

        protected void btnAltaCliente_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(TxtApellido.Text) || string.IsNullOrEmpty(TxtCodigoNuevoCliente.Text) || string.IsNullOrEmpty(TxtDNI.Text) || string.IsNullOrEmpty(TxtNombre.Text) || string.IsNullOrEmpty(ddlCategoria.Text))
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
                    nuevoCliente.codigo = TxtCodigoNuevoCliente.Text;
                    nuevoCliente.categoria = new CategoriaCliente();
                    nuevoCliente.categoria.id = int.Parse(ddlCategoria.SelectedValue);
                    nuevoCliente.telefono = TxtTelefono.Text;
                    nuevoCliente.email = TxtEmail.Text;
                    nuevoCliente.direccion = TxtDireccion.Text;

                    negocio.Agregar(nuevoCliente);

                    Session.Add("ClienteTemp", nuevoCliente);

                    Response.Redirect("DetalleComprobanteVenta.aspx", false);

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}