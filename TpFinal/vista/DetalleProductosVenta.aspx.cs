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
    public partial class DetalleProductosVenta : System.Web.UI.Page
    {
        public List<DetalleProducto> productosSeleccionados = new List<DetalleProducto>();
        public List<Producto> lista = new List<Producto>();
        public decimal DetTotal = 0;
        public decimal DetTotalCantidad = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["User"] == null)
                {
                    Response.Redirect("InicioSesion.aspx", false);
                }

                lista = new ProductoNegocio().listar();

                if (Session["ProductosSeleccionados"] != null)
                {
                    productosSeleccionados = recListDet("ProductosSeleccionados");
                }
                else if (Session["DetProductosVenta"] != null)
                {
                    productosSeleccionados = recListDet("DetProductosVenta");

                }

                gvProductos.DataSource = lista;
                DetTotal = 0;
                DetTotalCantidad = 0;
                foreach (DetalleProducto aux in productosSeleccionados)
                {
                    DetTotal += aux.monto;
                    DetTotalCantidad += aux.cantidad;

                }

                txtTotal.Text = "$ " + DetTotal;
                TxtTotCantidad.Text = "" + DetTotalCantidad;


                gvProductosSeleccionados.DataSource = productosSeleccionados;

                if (!IsPostBack)
                {
                    DataBind();
                }

            }
            catch (Exception ex)
            {

                Session.Add("Error.aspx", ex.Message);
            }


        }


        protected List<DetalleProducto> recListDet(string s)
        {
            List<DetalleProducto> aux = new List<DetalleProducto>();
            List<DetalleProducto> aux2 = new List<DetalleProducto>();

            aux2 = (List<DetalleProducto>)Session[s];

            int cont = 0;

            for(int x = 0; x < aux2.Count; x++)
            {
                DetalleProducto aux3 = new DetalleProducto();
                aux3.codComprobante =  aux2[cont].codComprobante;
                aux3.codProducto = aux2[cont].codProducto;
                aux3.cantidad = (int)aux2[cont].cantidad;
                aux3.estado = aux2[cont].estado;
                aux3.montoDescuento = (decimal)aux2[cont].montoDescuento;
                aux3.monto = (decimal)aux2[cont].monto;
                aux3.id = (int)aux2[cont].id;
                aux3.descripcion = aux2[cont].descripcion;
                aux3.precioVenta = (decimal) aux2[cont].precioVenta;

                aux.Add(aux3);
                cont++;
            }

        /*    foreach (DetalleProducto x in aux2)
            {


                aux3.codComprobante = x.codComprobante;
                aux3.codProducto = x.codProducto;
                aux3.cantidad = x.cantidad;
                aux3.estado = x.estado;
                aux3.montoDescuento = x.montoDescuento;
                aux3.monto = x.monto;
                aux3.id = x.id;
                aux3.descripcion = x.descripcion;
                aux3.precioVenta = x.precioVenta;

                aux.Add(aux3);
            }*/
            return aux;
        }

        protected void guardarForm()
        {
            DetalleProducto auxDet = new DetalleProducto();
        }

        protected void guardarSession()
        {
            Session.Add("ProductosSeleccionados", productosSeleccionados);
        }

        protected void borrarSession()
        {
            Session.Add("ProductosSeleccionados", null);
        }

        protected void gvProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string codigo = gvProductos.SelectedDataKey.Value.ToString();
            Producto auxProducto = (lista.Find(x => x.codigo == codigo));
            DetalleProducto auxDet = new DetalleProducto();

            int indx = productosSeleccionados.FindIndex(x => x.codProducto == codigo);

            if (indx != -1)
            {
                productosSeleccionados[indx].cantidad++;
                productosSeleccionados[indx].monto = productosSeleccionados[indx].precioVenta * productosSeleccionados[indx].cantidad;
            }
            else
            {
                auxDet.codProducto = auxProducto.codigo;
                auxDet.cantidad = 1;
                auxDet.descripcion = auxProducto.descripcion;
                auxDet.precioVenta = auxProducto.precioCompra * ((100 + auxProducto.ganacia) / 100);
                auxDet.monto = auxDet.precioVenta;
                productosSeleccionados.Add(auxDet);
            }

            guardarSession();
            Response.Redirect("DetalleProductosVenta.aspx");

        }

        protected void TxtFiltro_TextChanged(object sender, EventArgs e)
        {
            List<Producto> listaFiltrada = lista.FindAll(x => x.descripcion.ToUpper().Contains(TxtFiltro.Text.ToUpper()));
            gvProductos.DataSource = listaFiltrada;
            gvProductos.DataBind();
        }

        protected void TxtCantidad_TextChanged(object sender, EventArgs e)
        {
            int cantidad = gvProductosSeleccionados.Rows.Count;
            TextBox txt = new TextBox();


            for (int x = 0; x < cantidad; x++)
            {
                txt = (TextBox)(gvProductosSeleccionados.Rows[x].FindControl("TxtCantidad"));
                productosSeleccionados[x].cantidad = int.Parse(txt.Text);
                productosSeleccionados[x].monto = productosSeleccionados[x].cantidad * productosSeleccionados[x].precioVenta;
            }

            guardarSession();
            Response.Redirect("DetalleProductosVenta.aspx");

        }

        protected void TxtPrecio_TextChanged(object sender, EventArgs e)
        {

            int cantidad = gvProductosSeleccionados.Rows.Count;
            TextBox txt = new TextBox();

            for (int x = 0; x < cantidad; x++)
            {
                txt = (TextBox)(gvProductosSeleccionados.Rows[x].FindControl("TxtPrecio"));
                productosSeleccionados[x].precioVenta = decimal.Parse(txt.Text);
                productosSeleccionados[x].monto = productosSeleccionados[x].cantidad * productosSeleccionados[x].precioVenta;
            }

            guardarSession();
            Response.Redirect("DetalleProductosVenta.aspx");
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {

            Session.Add("DetProductosVenta", productosSeleccionados);

            Response.Redirect("AltaVenta.aspx");
        }

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            borrarSession();
            Response.Redirect("AltaVenta.aspx");
        }

        protected void gvProductosSeleccionados_SelectedIndexChanged(object sender, EventArgs e)
        {
            string codigo = gvProductosSeleccionados.SelectedDataKey.Value.ToString();
            int indx = productosSeleccionados.FindIndex(x => x.codProducto == codigo);

            productosSeleccionados.RemoveAt(indx);

            guardarSession();
            Response.Redirect("DetalleProductosVenta.aspx");
        }
    }
}