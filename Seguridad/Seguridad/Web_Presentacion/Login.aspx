<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Web_Presentacion.Formularios.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
    .auto-style1 {
        width: 100%;
    }
    .auto-style2 {
        width: 334px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <table class="auto-style1">
    <tr>
        <td class="auto-style2">&nbsp;</td>
        <td>
            <br />
            <br />
            <br />
            <asp:Login ID="Login1" runat="server" OnAuthenticate="Login1_Authenticate">
            </asp:Login>
        </td>
        <td>&nbsp;</td>
    </tr>
</table>
</asp:Content>
