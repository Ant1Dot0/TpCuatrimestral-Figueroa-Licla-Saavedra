﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AltaCategoriaProveedor.aspx.cs" Inherits="vista.AltaCategoriaProveedor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server"> <div class="container mt-5">
        <div class="row justify-content-md-center">
            <div class="col-lg-4 text-center">
                <h1>Nueva Categoría de Proveedor</h1>
            </div>
        </div>
        <div class="row justify-content-md-center ">
            <div class="card col-md-10">
                <div class="card-header text-center">
                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary mb-1" />
                    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger mb-1" />
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
                        <div class="col-md-8">
                            <div class="input-group mb-3">
                                <asp:Label ID="LblDescripcion" runat="server" Text="Descripcion"></asp:Label>
                                <asp:TextBox ID="TxtDescripcion" CssClass="form-control"  runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
