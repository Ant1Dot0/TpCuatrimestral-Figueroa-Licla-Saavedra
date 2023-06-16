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
    public partial class ListaProductos : System.Web.UI.Page
    {
        public List<Producto> productos;
        protected void Page_Load(object sender, EventArgs e)
        {
            productos = new ProductoNegocio().listar();
           /* Producto aux = new Producto();
            Producto aux2 = new Producto();
            aux.codigo = "S001";
            aux.descripcion = "samsung S001";
            aux.precioCompra = 1500;
            aux.id = 1;

            aux2.codigo = "S002";
            aux2.descripcion = "samsung S002";
            aux2.precioCompra = 1800;
            aux2.id = 2;

            productos.Add(aux);
            productos.Add(aux2);*/
            
        }
    }
}