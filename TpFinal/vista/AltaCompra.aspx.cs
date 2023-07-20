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
    public partial class AltaCompra : System.Web.UI.Page
    {
        public Proveedor ProveedorCompCompra = new Proveedor();
        public List<DetalleProducto> detProductosCompra = new List<DetalleProducto>();
        public Usuario vendedor = new Usuario();
        public int totalCantidad = 0;
        public decimal total = 0;
        public int totalItems = 0;

        public string numero;
        public string pdv;

        public DateTime hoy = DateTime.Today;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["User"] == null)
                {
                    Response.Redirect("InicioSesion.aspx", false);
                }


                if (Session["ProveedorCompCompra"] != null)
                {
                    ProveedorCompCompra = (Proveedor)Session["ProveedorCompCompra"];
                }

                if (Session["DetProductosCompra"] != null)
                {
                    detProductosCompra = (List<DetalleProducto>)Session["DetProductosCompra"];
                }

                if (Session["User"] != null)
                {
                    vendedor = (Usuario)Session["User"];
                }

                if (Session["Numero"] != null)
                {
                    numero = (string)Session["Numero"];
                }

                if (Session["pdv"] != null)
                {
                    pdv = (string)Session["pdv"];
                }

                gvProductos.DataSource = detProductosCompra;

                total = 0;
                totalCantidad = 0;
                totalItems = 0;

                foreach (DetalleProducto x in detProductosCompra)
                {
                    totalCantidad += x.cantidad;
                    total += x.monto;
                    totalItems++;
                }

                txtTotalCantidad.Text = "" + totalCantidad;
                TxtTotalItems.Text = "" + totalItems;

                if (!IsPostBack)
                {
                    cargarForm();
                    DataBind();
                }
            }
            catch (Exception ex)
            {

                Session.Add("Error.aspx", ex.Message);
            }


            
        }

        protected void cargarForm()
        {
            try
            {
                if (ProveedorCompCompra.id > 0)
                    TxtProveedor.Text = ProveedorCompCompra.codigo + " - " + ProveedorCompCompra.razonSocial;
                TxtVendedor.Text = vendedor.ToString();
                TxtNumero.Text = numero;
                TxtPdv.Text = pdv;
            }
            catch (Exception ex)
            {

                Session.Add("Error.aspx", ex.Message);
            }

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                total = 0;
                List<Producto> productos = new ProductoNegocio().listar();

                string codComprobante = obtCodPdv(int.Parse(pdv)) + "-" + obtCodNumero(int.Parse(numero)) + " - " + ProveedorCompCompra.codigo;

                foreach (DetalleProducto x in detProductosCompra)
                {
                    x.codComprobante = codComprobante;
                }

                CompCompra nueva = new CompCompra();

                nueva.codigo = codComprobante;
                nueva.puntoVenta = pdv;
                nueva.numero = numero;
                nueva.proveedor = ProveedorCompCompra;
                nueva.fechaComp = hoy;

                if (Session["User"] != null)
                {
                    nueva.vendedor = (Usuario)Session["User"];
                }
                else
                {
                    Session.Add("error", "CREDENCIALES INCORRECTAS");
                    Response.Redirect("error.aspx", false);
                }

                foreach (DetalleProducto x in detProductosCompra)
                {
                    new DetalleProductosCompraNegocio().Agregar(x);
                    total += x.monto;

                    Producto auxP = productos.Find(a => a.codigo == x.codProducto);

                    auxP.stockActual += x.cantidad;

                    new ProductoNegocio().Editar(auxP);
                }

                nueva.subtotal = total;
                nueva.totalDescuento = 0;
                nueva.descuentoComp = 0;
                nueva.totalComprobante = total;

                new CompraNegocio().Agregar(nueva);

                borrarSession();
                Response.Redirect("ListaCompra.aspx");
            }
            catch (Exception ex)
            {

                Session.Add("Error.aspx", ex.Message);
            }

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                borrarSession();
                Response.Redirect("Listacompra.aspx");
            }
            catch (Exception ex)
            {

                Session.Add("Error.aspx", ex.Message);
            }

        }

        protected void borrarSession()
        {
            try
            {
                Session.Add("ProveedorCompCompra", null);
                Session.Add("DetProductosCompra", null);
                Session.Add("ProductosSeleccionadosC", null);
                Session.Add("proveedorTemp", null);
                Session.Add("pdvTemp", null);
                Session.Add("pdv", null);
                Session.Add("NumeroTemp", null);
                Session.Add("Numero", null);
            }
            catch (Exception ex)
            {

                Session.Add("Error.aspx", ex.Message);
            }

        }

        protected string obtCodNumero(int numero)
        {
            string codigo = "";
            if (numero < 10)
            {
                codigo = "0000000" + numero;
            }
            else if (numero < 100)
            {
                codigo = "000000" + numero;
            }
            else if (numero < 1000)
            {
                codigo = "00000" + numero;
            }
            else if (numero < 10000)
            {
                codigo = "0000" + numero;
            }
            else if (numero < 100000)
            {
                codigo = "000" + numero;
            }
            else if (numero < 1000000)
            {
                codigo = "00" + numero;
            }
            else if (numero < 10000000)
            {
                codigo = "0" + numero;
            }
            else if (numero < 100000000)
            {
                codigo = "" + numero;
            }

            return codigo;
        }

        protected string obtCodPdv(int n)
        {
            string codigo = "";

            if (n < 10)
            {
                codigo = "000" + n;
            }
            else if (n < 100)
            {
                codigo = "00" + n;
            }
            else if (n < 1000)
            {
                codigo = "0" + n;
            }
            else if (n < 10000)
            {
                codigo = "" + n;
            }

            return codigo;
        }
    }
}