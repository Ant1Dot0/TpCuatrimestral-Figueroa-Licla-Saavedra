<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="DetalleProductosCompra.aspx.cs" Inherits="vista.DetalleProductosCompra" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">

        <div class="row justify-content-center mb-4">
            <div class="col-lg-4 text-center">
                <h1>Detalle de Productos</h1>
            </div>
        </div>
        <div class="row justify-content-between mb-2">
            <div class="col-md-3 text-start">
                <div class="input-group">
                    <span class="input-group-text" id="lblTotal">Total</span>
                    <asp:TextBox runat="server" ID="txtTotal" CssClass="form-control border border-secondary bg-primary-subtle text-black text" Enabled="false"></asp:TextBox>
                </div>
            </div>
            <div class="col-md-2 text-start">
                <div class="input-group">
                    <span class="input-group-text" id="lblTotCantidad">Cantidad</span>
                    <asp:TextBox runat="server" ID="TxtTotCantidad" CssClass="form-control border border-secondary bg-primary-subtle text-black text" Enabled="false"></asp:TextBox>
                </div>
            </div>
            <div class="col-md-6 text-end">
                <asp:Button runat="server" ID="BtnGuardar" CssClass="btn btn-success" Text="Guardar" OnClick="BtnGuardar_Click" />
                <asp:Button runat="server" ID="BtnCancelar" CssClass="btn btn-secondary" Text="Cancelar" OnClick="BtnCancelar_Click" />
            </div>
        </div>

        <div class="row justify-content-md-between">
            <div class="col-lg-7">
                <div class="card">
                    <div class="card-header text-center my-1">
                        <h4>Productos Seleccionados</h4>
                    </div>
                    <% if (productosSeleccionados.Count == 0)
                        { %>
                    <div class="card-body text-center mt-5">
                        <h5 class="card-title">Aún no has añadido Productos</h5>
                        <p>Utiliza el buscador para seleccionar nuevos productos</p>
                    </div>
                    <%}
                        else
                        { %>
                    <div class="card-body text-center mt-1">
                        <asp:GridView runat="server" ID="gvProductosSeleccionados" CssClass="table table-primary border border-primary-subtle" AutoGenerateColumns="false" DataKeyNames="codProducto"
                            OnSelectedIndexChanged="gvProductosSeleccionados_SelectedIndexChanged" OnPageIndexChanged="gvProductosSeleccionados_PageIndexChanged">
                            <Columns>
                                <asp:CommandField ShowSelectButton="true" ControlStyle-CssClass="text-bg-dark" SelectText='<i title=Quitar class="bi bi-x-square"></i>' HeaderText="Acciones" ItemStyle-Width="1" />
                                <asp:BoundField HeaderText="Codigo" DataField="codProducto" />
                                <asp:BoundField HeaderText="Descripcion" DataField="descripcion" />
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:Label runat="server" Text="Precio"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:TextBox TextMode="Number" runat="server" ID="TxtPrecio" Width="100" Text='<%#Eval("precioVenta")%>' AutoPostBack="true" OnTextChanged="TxtPrecio_TextChanged"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:Label runat="server" Text="Cantidad"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:TextBox TextMode="Number" runat="server" ID="TxtCantidad" Width="70" Text='<%#Eval("cantidad")%>' AutoPostBack="true" OnTextChanged="TxtCantidad_TextChanged"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:Label runat="server" Text="Monto"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <label runat="server"><%#Eval("monto") %></label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>

                    </div>
                    <%} %>
                </div>
            </div>

            <div class="col-lg-5">
                <div class="card">
                    <div class="card-header text-center my-1">
                        <h4>Buscador</h4>
                    </div>
                    <div class="card-body text-center">
                        <div class="input-group mb-2">
                            <span class="input-group-text" id="lblFiltro">Filtro</span>
                            <asp:TextBox runat="server" ID="TxtFiltro" CssClass="form-control  border border-secondary" AutoPostBack="true" OnTextChanged="TxtFiltro_TextChanged"></asp:TextBox>
                        </div>
                        <div>
                            <asp:GridView ID="gvProductos" runat="server" DataKeyNames="codigo" CssClass="table table-info" AutoGenerateColumns="false"
                                OnSelectedIndexChanged="gvProductos_SelectedIndexChanged" OnPageIndexChanged="gvProductos_PageIndexChanged"
                                AllowPaging="true">
                                <Columns>
                                    <asp:BoundField HeaderText="Codigo" DataField="codigo" />
                                    <asp:BoundField HeaderText="Descripcion" DataField="descripcion" />
                                    <asp:BoundField HeaderText="Stock" DataField="stockActual" />
                                    <asp:BoundField HeaderText="precio" DataField="precioCompra" />
                                    <asp:CommandField ShowSelectButton="true" SelectText='<i title=Agregar class=" text-bg-dark bi bi-plus-square"></i>' HeaderText="Acciones" />
                                </Columns>

                            </asp:GridView>
                        </div>
                    </div>
                </div>

            </div>
        </div>

    </div>
</asp:Content>
