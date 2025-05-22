<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WFArticulo.aspx.cs" Inherits="Presentacion.WFArticulo" ValidateRequest="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Gestión de Artículos</title>
    <link href="assets/styles/Articulo.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1>Gestión de Artículos</h1>
            
            <nav>
                <a href="Inicio.aspx">Inicio</a>
                <a href="WFCategoria.aspx">Categoría</a>
            </nav>

            <asp:TextBox ID="TBIdArticulo" runat="server" Visible="false"></asp:TextBox>

            <div class="form-group">
                <label for="TBNombre">Nombre del Artículo</label>
                <asp:TextBox ID="TBNombre" runat="server" CssClass="form-control" />
            </div>

            <div class="form-group">
                <label for="TBMarca">Marca</label>
                <asp:TextBox ID="TBMarca" runat="server" CssClass="form-control" />
            </div>

            <div class="form-group">
                <label for="TBPrecio">Precio</label>
                <asp:TextBox ID="TBPrecio" runat="server" CssClass="form-control" />
            </div>

            <div class="form-group">
                <label for="DDLEstado">Estado</label>
                <asp:DropDownList ID="DDLEstado" runat="server" CssClass="form-control">
                    <asp:ListItem Text="Seleccionar" Value="" />
                    <asp:ListItem Text="Nuevo" Value="nuevo" />
                    <asp:ListItem Text="Usado" Value="usado" />
                </asp:DropDownList>
            </div>

            <div class="form-group">
                <label for="DDLCategoria">Categoría</label>
                <asp:DropDownList ID="DDLCategoria" runat="server" CssClass="form-control" />
            </div>

            <asp:Label ID="LblMensaje" runat="server" CssClass="mensaje-error" />

            <div class="form-buttons">

                <asp:Button ID="BtnGuardar" runat="server" Text="Guardar" CssClass="btn" OnClick="BtnGuardar_Click" />
                <asp:Button ID="BtnActualizar" runat="server" Text="Actualizar" CssClass="btn btn-secundario" Visible="false" OnClick="BtnActualizar_Click" />
            </div>

            <h2>Lista de Artículos</h2>
            <asp:GridView ID="GVArticulo" runat="server" CssClass="tabla" AutoGenerateColumns="false" 
                          OnSelectedIndexChanged="GVArticulo_SelectedIndexChanged" OnRowDataBound="GVArticulo_RowDataBound">
                <Columns>
                    <asp:BoundField DataField="IdArticulo" HeaderText="ID" />
                    <asp:BoundField DataField="nombreArticulo" HeaderText="Nombre" />
                    <asp:BoundField DataField="marcaArticulo" HeaderText="Marca" />
                    <asp:BoundField DataField="precioArticulo" HeaderText="Precio" DataFormatString="{0:C}" />
                    <asp:BoundField DataField="estadoArticulo" HeaderText="Estado" />
                    <asp:BoundField DataField="idCategoria" HeaderText="ID Categoría" />
                    <asp:CommandField ShowSelectButton="true" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
