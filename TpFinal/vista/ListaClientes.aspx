<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" enableEventValidation ="false"  CodeBehind="ListaClientes.aspx.cs" Inherits="vista.ListaClientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container mt-4" style="height: 198px">
        <div class="row justify-content-center">
            <div class="col-md-auto text-center">
                <h1>Clientes</h1>
            </div>
        </div>
        <div class="row justify-content-end">
            <div class="col-md-4 text-end">
                <%if (Session["User"] != null && ((Dominio.Usuario)Session["User"]).rol.descripcion == Dominio.TipoRol.ADMIN.ToString())
                    {%>
                            <a href="AltaCliente.aspx" class="btn btn-primary">Nuevo Cliente</a>
                <%} %>
            </div>
        </div>

        <!-----------------------------------------INICIO LISTADO------------------------------>
               <div class="row justify-content-center mt-2">
            <div class="col-md-10">
                <asp:GridView ID="GridViewClientes" CssClass="table table-dark" runat="server" OnSelectedIndexChanged="GridViewClientes_SelectedIndexChanged" AutoGenerateColumns="false" DataKeyNames="ID">
                    <Columns>
                        <asp:BoundField HeaderText="ID" DataField="ID" />
                        <asp:BoundField HeaderText="Nombre" DataField="nombre" />
                        <asp:BoundField HeaderText="NºDocumento" DataField="nDocumento" />
                        <asp:BoundField HeaderText="Email" DataField="email" />
                        <asp:CommandField ShowSelectButton="true" SelectText="✔️" HeaderText=" " />
                    </Columns>
                </asp:GridView>
            </div>
            <asp:Button ID="btnExportarExcel" runat="server" Text="Exportar a Excel" OnClick="btnExportarExcel_Click" />
            &nbsp;
            <asp:Button ID="btnExportarPdf" runat="server" Text="Exportar a Pdf" OnClick="btnExportarPdf_Click" />
        </div>
    <!---------------------------------------FIN LISTADO--------------------------------->



</asp:Content>
