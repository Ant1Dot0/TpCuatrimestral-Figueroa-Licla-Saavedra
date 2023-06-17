<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ListaProductos.aspx.cs" Inherits="vista.ListaProductos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container mt-4" style="height: 198px">
        <div class="row justify-content-center">
            <div class="col-md-auto text-center">
                <h1>Productos</h1>
            </div>
        </div>
        <div class="row justify-content-end">
            <div class="col-md-4 text-center">
                <a href="AltaArticulo.aspx" class="btn btn-primary">Nuevo Producto</a>
            </div>
        </div>
        <%foreach (var x in productos)
            {%>
        <div class="card  text-bg-info my-3">
            <div class="row g-0">
                <div class="col-md-2">
                    <img src="https://static.vecteezy.com/system/resources/previews/004/141/669/non_2x/no-photo-or-blank-image-icon-loading-images-or-missing-image-mark-image-not-available-or-image-coming-soon-sign-simple-nature-silhouette-in-frame-isolated-illustration-vector.jpg" class="img-fluid rounded-start" alt="...">
                </div>
                <div class="col-md-7">
                    <div class="card-body">
                        <h5 class="card-title"><%=x.descripcion %> (<%=x.codigo%>)</h5>
                        <p class="card-text">Marca: <%=x.marca.descripcion %></p>
                        <p class="card-text">Categoría: <%=x.categoria.descripcion %></p>
                    </div>
                </div>
                <div class="col-md-3 mt-3">
                    <p class="card-text">Stock Actual: <%=x.stockActual %></p>
                    <p class="card-text">stock mínimo: <%=x.stockMinimo %></p>
                    <p class="card-text">Precio de compra: <%=x.precioCompra %></p>
                    <p class="card-text">Ganancia: <%=x.ganacia %></p>
                </div>
            </div>
        </div>
        <%} %>
    </div>
</asp:Content>
