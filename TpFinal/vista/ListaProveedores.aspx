﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ListaProveedores.aspx.cs" enableEventValidation ="false" Inherits="vista.ListaProveedores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4" style="height: 198px">
        <div class="row justify-content-center">
            <div class="col-md-auto text-center">
                <h1>Proveedores</h1>
            </div>
        </div>
        <div class="row justify-content-end">
            <div class="col-md-4 text-end">
                <%if (Session["User"] != null && ((Dominio.Usuario)Session["User"]).rol.descripcion == Dominio.TipoRol.ADMIN.ToString())
                    {%>
                         <a href="AltaProveedor.aspx" class="btn btn-primary">Nuevo Proveedor</a>
                
                      
                <%} %>
            </div>
        </div>


        <!--------------------------- INICIO MODAL-------------------------------------->
        <div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog modal-xl">
                <div class="modal-content">
                    <div class="modal-header">
                        <h3 class="modal-title" id="exampleModalLabel">Nuevo Proveedor</h3>
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
                                                    
                                                <asp:TextBox ID="TxtCodigo" CssClass="form-control"  runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="input-group mb-3">
                                                    <span class="input-group-text" id="lblCuit">CUIT</span>
                                                    
                                                    <asp:TextBox ID="TxtCuit" CssClass="form-control"  runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="col-md-12">
                                                <div class="input-group mb-3">
                                                    <span class="input-group-text" id="lblRazonSocial">Razón Social</span>
                                                    
                                                    <asp:TextBox ID="TxtRazonSocial" CssClass="form-control"  runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="input-group mb-3">
                                                    <span class="input-group-text" id="lblCategoria">Categoría</span>
                                                    <asp:DropDownList ID="ddlCategoria" runat="server" CssClass="btn btn-outline-secondary">
                                                        <asp:ListItem Selected="True" Value="Bebidas"></asp:ListItem>
                                                        <asp:ListItem Value="Carnes"></asp:ListItem>
                                                        <asp:ListItem Value="Varios"></asp:ListItem>
                                                    </asp:DropDownList>
                                                    
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="input-group mb-3">
                                                    <span class="input-group-text" id="lblTelefono">Telefono</span>
                                                    
                                                    <asp:TextBox ID="TxtTelefono" CssClass="form-control"  runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="col-md-10">
                                                <div class="input-group mb-3">
                                                    <span class="input-group-text" id="lblEmail">Email</span>
                                                    
                                                    <asp:TextBox ID="TxtEmail" CssClass="form-control"  runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="col-md-12">
                                                <div class="input-group mb-3">
                                                    <span class="input-group-text" id="lblDireccion">Dirección</span>
                                                    
                                                    <asp:TextBox ID="TxtDireccion" CssClass="form-control"  runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>
                    <div class="modal-footer">
                        
                        <asp:Button ID="BtnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-secondary" OnClick="BtnCancelar_Click" />
                       
                    </div>
                </div>
            </div>
        </div>
        <!----------------------------------------- FIN MODAL---------------------------------->



        <!-----------------------------------------INICIO LISTADO------------------------------>
        <div class="row justify-content-center mt-2">
            <div class="col-md-10">
                <asp:GridView ID="GridViewProveedores" CssClass="table table-dark" runat="server" OnSelectedIndexChanged="GridViewProveedores_SelectedIndexChanged" AutoGenerateColumns="false" DataKeyNames="ID">
                    <Columns>
                        <asp:BoundField HeaderText="ID" DataField="ID" />
                        <asp:BoundField HeaderText="Razón Social" DataField="razonSocial" />
                        <asp:BoundField HeaderText="Cuit" DataField="cuit" />
                        <asp:BoundField HeaderText="Email" DataField="email" />
                        <asp:BoundField HeaderText="Dirección" DataField="direccion" />
                        <asp:CommandField ShowSelectButton="true" SelectText="✔️" HeaderText=" " />
                    </Columns>
                </asp:GridView>
            </div>
            <asp:Button ID="btnExportarExcel" runat="server" Text="Exportar a Excel" OnClick="btnExportarExcel_Click" />
            &nbsp;
            <asp:Button ID="btnExportarPdf" runat="server" Text="Exportar a Pdf" OnClick="btnExportarPdf_Click" />
                   

           
        </div>
        <!---------------------------------------FIN LISTADO---------------------------------->
    </div>

</asp:Content>
