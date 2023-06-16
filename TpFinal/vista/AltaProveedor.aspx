<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AltaProveedor.aspx.cs" Inherits="vista.AltaProveedor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container mt-5">
        <div class="row justify-content-md-center">
            <div class="col-lg-4 text-center">
                <h1>Proveedor Nuevo</h1>
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
                                <input type="text" class="form-control" placeholder="Código Proveedor" aria-label="CodigoProveedor" aria-describedby="basic-addon1">
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="input-group mb-3">
                                <span class="input-group-text" id="lblCuit">CUIT</span>
                                <input type="text" class="form-control" placeholder="12-34567890-9" aria-label="Cuit" aria-describedby="basic-addon1">
                            </div>
                        </div>
                        <div class="col-md-12">
                            <div class="input-group mb-3">
                                <span class="input-group-text" id="lblRazonSocial">Razón Social</span>
                                <input type="text" class="form-control" placeholder="Razón Social" aria-label="RazonSocial" aria-describedby="basic-addon1">
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="input-group mb-3">
                                <span class="input-group-text" id="lblCategoria">Categoría</span>
                                <asp:DropDownList ID="ddlCategoria" runat="server" CssClass="btn btn-outline-secondary">
                                    <asp:ListItem Selected="True" Value="Bebidas"></asp:ListItem>
                                    <asp:ListItem Value="Carnes"></asp:ListItem>
                                    <asp:ListItem Value="Varios"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="input-group mb-3">
                                <span class="input-group-text" id="lblTelefono">Telefono</span>
                                <input type="tel" class="form-control" placeholder="11-1111-1111" aria-label="Telefono" aria-describedby="basic-addon1">
                            </div>
                        </div>
                        <div class="col-md-10">
                            <div class="input-group mb-3">
                                <span class="input-group-text" id="lblEmail">Email</span>
                                <input type="text" class="form-control" placeholder="Ejemplo@mail.com" aria-label="EmailProveedor" aria-describedby="basic-addon1">
                            </div>
                        </div>
                        <div class="col-md-12">
                            <div class="input-group mb-3">
                                <span class="input-group-text" id="lblDireccion">Dirección</span>
                                <input type="text" class="form-control" placeholder="Av. Siempreviva 742 - Springfield" aria-label="DireccionCliente" aria-describedby="basic-addon1">
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
