﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AltaMarcaProducto.aspx.cs" Inherits="vista.AltaMarcaProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
        <div class="row justify-content-md-center">
            <div class="col-lg-4 text-center">
                <h1>Nueva Marca de Producto</h1>
            </div>
        </div>
        <div class="row justify-content-md-center ">
            <div class="card col-md-10">

                <div class="card-body">
                    <div class="row">
                        <div class="col-md-4">
                            <div class="input-group mb-3">
                                <asp:Label ID="LblCodigo" runat="server" Text="Codigo"></asp:Label>
                                <asp:TextBox ID="TxtCodigo" CssClass="form-control" runat="server"></asp:TextBox>

                            </div>
                        </div>
                        <div class="col-md-8">
                            <div class="input-group mb-3">
                                <asp:Label ID="LblDescripcion" runat="server" Text="Descripcion"></asp:Label>
                                <asp:TextBox ID="TxtDescripcion" CssClass="form-control" runat="server"></asp:TextBox>

                            </div>
                        </div>
                    </div>
                </div>
                <div class="card-footer text-end">
                    <asp:Button runat="server" ID="btnGuardar" Text="Guardar" OnClick="btnGuardar_Click" CssClass="btn btn-success" />
                    <a href="ListaMarcasProductos.aspx" class="btn btn-danger">Cancelar</a>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
