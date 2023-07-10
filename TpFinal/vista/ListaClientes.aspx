<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ListaClientes.aspx.cs" Inherits="vista.ListaClientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container mt-4" style="height: 198px">
        <div class="row justify-content-center">
            <div class="col-md-auto text-center">
                <h1>Clientes</h1>
            </div>
        </div>
        <div class="row justify-content-end">
            <div class="col-md-4 text-end">
                <%if (Session["User"] != null && ((Dominio.Usuario)Session["User"]).rol.descripcion == Dominio.TipoRol.ADMIN.ToString())
                    {%>
                            <a href="AltaCliente.aspx" class="btn btn-primary">Nuevo Cliente</a>
                <%} %>
            </div>
        </div>

        <!-----------------------------------------INICIO LISTADO------------------------------>
        <div class="row justify-content-center mt-2">
            <div class="col-md-10">
                <div class="card mt-2">
                    <table class="table">
                        <thead class="">
                            <tr>
                                <th>Codigo</th>
                                <th>Nombre</th>
                                <th>Apellido</th>
                                <th>Telefono</th>
                                <th>Acciones</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater runat="server" ID="repClientes">
                                <ItemTemplate>
                                    <div>
                                        <tr>
                                            <td><%#Eval("codigo")%></td>
                                            <td><%#Eval("nombre")%></td>
                                            <td><%#Eval("apellido")%></td>
                                            <td><%#Eval("telefono")%></td>
                                            <td>
                                        </tr>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                </div>

            </div>
        </div>
    </div>
    <!---------------------------------------FIN LISTADO--------------------------------->
</asp:Content>
