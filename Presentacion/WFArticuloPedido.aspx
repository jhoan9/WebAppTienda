<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WFArticuloPedido.aspx.cs" Inherits="Presentacion.WFArticuloPedido"%>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Gestión de Artículo Pedido</title>
    <link href="assets/styles/ArticuloPedido.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container-articuloPedido">
            <h1>Gestión de Artículo Pedido</h1>

            <nav>
                <a href="Inicio.aspx">Inicio</a>
                <a href="WFArticulo.aspx">Artículo</a>
                <a href="WFCategoria.aspx">Categoría</a>
                <a href="WFCliente.aspx">Cliente</a>
            </nav>

            <asp:TextBox ID="TBIdArtPed" runat="server" Visible="false" />

            <div class="form-group">
                <label for="DDLArticulo">Artículo</label>
                <asp:DropDownList ID="DDLArticulo" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>

            <div class="form-group">
                <label for="DDLPedido">Pedido</label>
                <asp:DropDownList ID="DDLPedido" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>

            <div class="form-group">
                <label for="TBCantidad">Cantidad</label>
                <asp:TextBox ID="TBCantidad" runat="server" CssClass="form-control" type="number" min="1" />
            </div>

            <asp:Label ID="LblMensaje" runat="server" CssClass="mensaje-error" />

            <div class="form-buttons">
                <asp:Button ID="BtnGuardar" runat="server" Text="Guardar" CssClass="btn" OnClick="BtnGuardar_Click" />
                <asp:Button ID="BtnActualizar" runat="server" Text="Actualizar" CssClass="btn btn-secondary" Visible="false" OnClick="BtnActualizar_Click" />
            </div>

            <h2>Lista de Artículos por Pedido</h2>
            <asp:GridView ID="GVArticuloPedido" runat="server" CssClass="tabla" AutoGenerateColumns="false"
                OnSelectedIndexChanged="GVArticuloPedido_SelectedIndexChanged" OnRowDataBound="GVArticuloPedido_RowDataBound">
                <Columns>
                    <asp:BoundField DataField="IdpedidoArticulo" HeaderText="ID" />
                    <asp:BoundField DataField="IdArticulo" HeaderText="ID Artículo" />
                    <asp:BoundField DataField="IdPedido" HeaderText="ID Pedido" />
                    <asp:BoundField DataField="cantidadArticuloPedido" HeaderText="Cantidad" />
                    <asp:BoundField DataField="nombreArticulo" HeaderText="Articulo" />
                    <asp:BoundField DataField="marcaArticulo" HeaderText="Marca" />
                    <asp:BoundField DataField="pedidoDescripcion" HeaderText="Descripción" />
                    <asp:BoundField DataField="fecha" HeaderText="Fecha" />
                    <asp:BoundField DataField="precioArticulo" HeaderText="Precio" />
                    <asp:CommandField ShowSelectButton="true"/>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
