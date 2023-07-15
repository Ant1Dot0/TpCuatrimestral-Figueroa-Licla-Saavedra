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
                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" CssClass="btn btn-primary mb-1" />

                    <%if (Session["User"] != null && ((Dominio.Usuario)Session["User"]).rol.descripcion == Dominio.TipoRol.ADMIN.ToString() && TxtCodigo.Text != null)
                        {%>

                        <asp:Button runat="server" ID="Button1" OnClick="btnEliminar_Click" Text="Eliminar" CssClass="btn btn-dark"/>

                    <%} %>

                    
                    <asp:Button ID="btnLista" runat="server" Text="Ver Lista" CssClass="btn btn-success mb-1" />
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-md-4">
                            <div class="input-group mb-3">
                                <span class="input-group-text" id="lblCodigo">Codigo</span>
                                <asp:TextBox ID="TxtCodigo" CssClass="form-control" runat="server"></asp:TextBox>
                                
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="input-group mb-3">
                                <span class="input-group-text" id="lblCuit">CUIT</span>
                                <asp:TextBox ID="TxtCuit" CssClass="form-control" runat="server"></asp:TextBox>
                                
                            </div>
                        </div>
                        <div class="col-md-12">
                            <div class="input-group mb-3">
                                <span class="input-group-text" id="lblRazonSocial">Razón Social</span>
                                <asp:TextBox ID="TxtRazonSocial" CssClass="form-control" runat="server"></asp:TextBox>
                                
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
                                <asp:TextBox ID="TxtTelefono" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-10">
                            <div class="input-group mb-3">
                                <span class="input-group-text" id="lblEmail">Email</span>
                                <asp:TextBox ID="TxtEmail" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <div class="input-group mb-3">
                                <span class="input-group-text" id="lblDireccion">Dirección</span>
                                <asp:TextBox ID="TxtDireccion" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
                    <a href="ListaProveedores.aspx" class="btn btn-danger">Cancelar</a>
        </div>
    </div>
</asp:Content>
