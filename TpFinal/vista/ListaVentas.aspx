﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ListaVentas.aspx.cs" Inherits="vista.ListaVentas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="container mt-4" style="height: 198px">
        <div class="row justify-content-center">
            <div class="col-md-auto text-center">
                <h1>Ventas</h1>
            </div>
        </div>
        <div class="row justify-content-end">
            <div class="col-md-4 text-center">
                <a href="AltaVenta.aspx" class="btn btn-primary">Nueva Venta</a>
            </div>
        </div>
        <div class="row justify-content-center mt-2">
            <div class="col-md-10">
                <asp:GridView ID="GridViewClientes" CssClass="table table-dark" runat="server" AutoGenerateColumns="false" DataKeyNames="ID">
                    <Columns>
                        <asp:BoundField HeaderText="ID" DataField="ID" />
                        <asp:BoundField HeaderText="numero" DataField="numero" />
                        <asp:BoundField HeaderText="puntoVenta" DataField="puntoVenta" />
                        <asp:BoundField HeaderText="Cliente" DataField="cliente" />
                        <asp:BoundField HeaderText="Total" DataField="TotalComprobante" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
