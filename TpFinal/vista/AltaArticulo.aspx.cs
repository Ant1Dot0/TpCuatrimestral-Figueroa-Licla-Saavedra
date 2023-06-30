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
        protected void Page_Load(object sender, EventArgs e)
        {
            proveedores = new ProveedorNegocio().ListarProveedor();
            auxProductoSeleccionado.codigo = "CEMOE05";
            ListarProveedoresSeleccionados();
        }

        void ListarProveedoresSeleccionados()
        {
            auxProveedoresSeleccionados.Clear();
            List<ProveedorxProducto> auxDetalle = new ProveedorxProductoNegocio().Listar();

            foreach (ProveedorxProducto aux in auxDetalle)
            {
                if (aux.codigoProducto == auxProductoSeleccionado.codigo)
                {
                    auxProveedoresSeleccionados.Add(aux);
                }
            }
        }
    }
}