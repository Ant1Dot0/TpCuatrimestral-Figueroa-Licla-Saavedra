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
    public partial class DetalleProductosVenta : System.Web.UI.Page
    {
        public List<DetalleProducto> productosSeleccionados = new List<DetalleProducto>();
        public List<Producto> lista = new List<Producto>();
        public decimal DetTotal = 0;
        public decimal DetTotalCantidad = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            lista = new ProductoNegocio().listar();

            if(Session["ProductosSeleccionados"] != null)
            {
                productosSeleccionados = (List<DetalleProducto>)Session["ProductosSeleccionados"];
            }
            else if(Session["DetProductosVenta"] != null)
            {
                productosSeleccionados = (List<DetalleProducto>)Session["DetProductosVenta"];

            }
            prueba();

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

            if(!IsPostBack)
            {
                DataBind();
            }


        }

        protected void prueba()
        {
            if (Session["DetProductosVenta"] != null)
            {
                List<DetalleProducto> prueba = new List<DetalleProducto>();
                prueba = (List<DetalleProducto>)(Session["DetProductosVenta"]);
                decimal prueba2 = 0;
                foreach (DetalleProducto x in prueba)
                {
                    prueba2 += x.monto;
                }
                prueba2++;
            }

            
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