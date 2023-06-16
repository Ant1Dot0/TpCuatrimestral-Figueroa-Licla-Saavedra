<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ListaMarcasProductos.aspx.cs" Inherits="vista.ListaMarcasProductos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="container mt-4" style="height: 198px">
        <div class="row justify-content-center">
            <div class="col-md-auto text-center">
                <h1>Marcas de Productos</h1>
            </div>
        </div>
        <div class="row justify-content-end">
            <div class="col-md-4 text-center">
                <a href="AltaMarcaProducto.aspx" class="btn btn-primary">Nueva Marca</a>
            </div>
        </div>
        <div class="row justify-content-center mt-2">
            <div class="col-md-10">
                <asp:GridView ID="GridViewMarca" CssClass="table table-dark" runat="server" AutoGenerateColumns="false" DataKeyNames="ID">
                    <Columns>
                        <asp:BoundField HeaderText="ID" DataField="ID" />
                        <asp:BoundField HeaderText="Codigo" DataField="codigo" />
                        <asp:BoundField HeaderText="Descripción" DataField="descripcion" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
