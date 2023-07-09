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
    public partial class AltaArticulo : System.Web.UI.Page
    {
        public List<Proveedor> proveedores = new List<Proveedor>();
        public List<ProveedorxProducto> auxProveedoresSeleccionados = new List<ProveedorxProducto>();
        public Producto auxProductoSeleccionado = new Producto();
        public int accion = 0; // 0 para alta, 1 para editar.
        protected void Page_Load(object sender, EventArgs e)
        {

            if(Session["AccionProducto"] != null)
            {
                accion = int.Parse(Session["AccionProducto"].ToString());
            }

            if (Session["ProductoSelected"] != null)
            {
                auxProductoSeleccionado = (Producto)Session["ProductoSelected"];

            }

            if (Session["ProveedoresSelected"] != null)
            {
                auxProveedoresSeleccionados = (List<ProveedorxProducto>)Session["ProveedoresSelected"];
            }
            else
            {
                auxProveedoresSeleccionados = new ProveedorxProductoNegocio().ListarxProducto(auxProductoSeleccionado.codigo);
            }


            ddlCategoria.DataSource = new CategoriaArticuloNegocio().Listar();
            ddlCategoria.DataValueField = "id";
            ddlCategoria.DataTextField = "descripcion";


            ddlMarca.DataSource = new MarcaArticuloNegocio().Listar();
            ddlMarca.DataValueField = "id";
            ddlMarca.DataTextField = "descripcion";

            proveedores = proveedoresDisponibles();
            gvProveedores.DataSource = proveedores;

            if (!IsPostBack)
            {
                repProveedores.DataSource = auxProveedoresSeleccionados;
                DataBind();
                cargarForm();
            }


        }

        protected List<Proveedor> proveedoresDisponibles()
        {
            List<Proveedor> auxProveedores = new ProveedorNegocio().ListarProveedor();
            List<Proveedor> lista = new List<Proveedor>();
            foreach (Proveedor aux in auxProveedores)
            {
                if (auxProveedoresSeleccionados.FindIndex(a => a.codigoProveedor == aux.codigo) == -1)
                {
                    lista.Add(aux);
                }
            }

            return lista;
        }
        protected void gvProveedores_SelectedIndexChanged(object sender, EventArgs e)
        {
            GrabarProducto();
            string codigo = gvProveedores.SelectedDataKey.Value.ToString();
            ProveedorxProducto aux = new ProveedorxProducto();

            if (auxProveedoresSeleccionados.FindIndex(a => a.codigoProveedor == codigo) == -1)
            {
                aux.codigo = auxProductoSeleccionado.codigo + "-" + codigo;
                aux.codigoProducto = auxProductoSeleccionado.codigo;
                aux.codigoProveedor = codigo;

                auxProveedoresSeleccionados.Add(aux);
            }


            
            guardarSession();
            Response.Redirect("AltaArticulo.aspx");
        }

        protected void gvProveedores_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void cargarForm()
        {
            
            TxtCodigoProducto.Text = auxProductoSeleccionado.codigo;
            if (accion==1)
            {
                TxtCodigoProducto.Enabled = false;
            }

            TxtDescripcion.Text = auxProductoSeleccionado.descripcion;
            ddlMarca.SelectedIndex = new MarcaArticuloNegocio().Listar().FindIndex(a => a.id == auxProductoSeleccionado.marca.id);
            ddlCategoria.SelectedIndex = new CategoriaArticuloNegocio().Listar().FindIndex(a => a.id == auxProductoSeleccionado.categoria.id);
            TxtPrecioCompra.Text = auxProductoSeleccionado.precioCompra.ToString();
            TxtGanancia.Text = auxProductoSeleccionado.ganacia.ToString();
            TxtStock.Text = auxProductoSeleccionado.stockActual.ToString();
            TxtStockMinimo.Text = auxProductoSeleccionado.stockMinimo.ToString();
        }
        protected void GrabarProducto()
        {
            auxProductoSeleccionado.codigo = TxtCodigoProducto.Text;
            auxProductoSeleccionado.descripcion = TxtDescripcion.Text;
            auxProductoSeleccionado.marca.id = int.Parse(ddlMarca.SelectedValue);
            auxProductoSeleccionado.categoria.id = int.Parse(ddlCategoria.SelectedValue);
            auxProductoSeleccionado.precioCompra = decimal.Parse(TxtPrecioCompra.Text);
            auxProductoSeleccionado.ganacia = decimal.Parse(TxtGanancia.Text);
            auxProductoSeleccionado.stockActual = decimal.Parse(TxtStock.Text);
            auxProductoSeleccionado.stockMinimo = decimal.Parse(TxtStockMinimo.Text);

        }

        protected void GrabarProveedores()
        {

        }

        protected void btnCloseTag_Click(object sender, EventArgs e)
        {
            string valor = ((Button)sender).CommandArgument;
            auxProveedoresSeleccionados.RemoveAt(auxProveedoresSeleccionados.FindIndex(a => a.codigo == valor));

            GrabarProducto();
            guardarSession();

            Response.Redirect("AltaArticulo.aspx");

        }

        protected void guardarSession()
        {
            Session.Add("ProveedoresSelected", auxProveedoresSeleccionados);
            Session.Add("ProductoSelected", auxProductoSeleccionado);

        }

        protected void BorrarSession()
        {
            Session.Add("ProveedoresSelected", null);
            Session.Add("ProductoSelected", null);
            Session.Add("AccionProducto", null);

        }


        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            GrabarProducto();
            if(accion == 1) // 1 para editar, 0 para guardar
            {
                new ProductoNegocio().Editar(auxProductoSeleccionado);
            }
            else
            {
                new ProductoNegocio().Agregar(auxProductoSeleccionado);
            }
            

            new ProveedorxProductoNegocio().EliminarxProducto(auxProductoSeleccionado.codigo);

            foreach (ProveedorxProducto x in auxProveedoresSeleccionados)
            {
                new ProveedorxProductoNegocio().Agregar(x);
            }

            BorrarSession();
            Response.Redirect("ListaProductos.aspx");
        }

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            BorrarSession();
            Response.Redirect("ListaProductos.aspx");
        }


    }
}