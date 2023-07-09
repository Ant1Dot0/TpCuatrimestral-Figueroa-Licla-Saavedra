﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Logueo.master" AutoEventWireup="true" CodeBehind="InicioSesion.aspx.cs" Inherits="vista.InicioSesion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="container mt-5">
        <div class="row">
            <div class="row justify-content-md-center">
                <div class="col-lg-4 text-center">
                    <h1>OrganizAr</h1>
                </div>
            </div>
            <div class="row justify-content-md-center ">
                <div class="card col-md-6">
                    <div class="card-body">
                        <div class="mb-3">
                            <label for="TxtEmail" class="form-label">Email address</label>
                            <asp:TextBox ID="TxtEmail" CssClass="form-control" runat="server"></asp:TextBox>
                            <div id="emailHelp" class="form-text">We'll never share your email with anyone else.</div>
                        </div>
                        <div class="mb-3">
                            <label for="exampleInputPassword1" class="form-label">Password</label>
                            <asp:TextBox ID="TxtPass" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>

                    </div>
                    <div class="card-body">
                        <div class="row justify-content-end">
                            <div class="col-md-4 text-end">
                                <asp:Button ID="BtnIngreso" CssClass="btn btn-primary" OnClick="BtnIngreso_Click" runat="server" Text="Ingresar" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>


