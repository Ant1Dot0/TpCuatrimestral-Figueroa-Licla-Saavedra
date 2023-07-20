<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AltaUsuario.aspx.cs" Inherits="vista.AltaUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<h1>Usuario Nuevo</h1>
<div class="col-lg-4 text-center">
    &nbsp;
<h4>Datos Personales </h4>
 </div>   
    


               
                        <div class="col-md-4">
                            <div class="input-group mb-3">
                                <span class="input-group-text" id="lblNombre">Nombre</span>
                                <asp:TextBox ID="TxtNombre" CssClass="form-control" runat="server"></asp:TextBox>
                                
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="input-group mb-3">
                                <span class="input-group-text" id="lblApellido">Apellido</span>
                                <asp:TextBox ID="TxtApellido" CssClass="form-control" runat="server"></asp:TextBox>
                                
                            </div>

         
                            
                            <div class="input-group mb-3">
                                <span class="input-group-text" id="lblTelefono">Telefono</span>
                                <asp:TextBox ID="TxtTelefono" CssClass="form-control" runat="server"></asp:TextBox>
                                
                            </div>


                                                                             
                            <div class="input-group mb-3">
                                <span class="input-group-text" id="lblDireccion">Direccion</span>
                                <asp:TextBox ID="TxtDireccion" CssClass="form-control" runat="server"></asp:TextBox>
                                
                            </div>



                            </div>
    <div class="col-lg-4 text-center">                    
    <h4>Datos de registro usuario </h4>
    </div>
                            <div class="input-group mb-3">
                                <span class="input-group-text" id="lblEmail">E-mail</span>
                                <asp:TextBox ID="TxtEmail" CssClass="form-control" runat="server"></asp:TextBox>
                                
                            </div>
                                <div class="input-group mb-3">
                                <span class="input-group-text" id="lblContraseña">Contraseña</span>
                                <asp:TextBox ID="TextBox1" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>

                    <asp:Button ID="btnLista" runat="server" Text="Aceptar" CssClass="btn btn-success" />
                    <a href="ListaProveedores.aspx" class="btn btn-danger">Cancelar</a>

</asp:Content>
