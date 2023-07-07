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
            <div class="col-md-4 text-end">
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
                        <p class="card-text">Precio de compra: <%=x.precioCompra %></p>
                    </div>
                </div>
                <div class="col-md-3 mt-3">
                    <p class="card-text">Stock Actual: <%=x.stockActual %></p>
                    <p class="card-text">stock mínimo: <%=x.stockMinimo %></p>
                    <p class="card-text">Ganancia: <%=x.ganacia %></p>
                    <p>
                        <button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#staticBackdrop" onclick='guardarID(<%=x.id %>)'>Eliminar</button></p>
                </div>
            </div>
        </div>
        <%} %>
        <!--------------------------------------INICIO MODAL------------------------------------------>
        <div class="modal fade" id="staticBackdrop" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h1 class="modal-title fs-5" id="staticBackdropLabel">Advertencia!</h1>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div class="modal-body">
                        ¿Está seguro de eliminar el producto?
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-danger" onclick='ConfirmaEliminar()'>Sí</button>
                        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">No</button>

                    </div>
                </div>
            </div>
        </div>
        <!--------------------------------------FIN MODAL------------------------------------------>

    </div>
</asp:Content>
