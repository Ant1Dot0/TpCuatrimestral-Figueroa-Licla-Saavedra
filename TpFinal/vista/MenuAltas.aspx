<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="MenuAltas.aspx.cs" Inherits="vista.MenuAltas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container  mt-5">
        <div class="row">
            <div class="row justify-content-md-center">
                <div class="col-lg-4 text-center">
                    <h1>Altas</h1>
                </div>
            </div>
        </div>
        <div class="row justify-content-md-center">
            <div class="card col-lg-4 text-center">

                    <a href="ListaClientes.aspx" class="btn btn-secondary mb-2 mt-2">Clientes</a>
                    <a href="ListaProductos.aspx" class="btn btn-secondary mb-2">Productos</a>
                    <a href="ListaProveedores.aspx" class="btn btn-secondary mb-2">Proveedores</a>
                    <a href="ListaCategoriaCliente.aspx" class="btn btn-secondary mb-2">Categorías Cliente</a>
                    <a href="ListacategoriaProducto.aspx" class="btn btn-secondary mb-2">Categorías Productos</a>
                    <a href="ListaCategoriaProveedor.aspx" class="btn btn-secondary mb-2">Categorías Proveedores </a>
                    <a href="ListaMarcasProductos.aspx" class="btn btn-secondary mb-2">Marcas Productos</a>

            </div>
        </div>
    </div>
</asp:Content>
