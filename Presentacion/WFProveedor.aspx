<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WFProveedor.aspx.cs" Inherits="Presentacion.WFProveedor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Proveedor</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Gestion de Proveedor</h1>

            <a href="Inicio.aspx">Inicio</a><br />
            <a href="WFArticulo.aspx">Articulo</a><br />
            <a href="WFCategoria.aspx">Categoria</a><br />
            <a href="WFCliente.aspx">Cliente</a><br />

            <asp:GridView ID="GVProveedor" runat="server"></asp:GridView>
        </div>
    </form>
</body>
</html>
