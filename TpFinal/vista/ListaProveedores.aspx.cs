using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;
using System.IO;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;

namespace vista
{
    public partial class ListaProveedores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["User"] == null)
                {
                    Response.Redirect("InicioSesion.aspx", false);
                }


                ProveedorNegocio negocio = new ProveedorNegocio();
                GridViewProveedores.DataSource = negocio.ListarProveedor();
                DataBind();

                CategoriasProveedorNegocio categoriaProveedor = new CategoriasProveedorNegocio();
                List<CategoriaProveedor> Lista = categoriaProveedor.Listar();

                ddlCategoria.DataSource = Lista;
                ddlCategoria.DataValueField = "id";
                ddlCategoria.DataTextField = "descripcion";
                DataBind();


            }
            catch (Exception ex)
            {

                throw ex;
            }

            /****************************************************************************/
            /*ALTERNATIVA*/
            /*
            string strQuery = "SELECT [codigo],[razonSocial][cuit] from Proveedor";
            SqlCommand cmd = new SqlCommand(strQuery);
            DataTable dt;
            dt = GetData(cmd);
            GridView1.DataSource = dt;
            GridView1.DataBind();


            /****************************************************************************/
        }
        /*
        private DataTable GetData(SqlCommand cmd)
        {
            DataTable dt = new DataTable();
            string strconn

        }
        */



        /*CONFIGURAR BOTON AGREGAR PROVEEDOR*/

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            ProveedorNegocio Negocio = new ProveedorNegocio();

            try
            {
                Proveedor Nuevo = new Proveedor();
                Nuevo.codigo = (string)(TxtCodigo.Text);
                Nuevo.razonSocial = TxtRazonSocial.Text;
                Nuevo.cuit = TxtCuit.Text;
                Nuevo.categoria = new CategoriaProveedor();
                Nuevo.telefono = TxtTelefono.Text;
                Nuevo.email = TxtEmail.Text;
                Nuevo.direccion = TxtDireccion.Text;
                
               

                Negocio.Agregar(Nuevo);
                Response.Redirect("ListaProveedores.aspx", false);

            }
            catch (Exception ex)
            {

                throw ex;
            }




        }


        /*---------------------------------------------*/

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListaProovedores.aspx", false);
        }

        protected void GridViewProveedores_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = GridViewProveedores.SelectedDataKey.Value.ToString();
            Response.Redirect("AltaProveedor.aspx?id=" + id, false);
        }


        public override void VerifyRenderingInServerForm(Control control)
        {

        }


        protected void btnExportarExcel_Click(object sender, EventArgs e)
        {
           

            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            Response.AddHeader("content-disposition","attachment;filename=GridViewExport.xls");
            Response.ContentType = "application/ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            GridViewProveedores.AllowPaging = false;
            GridViewProveedores.DataBind();
            
            GridViewProveedores.RenderControl(hw);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();




        }
    }



}