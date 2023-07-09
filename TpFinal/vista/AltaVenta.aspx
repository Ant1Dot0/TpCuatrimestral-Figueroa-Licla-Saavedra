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
                                <h4 class="text-info"><i class="bi bi-gear"></i></h4>
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
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="input-group mb-3">
                                <span class="input-group-text text-secondary" id="lblVendedor">Vendedor</span>
                                <asp:TextBox runat="server" CssClass="form-control" ID="TxtVendedor" Enabled="false">Ariel Valenzuela</asp:TextBox>  
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
                                <h4 class="text-info"><i class="bi bi-gear"></i></h4>
                            </a>
                        </div>
                    </div>
                </div>
                <div class="card-body text-center">
                    <h5 class="card-title">Aún no has añadido Productos</h5>
                    <a href="#" class="btn btn-primary">Agregar productos</a>
                </div>
            </div>

            <!-------------------------------------------- FIN CARD DETALLE PRODUCTOS----------------------------------->
        </div>
    </div>
</asp:Content>
