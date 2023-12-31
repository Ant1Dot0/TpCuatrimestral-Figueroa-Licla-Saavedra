﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace vista
{
    public partial class AltaVenta : System.Web.UI.Page
    {
        public Cliente ClienteCompVenta = new Cliente();
        public List<DetalleProducto> detProductosVenta = new List<DetalleProducto>();
        public Usuario vendedor = new Usuario();
        public int totalCantidad = 0;
        public decimal total = 0;
        public int totalItems = 0;


        public DateTime hoy = DateTime.Today;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["ClienteCompVenta"] != null)
                {
                    ClienteCompVenta = (Cliente)Session["ClienteCompVenta"];
                }

                if (Session["DetProductosVenta"] != null)
                {
                    detProductosVenta = (List<DetalleProducto>)Session["DetProductosVenta"];
                }
                if (Session["User"] != null)
                {
                    vendedor = (Usuario)Session["User"];
                }

                gvProductos.DataSource = detProductosVenta;

                TxtVendedor.Text = vendedor.ToString();

                totalCantidad = 0;
                total = 0;
                totalItems = 0;

                foreach (DetalleProducto x in detProductosVenta)
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

                throw ex;
            }


        }

        protected void cargarForm()
        {
            try
            {
                if (ClienteCompVenta.id > 0)
                TxtCliente.Text = ClienteCompVenta.codigo + " - " + ClienteCompVenta.nombre + " " + ClienteCompVenta.apellido;
                TxtVendedor.Text = vendedor.ToString();
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
                Talonario auxTalonario = new TalonarioNegocio().Listar().Find(x => x.pdv == 1 && x.tipoComprobante == 1);
                auxTalonario.ultNumero++;
                int numero = auxTalonario.ultNumero;
                int pdv = 1;
                total = 0;
                List<Producto> productos = new ProductoNegocio().listar();

                string codComprobante = obtCodPdv(pdv) + "-" + obtCodNumero(numero);

                foreach (DetalleProducto x in detProductosVenta)
                {
                    x.codComprobante = codComprobante;
                }

                CompVenta nueva = new CompVenta();

                nueva.codigo = codComprobante;
                nueva.puntoVenta = pdv;
                nueva.numero = numero;
                nueva.cliente = ClienteCompVenta;
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

                foreach (DetalleProducto x in detProductosVenta)
                {
                    new DetalleProductoNegocio().Agregar(x);
                    total += x.monto;
                    Producto auxP = productos.Find(a => a.codigo == x.codProducto);

                    auxP.stockActual -= x.cantidad;

                    new ProductoNegocio().Editar(auxP);
                }

                

                nueva.subtotal = total;
                nueva.totalDescuento = 0;
                nueva.descuentoComp = 0;
                nueva.totalComprobante = total;

                new VentaNegocio().Agregar(nueva);
                new TalonarioNegocio().Editar(auxTalonario);

                borrarSession();
                Response.Redirect("ListaVentas.aspx");
            }
            catch (Exception ex)
            {

                Session.Add("Error.aspx", ex.Message);
            }

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            borrarSession();
            Response.Redirect("ListaVentas.aspx");
        }

        protected void borrarSession()
        {
            try
            {
                Session.Add("ClienteCompVenta", null);
                Session.Add("DetProductosVenta", null);
                Session.Add("ProductosSeleccionados", null);
                Session.Add("ClienteTemp", null);
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