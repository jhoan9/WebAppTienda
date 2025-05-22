<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WFArticulo.aspx.cs" Inherits="Presentacion.WFArticulo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Articulo</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Soy Articulo</h1>
            <a href="Inicio.aspx">Inicio</a><br/>
            <a href="WFCategoria.aspx">Categoria</a>

            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:GridView ID="GVArticulo" runat="server"></asp:GridView>
        </div>
    </form>
</body>
</html>
