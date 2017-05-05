<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Permisos.aspx.cs" Inherits="Web_Presentacion.Formularios.Permisos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
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
            color: #00FFFF;
        }
        .auto-style5 {
            width: 439px;
        }
        .auto-style6 {
            height: 49px;
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
    <p class="auto-style4" style="text-align: center; width: 465px; margin-left: 168px;">
        <strong>MANTENIMIENTO DE PERMISOS</strong></p>
    <table class="auto-style1">
        <tr>
            <td colspan="4">&nbsp;</td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:Button ID="btn_nuevo" runat="server" OnClick="btn_nuevo_Click" Text="NUEVO" />
                <asp:Button ID="btn_guardar" runat="server" OnClick="btn_guardar_Click" Text="GUARDAR" />
                <asp:Button ID="btn_eliminar" runat="server" Text="ELIMINAR" OnClick="btn_eliminar_Click" />
                <asp:Button ID="btn_buscar" runat="server" Text="BUSCAR" OnClick="btn_buscar_Click" />
                <asp:Button ID="btn_cancelar" runat="server" Text="CANCELAR" OnClick="btn_cancelar_Click" />
            </td>
        </tr>
        <tr>
            <td class="auto-style2">MENU:</td>
            <td class="auto-style3">
                <asp:DropDownList ID="ddlis_menu" runat="server">
                </asp:DropDownList>
            </td>
            <td class="auto-style2">PERFIL:</td>
            <td class="auto-style5">
                <asp:DropDownList ID="ddlis_perfil" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">ESTADO:</td>
            <td class="auto-style3">
                <asp:CheckBox ID="check_estado" runat="server" AutoPostBack="True" OnCheckedChanged="check_estado_CheckedChanged" />
            </td>
            <td class="auto-style2">
                <asp:Label ID="lbl_estado" runat="server" Text="0"></asp:Label>
            </td>
            <td class="auto-style5">
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
            <td colspan="2" class="auto-style6">
                <asp:CheckBox ID="check_todos" runat="server" AutoPostBack="True" Font-Size="6pt" Text="TODOS" OnCheckedChanged="check_todos_CheckedChanged" />
            </td>
            <td colspan="2" class="auto-style6">
                </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:CheckBox ID="check_xper" runat="server" AutoPostBack="True" Font-Size="6pt" Text="POR PERFIL" OnCheckedChanged="check_xper_CheckedChanged" />
            </td>
            <td colspan="2">
                <asp:DropDownList ID="ddlis_xper" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlis_xper_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;</td>
            <td colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:GridView ID="gv_permisos" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="cod_per" HeaderText="CODIGO" />
                        <asp:BoundField DataField="cod_men" HeaderText="COD_MENU" />
                        <asp:BoundField DataField="cod_rol" HeaderText="COD_ROL" />
                        <asp:BoundField DataField="est_rol" HeaderText="ESTADO" />
                        <asp:TemplateField HeaderText="PMS">
                            <ItemTemplate>
                                <asp:CheckBox ID="check_permiso" runat="server" AutoPostBack="True" OnCheckedChanged="check_permiso_CheckedChanged" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="menu" HeaderText="MENU" />
                        <asp:BoundField DataField="rol" HeaderText="ROL" />
                        <asp:CommandField ShowSelectButton="True" />
                    </Columns>
                </asp:GridView>
                <asp:Label ID="lbl_opciones" runat="server" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="4">&nbsp;</td>
        </tr>
    </table>
</asp:Content>
