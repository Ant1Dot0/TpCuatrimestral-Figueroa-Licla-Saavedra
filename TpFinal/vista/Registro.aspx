<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="vista.Registro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<form>
  <div class="mb-3">
    <label for="TxtEmail" class="form-label">Email address</label>
      <asp:TextBox ID="TxtEmail"  CssClass="form-control" runat="server"></asp:TextBox>
    <div id="emailHelp" class="form-text">We'll never share your email with anyone else.</div>
  </div>
  <div class="mb-3">
    <label for="exampleInputPassword1" class="form-label">Password</label>
      <asp:TextBox ID="TxtPass" CssClass="form-control" runat="server"></asp:TextBox>
    <input type="password" class="form-control" id="exampleInputPassword1">
  </div>
  <div class="mb-3 form-check">
    <input type="checkbox" class="form-check-input" id="exampleCheck1">
    <label class="form-check-label" for="exampleCheck1">Check me out</label>
  </div>
    <asp:Button ID="BtnIngreso" CssClass="btn btn-primary" OnClick="BtnIngreso_Click" runat="server" Text="Ingresar" />
</ form>

</asp:Content>
