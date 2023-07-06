<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ListaClientes.aspx.cs" Inherits="vista.ListaClientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container mt-4" style="height: 198px">
        <div class="row justify-content-center">
            <div class="col-md-auto text-center">
                <h1>Clientes</h1>
            </div>
        </div>
        <div class="row justify-content-end">
            <div class="col-md-4 text-end">
                <button type="button" id="new" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#exampleModal" data-bs-whatever="@getbootstrap">Nuevo Cliente</button>
            </div>
        </div>
        <!--------------------------- INICIO MODAL-------------------------------------->
        <div class="modal fade" id="exampleModal" role="dialog" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true"  >

            <div class="modal-dialog modal-xl">
                <div class="modal-content">
                    <div class="modal-header">
                        <h3 class="modal-title" id="exampleModalLabel">Nuevo Cliente</h3>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div class="modal-body">

                        <div class="container">
                            <div class="row justify-content-md-center ">
                                <div class="card col-md-10">
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
                                                    <span class="input-group-text" id="lblnDocumento">DNI</span>
                                                    <asp:TextBox ID="TxtDNI" CssClass="form-control" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="col-md-10">
                                                <div class="input-group mb-3">
                                                    <span class="input-group-text" id="lblNombre">Nombre</span>
                                                    <asp:TextBox ID="TxtNombre" CssClass="form-control" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="col-md-10">
                                                <div class="input-group mb-3">
                                                    <span class="input-group-text" id="lblApellido">Apellido</span>
                                                    <asp:TextBox ID="TxtApellido" CssClass="form-control" runat="server"></asp:TextBox>
                                                </div>
                                            </div>

                                            <div class="col-md-6">
                                                <div class="input-group mb-3">
                                                    <span class="input-group-text" id="lblCategoria">Categoría</span>
                                                    <asp:DropDownList ID="ddlCategoria" runat="server" CssClass="btn btn-outline-secondary">
                                                        <asp:ListItem Selected="True" Value="Importante"></asp:ListItem>
                                                        <asp:ListItem Value="Personal"></asp:ListItem>
                                                        <asp:ListItem Value="Común"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="input-group mb-3">
                                                    <span class="input-group-text" id="lblTelefono">Telefono</span>
                                                    <asp:TextBox ID="TxtTelefono" CssClass="form-control" runat="server"></asp:TextBox>
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
                            </div>
                        </div>

                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="BtnGuardar" runat="server" Text="Guardar" OnClick="BtnGuardar_Click" CssClass="btn btn-success" />
                        <asp:Button ID="BtnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-secondary" OnClick="BtnCancelar_Click" />


                    </div>
                </div>
            </div>
        </div>
        <!----------------------------------------- FIN MODAL---------------------------------->

        <!-----------------------------------------INICIO LISTADO------------------------------>
        <div class="row justify-content-center mt-2">
            <div class="col-md-10">
                <div class="card mt-2">
                    <table class="table">
                        <thead class="">
                            <tr>
                                <th>Codigo</th>
                                <th>Nombre</th>
                                <th>Apellido</th>
                                <th>Telefono</th>
                                <th>Acciones</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater runat="server" ID="repClientes">
                                <ItemTemplate>
                                    <div>
                                        <tr>
                                            <td><%#Eval("codigo")%></td>
                                            <td><%#Eval("nombre")%></td>
                                            <td><%#Eval("apellido")%></td>
                                            <td><%#Eval("telefono")%></td>
                                            <td>
                                                <asp:LinkButton runat="server" ID="prueba" OnClick="prueba_Click" OnClientClick="edit();" CommandArgument='<%#Eval("codigo")%>' CommandName="Pcodigo" ></asp:LinkButton></td>
                                        </tr>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                </div>

            </div>
        </div>
    </div>
    <!---------------------------------------FIN LISTADO--------------------------------->
</asp:Content>
