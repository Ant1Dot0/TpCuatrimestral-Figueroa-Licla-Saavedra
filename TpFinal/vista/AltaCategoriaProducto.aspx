<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AltaCategoriaProducto.aspx.cs" Inherits="vista.AltaCategoriaProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
        <div class="row justify-content-md-center">
            <div class="col-lg-4 text-center">
                <h1>Nueva Categoría Producto</h1>
            </div>
        </div>
        <div class="row justify-content-md-center ">
            <div class="card col-md-10">
                <div class="card-header text-center">
                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary mb-1" />
                    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger mb-1" />
                    <asp:Button ID="btnGuardarComo" runat="server" Text="Guardar Como" CssClass="btn btn-secondary mb-1" />
                    <asp:Button ID="btnLista" runat="server" Text="Ver Lista" CssClass="btn btn-success mb-1" />
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-md-4">
                            <div class="input-group mb-3">
                                <span class="input-group-text" id="lblCodigo">Codigo</span>
                                <input type="text" class="form-control" placeholder="Código Categoría" aria-label="CodigoCategoria" aria-describedby="basic-addon1">
                            </div>
                        </div>
                        <div class="col-md-8">
                            <div class="input-group mb-3">
                                <span class="input-group-text" id="lblDescripcion">Descripción</span>
                                <input type="text" class="form-control" placeholder="Descripción" aria-label="DescripcionCAtegoria" aria-describedby="basic-addon1">
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
