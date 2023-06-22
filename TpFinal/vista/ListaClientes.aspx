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
                <button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#exampleModal" data-bs-whatever="@getbootstrap">Nuevo Cliente</button>
            </div>
        </div>
        <!--------------------------- INICIO MODAL-------------------------------------->
        <div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
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
                                                    <input type="text" class="form-control" placeholder="Código Cliente" aria-label="CodigoCliente" aria-describedby="basic-addon1">
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="input-group mb-3">
                                                    <span class="input-group-text" id="lblnDocumento">DNI</span>
                                                    <input type="text" class="form-control" placeholder="12345678" aria-label="NDocumento" aria-describedby="basic-addon1">
                                                </div>
                                            </div>
                                            <div class="col-md-10">
                                                <div class="input-group mb-3">
                                                    <span class="input-group-text" id="lblNombre">Nombre</span>
                                                    <input type="text" class="form-control" placeholder="Nombre" aria-label="NombreCliente" aria-describedby="basic-addon1">
                                                </div>
                                            </div>
                                            <div class="col-md-10">
                                                <div class="input-group mb-3">
                                                    <span class="input-group-text" id="lblApellido">Apellido</span>
                                                    <input type="text" class="form-control" placeholder="Apellido" aria-label="ApellidoCliente" aria-describedby="basic-addon1">
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
                                                    <input type="tel" class="form-control" placeholder="11-1111-1111" aria-label="Telefono" aria-describedby="basic-addon1">
                                                </div>
                                            </div>
                                            <div class="col-md-10">
                                                <div class="input-group mb-3">
                                                    <span class="input-group-text" id="lblEmail">Email</span>
                                                    <input type="text" class="form-control" placeholder="Ejemplo@mail.com" aria-label="EmailCliente" aria-describedby="basic-addon1">
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

                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cancelar</button>
                        <button type="button" class="btn btn-success">Guardar</button>
                    </div>
                </div>
            </div>
        </div>
        <!----------------------------------------- FIN MODAL---------------------------------->

        <!-----------------------------------------INICIO LISTADO------------------------------>
        <div class="row justify-content-center mt-2">
            <div class="col-md-10">
                <asp:GridView ID="GridViewClientes" CssClass="table table-dark" runat="server" AutoGenerateColumns="false" DataKeyNames="ID">
                    <Columns>
                        <asp:BoundField HeaderText="ID" DataField="ID" />
                        <asp:BoundField HeaderText="Codigo" DataField="Codigo" />
                        <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                        <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
                        <asp:BoundField HeaderText="Telefono" DataField="Telefono" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
    <!---------------------------------------FIN LISTADO--------------------------------->
</asp:Content>
