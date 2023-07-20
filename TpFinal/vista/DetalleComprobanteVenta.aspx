<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="DetalleComprobanteVenta.aspx.cs" Inherits="vista.DetalleComprobanteVenta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
        <div class="row justify-content-md-center">
            <div class="col-lg-6 text-center">
                <h1>Datos del Comprobante</h1>
            </div>
        </div>
        <div class="row justify-content-md-center ">
            <div class="card col-md-10 mb-3">
                <div class="card-body">
                    <div class="row">
                        <div class="col-md-10">
                            <div class="input-group mb-3">
                                <span class="input-group-text" id="lblCliente">Cliente</span>
                                <asp:TextBox runat="server" CssClass="form-control" ID="txtCodigo" Enabled="false" ra></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ReqClienteNuevo" ControlToValidate="txtCodigo"
                                    ValidationGroup="ClienteNuevoGroup" runat="server"><h4 class="ms-2 text-danger"><i title="Campo obligatorio" class=" bi bi-exclamation-circle"></i></h4></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="input-group mb-3">
                                <button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#exampleModal" data-bs-whatever="@getbootstrap">Nuevo Cliente</button>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="input-group mb-3">
                                <span class="input-group-text" id="lblFecha">Fecha</span>
                                <input type="datetime" class="form-control" disabled="disabled" value="<%=hoy.ToString("d") %>" aria-label="Fecha" aria-describedby="basic-addon1">
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="input-group mb-3">
                                <span class="input-group-text" id="lblVendedor">Vendedor</span>
                               <asp:TextBox runat="server" CssClass="form-control" ID="TxtVendedor" Enabled="false"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="card-footer text-end">
                    <asp:Button runat="server" ID="BtnGuardar" CssClass="btn btn-success" Text="Guardar" OnClick="BtnGuardar_Click" CausesValidation="true" ValidationGroup="ClienteNuevoGroup" />
                    <asp:Button runat="server" ID="BtnCancelar" CssClass="btn btn-secondary" Text="Cancelar" OnClick="BtnCancelar_Click" />
                </div>
            </div>

            <div class="card col-md-10">
                <div class="input-group my-2">
                    <span class="input-group-text" id="lblFiltro">Filtro</span>
                    <asp:TextBox runat="server" ID="TxtFiltro" CssClass="form-control  border border-secondary" AutoPostBack="true" OnTextChanged="TxtFiltro_TextChanged"></asp:TextBox>
                </div>

                <asp:GridView ID="gvClientes" runat="server" DataKeyNames="codigo" CssClass="table table-info border border-info-subtle" AutoGenerateColumns="false"
                    OnSelectedIndexChanged="gvClientes_SelectedIndexChanged" OnPageIndexChanging="gvClientes_PageIndexChanging"
                    AllowPaging="true">
                    <Columns>
                        <asp:BoundField HeaderText="Codigo" DataField="codigo" />
                        <asp:BoundField HeaderText="Nombre" DataField="nombre" />
                        <asp:BoundField HeaderText="Apellido" DataField="apellido" />
                        <asp:BoundField HeaderText="DNI" DataField="nDocumento" />
                        <asp:BoundField HeaderText="Categoría" DataField="categoria" />
                        <asp:CommandField ShowSelectButton="true" SelectText='<i title="Seleccionar" class="bi bi-check2-square"></i>' HeaderText="Acciones " ControlStyle-CssClass="text-bg-dark" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        <div class="row justify-content-center">
            <div class="col-md-12 text-center">
                <asp:ValidationSummary runat="server" DisplayMode="BulletList" CssClass="text-danger fs-4" HeaderText="Debe Seleccionar un cliente" ValidationGroup="ClienteNuevoGroup" />
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
                                                    <asp:Label runat="server" ID="lblCodCliente" CssClass="input-group-text" Text="Código" AssociatedControlID="TxtCodigoNuevoCliente"></asp:Label>
                                                    <asp:TextBox ID="TxtCodigoNuevoCliente" CssClass="form-control" runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="ReqCampoCodigo" ControlToValidate="TxtCodigoNuevoCliente"
                                                        ValidationGroup="ClienteInfGroup" runat="server"><h4 class="ms-2 text-danger"><i title="Campo obligatorio" class=" bi bi-exclamation-circle"></i></h4></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="input-group mb-3">
                                                    <span class="input-group-text" id="lblnDocumento">DNI</span>
                                                    <asp:TextBox ID="TxtDNI" CssClass="form-control" runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="ReqCampoDNI" ControlToValidate="TxtDNI"
                                                        ValidationGroup="ClienteInfGroup" runat="server"><h4 class="ms-2 text-danger"><i title="Campo obligatorio" class="bi bi-exclamation-circle"></i></h4></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <div class="col-md-10">
                                                <div class="input-group mb-3">
                                                    <span class="input-group-text" id="lblNombre">Nombre</span>
                                                    <asp:TextBox ID="TxtNombre" CssClass="form-control" runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="ReqCampoNombre" ControlToValidate="TxtNombre"
                                                        ValidationGroup="ClienteInfGroup" runat="server"><h4 class="ms-2 text-danger"><i title="Campo obligatorio" class="bi bi-exclamation-circle"></i></h4></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <div class="col-md-10">
                                                <div class="input-group mb-3">
                                                    <span class="input-group-text" id="lblApellido">Apellido</span>
                                                    <asp:TextBox ID="TxtApellido" CssClass="form-control" runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="ReqCampoApellido" ControlToValidate="TxtApellido"
                                                        ValidationGroup="ClienteInfGroup" runat="server"><h4 class="ms-2 text-danger"><i title="Campo obligatorio" class="bi bi-exclamation-circle"></i></h4></asp:RequiredFieldValidator>
                                                </div>
                                            </div>

                                            <div class="col-md-6">
                                                <div class="input-group mb-3">
                                                    <span class="input-group-text" id="lblCategoria">Categoría</span>
                                                    <asp:DropDownList ID="ddlCategoria" runat="server" CssClass="btn btn-outline-secondary">
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
                                        <div class="row justify-content-center">
                                            <div class="col-md-12 text-center">

                                                <asp:ValidationSummary runat="server" DisplayMode="BulletList" CssClass="text-danger fs-4" HeaderText="Debe completar los campos marcados" ValidationGroup="ClienteInfGroup" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div><!---------fin row------------->
                        </div>

                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="btnAltaCliente" runat="server" Text="Guardar" OnClick="btnAltaCliente_Click" CssClass="btn btn-success" CausesValidation="true" ValidationGroup="ClienteInfGroup" />
                        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cancelar</button>
                    </div>
                </div>
            </div>
        </div>
        <!----------------------------------------- FIN MODAL---------------------------------->
    </div>
</asp:Content>
