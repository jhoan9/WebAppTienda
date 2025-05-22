<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WFPedido.aspx.cs" Inherits="Presentacion.WFPedido" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Pedido</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Gestion de Pedido</h1>

            <a href="Inicio.aspx">Inicio</a><br />
            <a href="WFArticulo.aspx">Articulo</a><br />
            <a href="WFCategoria.aspx">Categoria</a><br />
            <a href="WFCliente.aspx">Cliente</a><br />

            <asp:GridView ID="GVPedido" runat="server"></asp:GridView>
        </div>
    </form>
</body>
</html>
