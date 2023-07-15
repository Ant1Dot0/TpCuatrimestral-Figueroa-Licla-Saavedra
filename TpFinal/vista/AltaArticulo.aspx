<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AltaArticulo.aspx.cs" Inherits="vista.AltaArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
        <div class="row justify-content-md-center">
            <div class="col-lg-4 text-center">
                <h1><%=  accion == 0 ? "Producto Nuevo": "Producto " + auxProductoSeleccionado.codigo %></h1>
            </div>
        </div>
        <div class="row justify-content-md-center ">
            <div class="card col-md-10">
                <div class="card-body">
                    <div class="row">
                        <div class="col-md-4">
                            <div class="input-group mb-3">
                                <span class="input-group-text" id="lblCodigo">Codigo</span>
                                <asp:TextBox runat="server" CssClass="form-control" ID="TxtCodigoProducto"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-8">
                            <div class="input-group mb-3">
                                <span class="input-group-text" id="lblDescripcion">Descripción</span>
                                <asp:TextBox runat="server" CssClass="form-control" ID="TxtDescripcion"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="input-group mb-3">
                                <span class="input-group-text" id="lblMarca">Marca</span>
                                <asp:DropDownList ID="ddlMarca" runat="server" CssClass="btn btn-outline-secondary">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="input-group mb-3">
                                <span class="input-group-text" id="lblCategoria">Categoría</span>
                                <asp:DropDownList ID="ddlCategoria" runat="server" CssClass="btn btn-outline-secondary">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="input-group mb-3">
                                <span class="input-group-text" id="lblPrecioCompra">Precio $</span>
                                <asp:TextBox runat="server" CssClass="form-control" ID="TxtPrecioCompra"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="input-group mb-3">
                                <span class="input-group-text" id="lblGanancia">Ganancia %</span>
                                <asp:TextBox runat="server" CssClass="form-control" ID="TxtGanancia"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="input-group mb-3">
                                <span class="input-group-text" id="lblStockActual">Stock</span>
                                <asp:TextBox runat="server" CssClass="form-control" ID="TxtStock"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="input-group mb-3">
                                <span class="input-group-text" id="lblStockMinimo">StockMinimo</span>
                                <asp:TextBox runat="server" CssClass="form-control" ID="TxtStockMinimo"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-10">
                            <h5>Proveedores
                                 <button type="button" class="btn btn-info" data-bs-toggle="modal" data-bs-target="#exampleModal" data-bs-whatever="@getbootstrap">Buscar</button></h5>
                            <div class="col-md-10">
                                <asp:Repeater runat="server" ID="repProveedores" Visible="true">
                                    <ItemTemplate>
                                        <div class="btn btn-secondary mb-1">
                                            <%#Eval("codigoProveedor") %>
                                            <asp:Button runat="server" ID="btnCloseTag" CssClass="btn-close" Font-Size="X-Small" OnClick="btnCloseTag_Click" CommandArgument='<%#Eval("codigo") %>' />
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>

                            </div>

                        </div>
                        <div class="card-footer text-end">
                            <asp:Button ID="BtnGuardar" runat="server" Text="Guardar" OnClick="BtnGuardar_Click" CssClass="btn btn-success" />

                             <%if (Session["User"] != null && ((Dominio.Usuario)Session["User"]).rol.descripcion == Dominio.TipoRol.ADMIN.ToString() && TxtCodigoProducto.Text != null)
                                {%>

                                    <asp:Button runat="server" ID="btnEliminar" OnClick="btnEliminar_Click" Text="Eliminar" CssClass="btn btn-dark"/>

                            <%} %>


                            <asp:Button ID="BtnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-secondary" OnClick="BtnCancelar_Click" />
                        </div>
                    </div>

                    <!--------------------------- INICIO MODAL-------------------------------------->
                    <div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                        <div class="modal-dialog modal-xl">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <h3 class="modal-title" id="exampleModalLabel">Proveedores</h3>
                                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                                </div>
                                <div class="modal-body">

                                    <div class="container">
                                        <div class="row justify-content-md-center ">
                                            <div class="col-md-8">
                                                    <asp:GridView ID="gvProveedores" CssClass="table table-dark" runat="server" AutoGenerateColumns="false" DataKeyNames="Codigo"
                                                        OnSelectedIndexChanged="gvProveedores_SelectedIndexChanged" OnPageIndexChanging="gvProveedores_PageIndexChanging"
                                                        AllowPaging="true">
                                                        <Columns>
                                                            <asp:BoundField HeaderText="Codigo" DataField="Codigo" />
                                                            <asp:BoundField HeaderText="Descripcion" DataField="razonSocial" />
                                                            <asp:CommandField ShowSelectButton="true" SelectText="+" HeaderText=" " />
                                                        </Columns>
                                                    </asp:GridView>
                                            </div>
                                        </div>
                                    </div>

                                </div>
                                <div class="modal-footer">
                                </div>
                            </div>
                        </div>
                    </div>
                    <!----------------------------------------- FIN MODAL---------------------------------->

                </div>
            </div>
        </div>
    </div>
</asp:Content>
