<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AltaArticulo.aspx.cs" Inherits="vista.AltaArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
        <div class="row justify-content-md-center">
            <div class="col-lg-4 text-center">
                <h1>Producto nuevo</h1>
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
                                <span class="input-group-text" id="lblCodigo">Codigo</span>
                                <input type="text" class="form-control" placeholder="Código Producto" aria-label="CodigoArticulo" aria-describedby="basic-addon1">
                            </div>
                        </div>
                        <div class="col-md-8">
                            <div class="input-group mb-3">
                                <span class="input-group-text" id="lblDescripcion">Descripción</span>
                                <input type="text" class="form-control" placeholder="Descripción" aria-label="DescripcionArticulo" aria-describedby="basic-addon1">
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="input-group mb-3">
                                <span class="input-group-text" id="lblMarca">Marca</span>
                                <asp:DropDownList ID="ddlMarca" runat="server" CssClass="btn btn-outline-secondary">
                                    <asp:ListItem Selected="True" Value="Cuchuflito"></asp:ListItem>
                                    <asp:ListItem Value="Pindonga"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="col-md-6">
                            <div class="input-group mb-3">
                                <span class="input-group-text" id="lblCategoria">Categoría</span>
                                <asp:DropDownList ID="ddlCategoria" runat="server" CssClass="btn btn-outline-secondary">
                                    <asp:ListItem Selected="True" Value="Alimento"></asp:ListItem>
                                    <asp:ListItem Value="Libros"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="input-group mb-3">
                                <span class="input-group-text" id="lblPrecioCompra">Precio $</span>
                                <input type="number" class="form-control" placeholder="$9999" aria-label="Precio" aria-describedby="basic-addon1">
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="input-group mb-3">
                                <span class="input-group-text" id="lblGanancia">Ganancia %</span>
                                <input type="number" class="form-control" placeholder="100%" aria-label="Ganancia" aria-describedby="basic-addon1">
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="input-group mb-3">
                                <span class="input-group-text" id="lblStockActual">Stock</span>
                                <input type="number" class="form-control" placeholder="999" aria-label="Stock" aria-describedby="basic-addon1">
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="input-group mb-3">
                                <span class="input-group-text" id="lblStockMinimo">StockMinimo</span>
                                <input type="number" class="form-control" placeholder="999" aria-label="StockMinimo" aria-describedby="basic-addon1">
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-10">
                            <h5>Proveedores
                                 <button type="button" class="btn btn-info" data-bs-toggle="modal" data-bs-target="#exampleModal" data-bs-whatever="@getbootstrap">Modificar</button></h5>
                            <div class="col-md-10">
                                <%foreach (var x in auxProveedoresSeleccionados)
                                    {%>
                                <div class="btn btn-secondary mb-1"><%=x.codigoProveedor %></div>
                                <%} %>
                            </div>
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
                                                <div class="row">
                                                    <asp:GridView ID="gvProveedores" CssClass="table table-dark" runat="server" AutoGenerateColumns="false" DataKeyNames="ID">
                                                        <Columns>
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:CheckBox runat="server" ID="chbCheck"/>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:CheckBoxField HeaderText="Seleccionado" DataField="seleccionado" />
                                                            <asp:BoundField HeaderText="Codigo" DataField="Codigo"  />
                                                            <asp:BoundField HeaderText="Descripcion" DataField="razonSocial" />
                                                        </Columns>
                                                    </asp:GridView>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                </div>
                                <div class="modal-footer">
                                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cancelar</button>
                                    <button type="button" class="btn btn-success">Guardar</button>
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
