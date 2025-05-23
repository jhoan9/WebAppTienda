<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WFPersona.aspx.cs" Inherits="Presentacion.WFPersona" ValidateRequest="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
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

            <asp:TextBox ID="TBIdPersona" runat="server" Visible="false"></asp:TextBox>

            <div class="form-group">
                <label for="TBNombre">Nombre</label>
                <asp:TextBox ID="TBNombre" runat="server" CssClass="form-control" />
            </div>

            <div class="form-group">
                <label for="TBApellido">Apellido</label>
                <asp:TextBox ID="TBApellido" runat="server" CssClass="form-control" />
            </div>

            <div class="form-group">
                <label for="TBTelefono">Telefono</label>
                <asp:TextBox ID="TBTelefono" runat="server" CssClass="form-control" />
            </div>

            <div class="form-group">
                <label for="TBDireccion">Direccion</label>
                <asp:TextBox ID="TBDireccion" runat="server" CssClass="form-control" />
            </div>

            <div class="form-group">
                <label for="TBEmail">Correo Electronico</label>
                <asp:TextBox ID="TBEmail" runat="server" CssClass="form-control" />
            </div>

            <asp:Label ID="LblMensaje" runat="server" CssClass="mensaje-error" />

            <div class="form-buttons">
                <asp:Button ID="BtnGuardar" runat="server" OnClick="BtnGuardar_Click" Text="Guardar" CssClass="btn" />
                <asp:Button ID="BtnActualizar" runat="server" Text="Actualizar" CssClass="btn btn-secundario" OnClick="BtnActualizar_Click" />
            </div>

            <h2>Lista de Personas</h2>
            <asp:GridView ID="GVPersona" runat="server" CssClass="tabla" AutoGenerateColumns="false"
                OnSelectedIndexChanged="GVPersona_SelectedIndexChanged" OnRowDataBound="GVPersona_RowDataBound">

                <Columns>
                    <asp:BoundField DataField="IdPersona" HeaderText="ID    " />
                    <asp:BoundField DataField="nombrePersona" HeaderText="Nombre" />
                    <asp:BoundField DataField="apellidoPersona" HeaderText="Apellido" />
                    <asp:BoundField DataField="telefonoPersona" HeaderText="Teléfono" />
                    <asp:BoundField DataField="direccionPersona" HeaderText="Dirección" />
                    <asp:BoundField DataField="correoPersona" HeaderText="Correo Electrónico" />
                    <asp:CommandField ShowSelectButton="true" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
