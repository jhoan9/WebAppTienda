<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WFCategoria.aspx.cs" Inherits="Presentacion.WFCategoria" EnableEventValidation="false" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Gestión de Categorías</title>
    <link href="assets/styles/categoria.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1>Gestión de Categorías</h1>

            <div class="nav-links">
                <a href="Inicio.aspx">Inicio</a>
                <a href="WFArticulo.aspx">Artículo</a>
            </div>

            <asp:TextBox ID="TBId" runat="server" Visible="false"></asp:TextBox>

            <div class="form-group">
                <label for="TBNombreCategoria">Nombre Categoría</label>
                <asp:TextBox ID="TBNombreCategoria" runat="server"></asp:TextBox>
            </div>

            <div class="form-group">
                <label for="TBDescripcionCategoria">Descripción</label>
                <asp:TextBox ID="TBDescripcionCategoria" runat="server"></asp:TextBox>
            </div>

            <asp:Label ID="LblMensaje" runat="server" ForeColor="Red"></asp:Label><br /><br />

            <asp:Button ID="BtnGuardar" runat="server" Text="Guardar" OnClick="BtnGuardar_Click" />
            <asp:Button ID="BtnActualizar" runat="server" Text="Actualizar" OnClick="BtnActualizar_Click" Visible="false" />

            <div class="grid-container">
                <asp:GridView ID="GVCategoria" runat="server" 
                    CssClass="gridview"
                    AutoGenerateColumns="false" 
                    OnRowDataBound="GVCategoria_RowDataBound" 
                    OnSelectedIndexChanged="GVCategoria_SelectedIndexChanged">
                    <Columns>                    
                        <asp:BoundField DataField="IdCategoria" HeaderText="ID" />
                        <asp:BoundField DataField="nombreCategoria" HeaderText="Nombre" HtmlEncode="false"/>
                        <asp:BoundField DataField="descripcionCategoria" HeaderText="Descripción" HtmlEncode="false"/>
                        <asp:CommandField ShowSelectButton="True" Visible="false" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </form>
</body>
</html>
