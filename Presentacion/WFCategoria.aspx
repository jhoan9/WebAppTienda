<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WFCategoria.aspx.cs" Inherits="Presentacion.WFCategoria" EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Categoria</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Gestion de Categorias</h1>

            <a href="Inicio.aspx">Inicio</a><br />
            <a href="WFArticulo.aspx">Articulo</a><br />
            <asp:TextBox ID="TBId" runat="server" Visible="false"></asp:TextBox><br />

            <asp:Label ID="Label1" runat="server" Text="Nombre Categoria"></asp:Label><br />
            <asp:TextBox ID="TBNombreCategoria" runat="server"></asp:TextBox><br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Descripción"></asp:Label><br />
            <asp:TextBox ID="TBDescripcionCategoria" runat="server"></asp:TextBox><br />
            <br />

            <asp:Label ID="LblMensaje" runat="server" ForeColor="Red"></asp:Label><br /><br />

            <asp:Button ID="BtnGuardar" runat="server" Text="Guardar" OnClick="BtnGuardar_Click" />
            <asp:Button ID="BtnActualizar" runat="server" Text="Actualizar" OnClick="BtnActualizar_Click" Visible="false" /><br />
            <br />
            <asp:GridView ID="GVCategoria" runat="server" 
                OnRowDataBound="GVCategoria_RowDataBound" 
                AutoGenerateColumns="false" 
                OnSelectedIndexChanged="GVCategoria_SelectedIndexChanged">
                <Columns>                    
                    <asp:BoundField DataField="IdCategoria" HeaderText="ID" />
                    <asp:BoundField DataField="nombreCategoria" HeaderText="Nombre"  HtmlEncode="false"/>
                    <asp:BoundField DataField="descripcionCategoria" HeaderText="Descripción"  HtmlEncode="false"/>
                    <asp:CommandField ShowSelectButton="True" Visible="false" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
