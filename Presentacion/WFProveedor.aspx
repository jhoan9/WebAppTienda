<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WFProveedor.aspx.cs" Inherits="Presentacion.WFProveedor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Gestión de Proveedores</title>
    <link href="assets/styles/Proveedor.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="container">
        <h1>Gestión de Proveedores</h1>

        <nav>
            <a href="Inicio.aspx">Inicio</a>
            <a href="WFArticulo.aspx">Artículo</a>
            <a href="WFCategoria.aspx">Categoría</a>
            <a href="WFCliente.aspx">Cliente</a>
        </nav>

        <asp:TextBox ID="TBIdProveedor" runat="server" Visible="false"></asp:TextBox>

        <div class="form-group">
            <label for="ddlPersona">Persona</label>
            <asp:DropDownList ID="ddlPersona" runat="server" CssClass="form-control" />
        </div>

        <div class="form-group">
            <label for="ddlEstado">Estado</label>
            <asp:DropDownList ID="ddlEstado" runat="server" CssClass="form-control">
                <asp:ListItem Text="activo" Value="activo" />
                <asp:ListItem Text="inactivo" Value="inactivo" />
            </asp:DropDownList>
        </div>

        <asp:Label ID="LblMensaje" runat="server" CssClass="mensaje-error" />

        <div class="form-buttons">
            <asp:Button ID="BtnGuardar" runat="server" Text="Guardar" CssClass="btn" OnClick="BtnGuardar_Click" />
            <asp:Button ID="BtnActualizar" runat="server" Text="Actualizar" CssClass="btn btn-secundario" Visible="false" OnClick="BtnActualizar_Click" />
        </div>

        <h2>Lista de Proveedores</h2>
        <asp:GridView ID="GVProveedor" runat="server" CssClass="tabla" AutoGenerateColumns="false"
            OnSelectedIndexChanged="GVProveedor_SelectedIndexChanged" OnRowDataBound="GVProveedor_RowDataBound">
            <Columns>
                <asp:BoundField DataField="idproveedor" HeaderText="ID" />
                <asp:BoundField DataField="per_nombre" HeaderText="Nombre Completo" />
                <asp:BoundField DataField="per_telefono" HeaderText="Teléfono" />
                <asp:BoundField DataField="per_direccion" HeaderText="Dirección" />
                <asp:BoundField DataField="per_correo" HeaderText="Correo" />
                <asp:BoundField DataField="pro_estado" HeaderText="Estado" />
                <asp:BoundField DataField="IdPersona" HeaderText="ID Persona" />
                 <asp:CommandField ShowSelectButton="true" />
            </Columns>
        </asp:GridView>
    </div>
</form>

</body>
</html>
