<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Web_Presentacion.Account.Login" %>
<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %>.</h1>
    </hgroup>
    <section id="loginForm">
        
        <asp:Login runat="server" ViewStateMode="Disabled" RenderOuterTable="false">
        </asp:Login>
        <p>
            <asp:HyperLink runat="server" ID="RegisterHyperLink" ViewStateMode="Disabled">Registrarse</asp:HyperLink>
            si no tiene una cuenta.
        </p>
    </section>

    <section id="socialLoginForm">
        
        <uc:OpenAuthProviders runat="server" ID="OpenAuthLogin" />
    </section>
</asp:Content>
