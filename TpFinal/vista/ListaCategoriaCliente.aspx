﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ListaCategoriaCliente.aspx.cs" Inherits="vista.ListaCategoriaCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4" style="height: 198px">
        <div class="row justify-content-center">
            <div class="col-md-auto text-center">
                <h1>Categorías de Cliente</h1>
            </div>
        </div>
        <div class="row justify-content-end">
            <div class="col-md-4 text-end">
                <button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#exampleModal" data-bs-whatever="@getbootstrap">Nueva Categoría</button>
            </div>
        </div>

        <!--------------------------- INICIO MODAL-------------------------------------->
        <div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog modal-xl">
                <div class="modal-content">
                    <div class="modal-header">
                        <h3 class="modal-title" id="exampleModalLabel">Nueva Categoría Cliente</h3>
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
                                </div>
                            </div>
                        </div>

                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="BtnCancelar" runat="server" CssClass="btn btn-secondary" OnClick="BtnCancelar_Click" Text="Cancelar" />
                        <asp:Button ID="BtnGuardar"  runat="server" CssClass="btn btn-secondary" OnClick="BtnGuardar_Click" Text="Guardar" />

                    </div>
                </div>
            </div>
        </div>
        <!----------------------------------------- FIN MODAL---------------------------------->

        <!-----------------------------------------INICIO LISTADO------------------------------>
        <div class="row justify-content-center mt-2">
            <div class="col-md-10">
                <asp:GridView ID="GridViewCategoria" CssClass="table table-dark" runat="server" OnSelectedIndexChanged="GridViewCategoria_SelectedIndexChanged" AutoGenerateColumns="false" DataKeyNames="ID">
                    <Columns>
                        <asp:BoundField HeaderText="ID" DataField="ID" />
                        <asp:BoundField HeaderText="Codigo" DataField="codigo" />
                        <asp:BoundField HeaderText="Descripción" DataField="descripcion" />
                        <asp:CommandField ShowSelectButton="true" SelectText="✔️" HeaderText=" " />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        <!---------------------------------------FIN LISTADO---------------------------------->
    </div>
</asp:Content>
