<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WFPedido.aspx.cs" Inherits="Presentacion.WFPedido" ValidateRequest="false"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Gestión de Pedido</title>
    <link href="assets/styles/Pedido.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1>Gestión de Pedido</h1>

            <nav>
                <a href="Inicio.aspx">Inicio</a>
                <a href="WFArticulo.aspx">Artículo</a>
                <a href="WFCategoria.aspx">Categoría</a>
                <a href="WFCliente.aspx">Cliente</a>
            </nav>

            <asp:TextBox ID="TBIdPedido" runat="server" Visible="false" />

            <div class="form-group">
                <label for="TBFecha">Fecha</label>
                <asp:TextBox ID="TBFecha" runat="server" CssClass="form-control" placeholder="YYYY-MM-DD" TextMode="Date" />
            </div>

            <div class="form-group">
                <label for="TBDescripcion">Descripción</label>
                <asp:TextBox ID="TBDescripcion" runat="server" CssClass="form-control" MaxLength="100" />
            </div>

            <div class="form-group">
                <label for="ddlCliente">Cliente</label>
                <asp:DropDownList ID="ddlCliente" runat="server" CssClass="form-control" />
            </div>

            <asp:Label ID="LblMensaje" runat="server" CssClass="mensaje-error" />

            <div class="form-buttons">
                <asp:Button ID="BtnGuardar" runat="server" Text="Guardar" CssClass="btn" OnClick="BtnGuardar_Click" />
                <asp:Button ID="BtnActualizar" runat="server" Text="Actualizar" CssClass="btn btn-secondary" Visible="false" OnClick="BtnActualizar_Click" />
            </div>

            <h2>Lista de Pedidos</h2>
            <asp:GridView ID="GVPedido" runat="server" AutoGenerateColumns="false" CssClass="tabla" 
                OnSelectedIndexChanged="GVPedido_SelectedIndexChanged" OnRowDataBound="GVPedido_RowDataBound">
                <Columns>
                    <asp:BoundField DataField="IdPedido" HeaderText="ID" />
                    <asp:BoundField DataField="fechaPedido" HeaderText="Fecha" DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="false" />
                    <asp:BoundField DataField="descripcionPedido" HeaderText="Descripción" HtmlEncode="false"/>
                    <asp:BoundField DataField="IdCliente" HeaderText="DNI Cliente" />
                    <asp:CommandField ShowSelectButton="true" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
