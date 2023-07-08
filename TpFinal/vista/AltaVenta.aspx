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
            <div class="card col-md-10">
                <div class="card-header text-center">
                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary mb-1" />
                    <asp:Button ID="btnEliminar" runat="server" Text="Anular" CssClass="btn btn-danger mb-1" />
                    <asp:Button ID="btnLista" runat="server" Text="Ver Lista" CssClass="btn btn-success mb-1" />
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-md-4">
                            <div class="input-group mb-3">
                                <span class="input-group-text" id="lblCliente">Cliente</span>
                                <input type="text" class="form-control" placeholder="Codigo Cliente" aria-label="CodigoCliente" aria-describedby="basic-addon1">
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="input-group mb-3">
                                <span class="input-group-text" id="lblNumero">Número</span>
                                <input type="text" class="form-control" disabled="disabled" placeholder="0001-00000001" aria-label="DescripcionArticulo" aria-describedby="basic-addon1">
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="input-group mb-3">
                                <span class="input-group-text" id="lblVendedor">Vendedor</span>
                                <input type="text" class="form-control" disabled="disabled" placeholder="Ariel Valenzuela" aria-label="CodigoVendedor" aria-describedby="basic-addon1">
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="input-group mb-3">
                                <span class="input-group-text" id="lblFecha">Fecha</span>
                                <input type="datetime" class="form-control" disabled="disabled" value="<%=hoy.ToString("d") %>" aria-label="Fecha" aria-describedby="basic-addon1">
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-8">
                                <h5>Articulos
                                <asp:Button runat="server" ID="btnBuscarProveedor" Text="Buscar" CssClass="btn btn-info" /></h5>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row justify-content-center mt-2">
                <div class="col-md-10">
                    <asp:GridView ID="GridViewDetalleProductos" CssClass="table table-dark" runat="server" AutoGenerateColumns="false" DataKeyNames="ID">
                        <Columns>
                            <asp:BoundField HeaderText="Codigo" DataField="codProducto" />
                            <asp:BoundField HeaderText="Descripción" DataField="descripcion" />
                            <asp:BoundField HeaderText="Cantidad" DataField="Cantidad" />
                            <asp:BoundField HeaderText="precioVenta" DataField="precioVenta" />
                            <asp:BoundField HeaderText="Descuento" DataField="montoDescuento" />
                            <asp:BoundField HeaderText="Monto" DataField="monto" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
               <a href="ListaVentas.aspx" class="btn btn-danger">Cancelar</a>
        </div>
    </div>
</asp:Content>
