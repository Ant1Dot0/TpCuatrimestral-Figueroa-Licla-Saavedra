<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AltaVenta.aspx.cs" Inherits="vista.AltaVenta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
        <div class="row justify-content-md-center">
            <div class="col-lg-4 text-center">
                <h1>Nueva Venta</h1>
            </div>
        </div>
        <div class="row justify-content-md-center ">
            <!--------------------------------------------CARD DATOS DEL COMPROBANTE----------------------------------->
            <div class="card col-md-10 mb-2">
                <div class="card-header">
                    <div class="row">
                        <div class="col-md-6 text-start">
                            <h4 class="text-info">Datos del Comprobante</h4>
                        </div>
                        <div class="col-md-6 text-end">
                            <a href="DetalleComprobanteVenta.aspx">
                                <h4 class="text-info"><i title="Editar" class="bi bi-pencil-square"></i></h4>
                            </a>
                        </div>
                    </div>
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-md-9">
                            <div class="input-group mb-3">
                                <span class="input-group-text text-secondary" id="lblCliente">Cliente</span>
                                <asp:TextBox runat="server" CssClass="form-control" ID="TxtCliente" Enabled="false"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ReqCliente" ControlToValidate="TxtCliente"
                                    ValidationGroup="VentaGroup" runat="server"><h4 class="ms-2 text-danger"><i title="Campo obligatorio" class=" bi bi-exclamation-circle"></i></h4></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="input-group mb-3">
                                <span class="input-group-text text-secondary" id="lblVendedor">Vendedor</span>
                                <asp:TextBox runat="server" CssClass="form-control" ID="TxtVendedor" Enabled="false"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="input-group mb-3">
                                <span class="input-group-text text-secondary" id="lblFecha">Fecha</span>
                                <input type="datetime" class="form-control" disabled="disabled" value="<%=hoy.ToString("d") %>" aria-label="Fecha" aria-describedby="basic-addon1">
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-------------------------------------------- FIN CARD DATOS DEL COMPROBANTE----------------------------------->

            <!-------------------------------------------- CARD DETALLE PRODUCTOS----------------------------------->
            <div class="card col-md-10">
                <div class="card-header">
                    <div class="row">
                        <div class="col-md-6 text-start">
                            <h4 class="text-info">Detalle de Productos</h4>
                        </div>
                        <div class="col-md-6 text-end">
                            <a href="DetalleProductosVenta.aspx">
                                <h4 class="text-info"><i title="Editar" class="bi bi-pencil-square"></i></h4>
                            </a>
                        </div>
                    </div>
                </div>

                <div class="card-body text-center">
                    <%if (detProductosVenta.Count == 0)
                        { %>
                    <h5 class="card-title">Aún no has añadido Productos</h5>
                    <a href="DetalleProductosVenta.aspx" class="btn btn-primary">Agregar productos</a>
                    <%}
                        else
                        { %>

                    <div class="row justify-content-around">
                        <div class="col-md-4">
                            <span class="form-control text-black" id="lblTotalCantidad">Cantidad</span>
                            <asp:TextBox runat="server" CssClass="form-control text-center" ID="txtTotalCantidad" Enabled="false"></asp:TextBox>
                        </div>

                        <div class="col-md-4">
                            <span class="form-control text-black" id="lblTotalItems">Items</span>
                            <asp:TextBox runat="server" CssClass="form-control text-center" ID="TxtTotalItems" Enabled="false"></asp:TextBox>
                        </div>
                        <div class="col-md-4">
                            <div class="card-body bg-primary-subtle border border-info border-bottom">
                                <h2>TOTAL: <%=total %></h2>
                            </div>
                        </div>

                    </div>


                    <%} %>
                </div>
                <div class="card-footer text-end">
                    <%if (totalCantidad > 0)
                        { %>
                    <button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#exampleModal" data-bs-whatever="@getbootstrap">Ver Detalle</button>
                    <asp:Button runat="server" ID="btnAceptar" CssClass="btn btn-success" Text="Aceptar" OnClick="btnAceptar_Click" CausesValidation="true" ValidationGroup="VentaGroup" />
                    <%} %>
                    <asp:Button runat="server" ID="btnCancelar" CssClass="btn btn-danger" Text="Cancelar" OnClick="btnCancelar_Click" />

                </div>

            </div>
            <div class="row justify-content-center">
                <div class="col-md-12 text-center">
                    <asp:ValidationSummary runat="server" DisplayMode="BulletList" CssClass="text-danger fs-4" HeaderText="Debe completar los campos marcados" ValidationGroup="VentaGroup" />
                </div>
            </div>
            <!-------------------------------------------- FIN CARD DETALLE PRODUCTOS----------------------------------->

        </div>
        <!--------------------------- INICIO MODAL-------------------------------------->
        <div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog modal-xl">
                <div class="modal-content">
                    <div class="modal-header">
                        <h3 class="modal-title" id="exampleModalLabel">Detalle de Productos</h3>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div class="modal-body">

                        <div class="container">
                            <div class="row justify-content-md-center ">
                                <div class="col-md-10">
                                    <asp:GridView ID="gvProductos" CssClass="table table-success border border-success-subtle" runat="server" AutoGenerateColumns="false">
                                        <Columns>
                                            <asp:BoundField HeaderText="Codigo" DataField="codProducto" />
                                            <asp:BoundField HeaderText="Descripcion" DataField="descripcion" />
                                            <asp:BoundField HeaderText="Cantidad" DataField="cantidad" />
                                            <asp:BoundField HeaderText="Precio" DataField="precioVenta" />
                                            <asp:BoundField HeaderText="Monto" DataField="monto" />
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Aceptar</button>
                    </div>
                </div>
            </div>
        </div>
        <!----------------------------------------- FIN MODAL---------------------------------->
    </div>
</asp:Content>
