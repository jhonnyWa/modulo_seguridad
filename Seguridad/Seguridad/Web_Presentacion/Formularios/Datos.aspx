<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Datos.aspx.cs" Inherits="Web_Presentacion.Formularios.Datos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 72%;
        }
        .auto-style2 {
            width: 93px;
        }
        .auto-style3 {
            width: 333px;
        }
        .auto-style5 {
            height: 49px;
        }
        .auto-style6 {
            height: 23px;
        }
        .auto-style7 {
            text-decoration: underline;
            color: #00CCFF;
        }
        .auto-style8 {
            width: 93px;
            text-align: center;
        }
        .auto-style9 {
            width: 444px;
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
    <h1 class="auto-style7" style="text-align: center; width: 554px; margin-left: 88px;">
        <strong>MANTENIMIENTO DE DATOS</strong></h1>
    <table class="auto-style1">
        <tr>
            <td colspan="4">&nbsp;</td>
        </tr>
        <tr>
            <td colspan="4" class="auto-style5">
                <asp:Button ID="btn_nuevo" runat="server" OnClick="btn_nuevo_Click" Text="NUEVO" />
                <asp:Button ID="btn_guardar" runat="server" OnClick="btn_guardar_Click" Text="GUARDAR" />
                <asp:Button ID="btn_eliminar" runat="server" OnClick="btn_eliminar_Click" Text="ELIMINAR" />
                <asp:Button ID="btn_buscar" runat="server" OnClick="btn_buscar_Click" Text="BUSCAR" />
                <asp:Button ID="btn_cancelar" runat="server" OnClick="btn_cancelar_Click" Text="CANCELAR" />
            </td>
        </tr>
        <tr>
            <td class="auto-style8">CODIGO:</td>
            <td class="auto-style3">
                <asp:TextBox ID="txt_codigo" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style8">NOMBRE:</td>
            <td class="auto-style9">
                <asp:TextBox ID="txt_nombre" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style8">TIPO:</td>
            <td class="auto-style3">
                <asp:TextBox ID="txt_tipo" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style8">VALOR:</td>
            <td class="auto-style9">
                <asp:TextBox ID="txt_valor" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="4" class="auto-style6">
                </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:Label ID="lbl_titulo" runat="server" Text="OPCIONES DE BUSQUEDA" style="color: #000000"></asp:Label>
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
                <asp:CheckBox ID="check_tipo" runat="server" AutoPostBack="True" Font-Size="6pt" OnCheckedChanged="check_tipo_CheckedChanged" Text="TIPO DE REGISTRO" />
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
                <asp:GridView ID="gv_datos" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gvDatos_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="cod_segdat" HeaderText="CODIGO" />
                        <asp:BoundField DataField="nom_segdat" HeaderText="NOMBRE" />
                        <asp:BoundField DataField="tip_segdat" HeaderText="TIPO" />
                        <asp:BoundField DataField="val_segdat" HeaderText="VALOR" />
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
