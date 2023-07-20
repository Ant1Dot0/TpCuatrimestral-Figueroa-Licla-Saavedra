<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ListaCompra.aspx.cs" Inherits="vista.ListaCompra" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="container mt-4" style="height: 198px">
        <div class="row justify-content-center">
            <div class="col-md-auto text-center">
                <h1>Compras</h1>
            </div>
        </div>
        <div class="row justify-content-end">
            <div class="col-md-4 text-end">
                <%if (Session["User"] != null && ((Dominio.Usuario)Session["User"]).rol.descripcion == Dominio.TipoRol.ADMIN.ToString())
                    {%>

                     <asp:Button ID="btnNuevaCompra" runat="server" CssClass="btn btn-primary" Text="Nueva Compra" OnClick="btnNuevaCompra_Click" />

                <%} %>
            </div>
        </div>
        <div class="row justify-content-center mt-2">
            <div class="col-md-10">
                <asp:GridView ID="gvCompras" CssClass="table table-dark" OnSelectedIndexChanged="gvCompras_SelectedIndexChanged" runat="server" AutoGenerateColumns="false" DataKeyNames="ID">
                    <Columns>
                        <asp:BoundField HeaderText="numero" DataField="codigo" />
                        <asp:BoundField HeaderText="Proveedor" DataField="proveedor" />
                        <asp:BoundField HeaderText="Total" DataField="TotalComprobante" />
                        <asp:CommandField ShowSelectButton="true" SelectText="✔️" HeaderText=" " />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
