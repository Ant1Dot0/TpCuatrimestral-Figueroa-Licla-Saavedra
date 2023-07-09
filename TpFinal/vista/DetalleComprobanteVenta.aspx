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
                                <input type="text" class="form-control" disabled="disabled" placeholder="CF- Consumdor Final" aria-label="CodigoCliente" aria-describedby="basic-addon1">
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="input-group mb-3">
                               <asp:Button runat="server" CssClass="btn btn-primary" text="Nuevo Cliente" />
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
                                <input type="text" class="form-control" disabled="disabled" placeholder="Ariel Valenzuela" aria-label="CodigoVendedor" aria-describedby="basic-addon1">
                            </div>
                        </div>
                    </div>
                </div>
                <div class="card-footer text-end">
                    <asp:Button runat="server" CssClass="btn btn-success"  Text="Guardar"/>
                    <asp:Button runat="server" CssClass="btn btn-secondary"  Text="Cancelar"/>
                </div>
            </div>

            <div class="card col-md-10"></div>
        </div>
    </div>
</asp:Content>
