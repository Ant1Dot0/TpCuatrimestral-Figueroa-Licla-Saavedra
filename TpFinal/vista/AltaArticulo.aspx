<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AltaArticulo.aspx.cs" Inherits="vista.AltaArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
        <div class="row justify-content-md-center">
            <div class="col-lg-4 text-center">
                <h1>Producto nuevo</h1>
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
                                <input type="text" class="form-control" placeholder="Código Producto" aria-label="CodigoArticulo" aria-describedby="basic-addon1">
                            </div>
                        </div>
                        <div class="col-md-8">
                            <div class="input-group mb-3">
                                <span class="input-group-text" id="lblDescripcion">Descripción</span>
                                <input type="text" class="form-control" placeholder="Descripción" aria-label="DescripcionArticulo" aria-describedby="basic-addon1">
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="input-group mb-3">
                                <span class="input-group-text" id="lblMarca">Marca</span>
                                <asp:DropDownList ID="ddlMarca" runat="server" CssClass="btn btn-outline-secondary">
                                    <asp:ListItem Selected="True" Value="Chirolita"></asp:ListItem>
                                    <asp:ListItem Value="Random"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="col-md-6">
                            <div class="input-group mb-3">
                                <span class="input-group-text" id="lblCategoria">Categoría</span>
                                <asp:DropDownList ID="ddlCategoria" runat="server" CssClass="btn btn-outline-secondary">
                                    <asp:ListItem Selected="True" Value="Chirolita"></asp:ListItem>
                                    <asp:ListItem Value="Random"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="input-group mb-3">
                                <span class="input-group-text" id="lblPrecioCompra">Precio $</span>
                                <input type="number" class="form-control" placeholder="$9999" aria-label="Precio" aria-describedby="basic-addon1">
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="input-group mb-3">
                                <span class="input-group-text" id="lblGanancia">Ganancia %</span>
                                <input type="number" class="form-control" placeholder="100%" aria-label="Ganancia" aria-describedby="basic-addon1">
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="input-group mb-3">
                                <span class="input-group-text" id="lblStockActual">Stock</span>
                                <input type="number" class="form-control" placeholder="999" aria-label="Stock" aria-describedby="basic-addon1">
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="input-group mb-3">
                                <span class="input-group-text" id="lblStockMinimo">StockMinimo</span>
                                <input type="number" class="form-control" placeholder="999" aria-label="StockMinimo" aria-describedby="basic-addon1">
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
