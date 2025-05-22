<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="Presentacion.Inicio" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Inicio</title>
    <link href="assets/styles/inicio.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1>Panel Principal</h1>

            <div class="nav-links">
                <a href="Inicio.aspx">Inicio</a>
                <a href="WFArticulo.aspx">Artículo</a>
                <a href="WFCategoria.aspx">Categoría</a>
                <a href="WFProveedor.aspx">Proveedor</a>
                <a href="WFCliente.aspx">Cliente</a>
                <a href="WFPedido.aspx">Pedido</a>
                <a href="WFPersona.aspx">Persona</a>
                <a href="WFArticuloPedido.aspx">Artículo Pedido</a>
            </div>
        </div>
    </form>
</body>
</html>
