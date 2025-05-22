<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WFCliente.aspx.cs" Inherits="Presentacion.WFCliente" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Gestión de Cliente</title>
    <link href="assets/styles/Cliente.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1>Gestión de Clientes</h1>

            <nav>
                <a href="Inicio.aspx">Inicio</a>
                <a href="WFArticulo.aspx">Artículo</a>
                <a href="WFCategoria.aspx">Categoría</a>
                <a href="WFCliente.aspx">Cliente</a>
            </nav>

            <asp:TextBox ID="TBIdCliente" runat="server" Visible="false" />

            <div class="form-group">
                <label for="ddlTipo">Tipo de Cliente</label>
                <asp:DropDownList ID="ddlTipo" runat="server" CssClass="form-control">
                    <asp:ListItem Text="Empresa" Value="empresa" />
                    <asp:ListItem Text="Independiente" Value="independiente" />
                </asp:DropDownList>
            </div>

            <div class="form-group">
                <label for="ddlPersona">Persona</label>
                <asp:DropDownList ID="ddlPersona" runat="server" CssClass="form-control" />
            </div>

            <asp:Label ID="LblMensaje" runat="server" CssClass="mensaje-error" />

            <div class="form-group">
                <asp:Button ID="BtnGuardar" runat="server" Text="Guardar" CssClass="btn" OnClick="BtnGuardar_Click" />
                <asp:Button ID="BtnActualizar" runat="server" Text="Actualizar" CssClass="btn btn-secondary" Visible="false" OnClick="BtnActualizar_Click" />
            </div>

            <asp:GridView ID="GVCliente" runat="server" AutoGenerateColumns="false" CssClass="tabla"
                OnSelectedIndexChanged="GVCliente_SelectedIndexChanged" >
                <Columns>
                    <asp:BoundField DataField="IdCliente" HeaderText="ID" />
                    <asp:BoundField DataField="tipoCliente" HeaderText="Tipo" />
                    <asp:BoundField DataField="nombrePersona" HeaderText="Nombre Completo" />
                    <asp:BoundField DataField="IdPersona" HeaderText="ID Persona" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
