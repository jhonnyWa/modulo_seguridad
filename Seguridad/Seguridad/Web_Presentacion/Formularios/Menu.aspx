<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="Web_Presentacion.Formularios.Menu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 71%;
        }
        .auto-style2 {
            width: 93px;
        }
        .auto-style3 {
            width: 333px;
        }
        .auto-style4 {
            font-size: x-large;
            text-decoration: underline;
            color: #33CCFF;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <table class="auto-style1">
        <tr>
            <td>&nbsp;</td>
        </tr>
        </table>
    <p class="auto-style4" style="text-align: center; width: 765px;">
        <strong>MANTENIMIENTO DE MENUS</strong></p>
    <table class="auto-style1">
        <tr>
            <td colspan="4">&nbsp;</td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:Button ID="btn_nuevo" runat="server" OnClick="btn_nuevo_Click" Text="NUEVO" />
                <asp:Button ID="btn_guardar" runat="server" OnClick="btn_guardar_Click" Text="GUARDAR" />
                <asp:Button ID="btn_eliminar" runat="server" OnClick="btn_eliminar_Click" Text="ELIMINAR" />
                <asp:Button ID="btn_buscar" runat="server" OnClick="btn_buscar_Click" Text="BUSCAR" />
                <asp:Button ID="btn_cancelar" runat="server" OnClick="btn_cancelar_Click" Text="CANCELAR" />
            </td>
        </tr>
        <tr>
            <td class="auto-style2">CODIGO:</td>
            <td class="auto-style3">
                <asp:TextBox ID="txt_codigo" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style2">NOMBRE:</td>
            <td>
                <asp:TextBox ID="txt_nombre" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">LINK:</td>
            <td class="auto-style3">
                <asp:TextBox ID="txt_link" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style2">GRUPO:</td>
            <td>
                <asp:TextBox ID="txt_grupo" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                FUNCION:</td>
            <td>
                <asp:TextBox ID="txt_funcion" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="4">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:Label ID="lbl_titulo" runat="server" Text="OPCIONES DE BUSQUEDA"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:CheckBox ID="check_todos" runat="server" AutoPostBack="True" Font-Size="6pt" OnCheckedChanged="check_todos_CheckedChanged" Text="TODOS" />
            </td>
            <td colspan="2">
                <asp:DropDownList ID="ddlis_tipo" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlis_tipo_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:CheckBox ID="check_tipo" runat="server" AutoPostBack="True" Font-Size="6pt" OnCheckedChanged="check_tipo_CheckedChanged" Text="GRUPO DE MENU" />
            </td>
            <td colspan="2">
                <asp:Label ID="lbl_buscar" runat="server" Text="INGRESE PARTE DEL DATO A BUSCAR"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:CheckBox ID="check_filtrar" runat="server" AutoPostBack="True" Font-Size="6pt" OnCheckedChanged="check_filtrar_CheckedChanged" Text="FILTRAR" />
            </td>
            <td colspan="2">
                <asp:TextBox ID="txt_filtrar" runat="server" AutoPostBack="True" OnTextChanged="txt_filtrar_TextChanged"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:GridView ID="gv_menu" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gv_menu_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="id_menu" HeaderText="CODIGO" />
                        <asp:BoundField DataField="nom_men" HeaderText="NOMBRE" />
                        <asp:BoundField DataField="link_men" HeaderText="LINK" />
                        <asp:BoundField DataField="gru_men" HeaderText="GRUPO" />
                        <asp:BoundField DataField="fun_men" HeaderText="FUNCION" />
                        <asp:CommandField ShowSelectButton="True" />
                    </Columns>
                </asp:GridView>
                <asp:Label ID="lbl_opciones" runat="server" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="4">&nbsp;</td>
        </tr>
        <tr>
            <td colspan="4">&nbsp;</td>
        </tr>
    </table>
</asp:Content>
