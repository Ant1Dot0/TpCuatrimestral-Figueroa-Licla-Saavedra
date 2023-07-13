<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ListaVentas.aspx.cs" Inherits="vista.ListaVentas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="container mt-4" style="height: 198px">
        <div class="row justify-content-center">
            <div class="col-md-auto text-center">
                <h1>Ventas</h1>
            </div>
        </div>
        <div class="row justify-content-end">
            <div class="col-md-4 text-center">
                <%if (Session["User"] != null && ((Dominio.Usuario)Session["User"]).rol.descripcion == Dominio.TipoRol.ADMIN.ToString())
                    {%>

                     <a href="AltaVenta.aspx" class="btn btn-primary">Nuevo Venta</a>

                <%} %>
            </div>
        </div>
        <div class="row justify-content-center mt-2">
            <div class="col-md-10">
                <asp:GridView ID="gvVentas" CssClass="table table-dark" runat="server"  AutoGenerateColumns="false" DataKeyNames="ID">
                    <Columns>
                        <asp:BoundField HeaderText="numero" DataField="codigo" />
                        <asp:BoundField HeaderText="Cliente" DataField="cliente" />
                        <asp:BoundField HeaderText="Total" DataField="TotalComprobante" />
                        <asp:CommandField ShowSelectButton="true" SelectText="✔️" HeaderText=" " />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
