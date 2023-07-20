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
    public partial class DetalleComprobanteCompra : System.Web.UI.Page
    {
        public DateTime hoy = DateTime.Today;
        public Proveedor proveedorTemp = new Proveedor();
        public List<Proveedor> proveedores = new List<Proveedor>();
        public Usuario vendedor = new Usuario();
        public string numero;
        public string pdv;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["User"] == null)
            {
                Response.Redirect("InicioSesion.aspx", false);
            }


            if (Session["ProveedorTemp"] != null)
            {
                proveedorTemp = (Proveedor)Session["ProveedorTemp"];
            }
            else if (Session["ProveedorCompCompra"] != null)
            {
                proveedorTemp = (Proveedor)Session["ProveedorCompCompra"];
            }
            if (Session["User"] != null)
            {
                vendedor = (Usuario)Session["User"];
            }

            if (Session["NumeroTemp"] != null)
            {
                numero = (string)Session["NumeroTemp"];
            }
            else if (Session["Numero"] != null)
            {
                numero = (string)Session["Numero"];
            }

            if (Session["pdvTemp"] != null)
            {
                pdv = (string)Session["pdvTemp"];
            }
            else if (Session["pdv"] != null)
            {
                pdv = (string)Session["pdv"];
            }

            proveedores = new ProveedorNegocio().ListarProveedor();
            gvProveedores.DataSource = proveedores;

            ddlCategoria.DataSource = new CategoriasProveedorNegocio().Listar();
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
            if (proveedorTemp.id > 0)
                txtCodigo.Text = proveedorTemp.codigo + " - " + proveedorTemp.razonSocial;
            TxtVendedor.Text = vendedor.ToString();
            TxtNumero.Text = numero;
            TxtPdv.Text = pdv;
        }

        protected void guardarForm()
        {
            numero = TxtNumero.Text;
            pdv = TxtPdv.Text;


            Session.Add("NumeroTemp", numero);
            Session.Add("pdvTemp", pdv);
        }

        protected void guardarSession()
        {
            Session.Add("ProveedorTemp", proveedorTemp);
            Session.Add("NumeroTemp", numero);
            Session.Add("pdvTemp", pdv);

        }

        protected void borrarSession()
        {
            Session.Add("ProveedorTemp", null);
            Session.Add("NumeroTemp", null);
            Session.Add("pdvTemp", null);
        }
        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            guardarForm();
            numero = TxtNumero.Text;
            pdv = TxtPdv.Text;

            Session.Add("ProveedorCompCompra", proveedorTemp);
            Session.Add("Numero", numero);
            Session.Add("pdv", pdv);

            Response.Redirect("AltaCompra.aspx");
        }

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            borrarSession();
            Response.Redirect("AltaCompra.aspx");
        }

        protected void gvProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            string codigo = gvProveedores.SelectedDataKey.Value.ToString();
            proveedorTemp = proveedores.Find(x => x.codigo == codigo);

            guardarForm();
            guardarSession();
            Response.Redirect("DetalleComprobanteCompra.aspx");
        }

        protected void gvProveedor_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void TxtFiltro_TextChanged(object sender, EventArgs e)
        {
            List<Proveedor> listaFiltrada = proveedores.FindAll(x => x.razonSocial.ToUpper().Contains(TxtFiltro.Text.ToUpper()));
            gvProveedores.DataSource = listaFiltrada;
            guardarForm();
            gvProveedores.DataBind();
        }

        protected void btnAltaProveedor_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(TxtCodigoProveedorNuevo.Text) || string.IsNullOrEmpty(TxtRazonSocial.Text) || string.IsNullOrEmpty(TxtCuit.Text))
                {
                    return;
                }
                else
                {
                    Proveedor nuevoCliente = new Proveedor();
                    ProveedorNegocio negocio = new ProveedorNegocio();

                    nuevoCliente.codigo = TxtCodigoProveedorNuevo.Text;
                    nuevoCliente.cuit = TxtCuit.Text;
                    nuevoCliente.razonSocial = TxtRazonSocial.Text;
                    nuevoCliente.telefono = TxtTelefono.Text;
                    nuevoCliente.categoria = new CategoriaProveedor();
                    nuevoCliente.categoria.id = int.Parse(ddlCategoria.SelectedValue);
                    nuevoCliente.email = TxtEmail.Text;
                    nuevoCliente.direccion = TxtDireccion.Text;

                    negocio.Agregar(nuevoCliente);

                    nuevoCliente = negocio.ListarProveedor().Find(x => x.codigo == nuevoCliente.codigo);

                    Session.Add("ClienteTemp", nuevoCliente);
                    guardarForm();

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