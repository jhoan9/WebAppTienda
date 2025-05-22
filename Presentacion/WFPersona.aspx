<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WFPersona.aspx.cs" Inherits="Presentacion.WFPersona" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Gestión de Persona</title>
    <link href="assets/styles/Persona.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1>Gestión de Persona</h1>

            <nav>
                <a href="Inicio.aspx">Inicio</a>
                <a href="WFArticulo.aspx">Artículo</a>
                <a href="WFCategoria.aspx">Categoría</a>
                <a href="WFCliente.aspx">Cliente</a>
            </nav>

            <asp:TextBox ID="TBIdPersona" runat="server" Visible="false" />

            <div class="form-group">
                <label for="TBNombre">Nombre</label>
                <asp:TextBox ID="TBNombre" runat="server" CssClass="form-control" MaxLength="80" />
            </div>

            <div class="form-group">
                <label for="TBApellido">Apellido</label>
                <asp:TextBox ID="TBApellido" runat="server" CssClass="form-control" MaxLength="80" />
            </div>

            <div class="form-group">
                <label for="TBTelefono">Teléfono</label>
                <asp:TextBox ID="TBTelefono" runat="server" CssClass="form-control" MaxLength="30" />
            </div>

            <div class="form-group">
                <label for="TBDireccion">Dirección</label>
                <asp:TextBox ID="TBDireccion" runat="server" CssClass="form-control" MaxLength="70" />
            </div>

            <div class="form-group">
                <label for="TBEmail">Correo Electrónico</label>
                <asp:TextBox ID="TBEmail" runat="server" CssClass="form-control" MaxLength="100" />
            </div>

            <asp:Label ID="LblMensaje" runat="server" CssClass="mensaje-error" />

            <div class="form-buttons">
                <asp:Button ID="BtnGuardar" runat="server" Text="Guardar" CssClass="btn" OnClick="BtnGuardar_Click" />
                <asp:Button ID="BtnActualizar" runat="server" Text="Actualizar" CssClass="btn btn-secondary" Visible="false" OnClick="BtnActualizar_Click" />
            </div>

            <h2>Lista de Personas</h2>
            <asp:GridView ID="GVPersona" runat="server" CssClass="tabla" AutoGenerateColumns="false"
                OnSelectedIndexChanged="GVPersona_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="IdPersona" HeaderText="ID" />
                    <asp:BoundField DataField="nombrePersona" HeaderText="Nombre" />
                    <asp:BoundField DataField="apellidoPersona" HeaderText="Apellido" />
                    <asp:BoundField DataField="telefonoPersona" HeaderText="Teléfono" />
                    <asp:BoundField DataField="direccionPersona" HeaderText="Dirección" />
                    <asp:BoundField DataField="correoPersona" HeaderText="Correo Electrónico" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
