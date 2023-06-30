<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AltaCliente.aspx.cs" Inherits="vista.AltaCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
        <div class="row justify-content-md-center">
            <div class="col-lg-4 text-center">
                <h1>Cliente Nuevo</h1>
            </div>
        </div>
        <div class="row justify-content-md-center ">
            <div class="card col-md-10">
                <div class="card-header text-center">
                    <asp:Button ID="btnGuardar" runat="server" OnClick="btnGuardar_Click" Text="Guardar" CssClass="btn btn-primary mb-1" />
                    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" CssClass="btn btn-danger mb-1" />
                    <asp:Button ID="btnGuardarComo" runat="server" Text="Guardar Como" CssClass="btn btn-secondary mb-1" />
                    <asp:Button ID="btnLista" runat="server" Text="Ver Lista" CssClass="btn btn-success mb-1" />
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-md-4">
                            <div class="input-group mb-3">
                                <asp:Label ID="LblCodigo" runat="server" Text="Codigo"></asp:Label>
                                <asp:TextBox ID="TxtCodigo" CssClass="form-control"  runat="server"></asp:TextBox>
                               
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="input-group mb-3">
                                <asp:Label ID="LblDNI" runat="server" Text="Documento"></asp:Label>
                                <asp:TextBox ID="TxtDNI" CssClass="form-control"  runat="server"></asp:TextBox>
                               
                            </div>
                        </div>
                        <div class="col-md-10">
                            <div class="input-group mb-3">
                                <asp:Label ID="lblNombre" runat="server" Text="Nombre"></asp:Label>
                                <asp:TextBox ID="TxtNombre" CssClass="form-control"  runat="server"></asp:TextBox>
                                
                            </div>
                        </div>
                        <div class="col-md-10">
                            <div class="input-group mb-3">
                                <asp:Label ID="lblApellido" runat="server" Text="Apellido"></asp:Label>
                                <asp:TextBox ID="TxtApellido" CssClass="form-control"  runat="server"></asp:TextBox>                      
                            </div>
                        </div>

                        <div class="col-md-6">
                            <div class="input-group mb-3">
                                 <asp:Label ID="lblCategoria" runat="server" Text="Categoria"></asp:Label>
                                <asp:DropDownList ID="ddlCategoria" runat="server" CssClass="btn btn-outline-secondary">
                                    <asp:ListItem Selected="True" Value="Importante"></asp:ListItem>
                                    <asp:ListItem Value="Personal"></asp:ListItem>
                                    <asp:ListItem Value="Común"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="input-group mb-3">
                                <asp:Label ID="LblTelefono" runat="server" Text="Telefono"></asp:Label>
                                <asp:TextBox ID="TxtTelefono" CssClass="form-control"  runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-10">
                            <div class="input-group mb-3">
                                <asp:Label ID="LblEmail" runat="server" Text="Email"></asp:Label>
                                <asp:TextBox ID="TxtEmail" CssClass="form-control"  runat="server"></asp:TextBox>
                                
                            </div>
                        </div>
                        <div class="col-md-12">
                            <div class="input-group mb-3">
                                <asp:Label ID="lblDireccion" runat="server" Text="Direccion"></asp:Label>
                                <asp:TextBox ID="TxtDireccion" CssClass="form-control"  runat="server"></asp:TextBox>  
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
