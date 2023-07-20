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
    public partial class ListaCategoriaCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["User"] == null)
                {
                    Response.Redirect("InicioSesion.aspx", false);
                }

                CategoriasClienteNegocio negocio = new CategoriasClienteNegocio();
                GridViewCategoria.DataSource = negocio.Listar();
                DataBind();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


        protected void GridViewCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
           var id = GridViewCategoria.SelectedDataKey.Value.ToString();
           Response.Redirect("AltaCategoriaCliente.aspx?id=" + id, false);
        }

        public override void VerifyRenderingInServerForm(Control control)
        {

        }

        protected void btnExportarExcel_Click(object sender, EventArgs e)
        {


            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.xls");
            Response.ContentType = "application/ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            GridViewCategoria.AllowPaging = false;
            GridViewCategoria.DataBind();
            GridViewCategoria.RenderControl(hw);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();




        }

        protected void btnExportarPdf_Click(object sender, EventArgs e)
        {
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            GridViewCategoria.AllowPaging = false;
            GridViewCategoria.DataBind();
            GridViewCategoria.RenderControl(hw);
            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            htmlparser.Parse(sr);
            pdfDoc.Close();
            Response.Write(pdfDoc);
            Response.End();



        }

    }
}