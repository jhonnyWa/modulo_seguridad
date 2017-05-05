<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Persona.aspx.cs" Inherits="Web_Presentacion.Formularios.Persona" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        background-color: #999999;
    }
        .auto-style2 {
            width: 93px;
        }
        .auto-style5 {
            height: 47px;
        }
        .auto-style6 {
            height: 49px;
        }
        .auto-style7 {
            text-decoration: underline;
            color: #00CCFF;
        background-color: #FFFFFF;
    }
    .auto-style8 {
        height: 47px;
        width: 121px;
    }
    .auto-style9 {
        background-color: #FFFFFF;
    }
    .auto-style10 {
        width: 67px;
        text-align: center;
        color: #000000;
    }
    .auto-style11 {
        width: 275px;
        color: #99FF99;
    }
    .auto-style12 {
        width: 38px;
        text-align: center;
        color: #000000;
    }
    .auto-style13 {
        width: 38px;
        color: #000000;
    }
    .auto-style14 {
        height: 47px;
        width: 38px;
        color: #000000;
    }
    .auto-style15 {
        width: 275px;
    }
    .auto-style16 {
        height: 47px;
        width: 275px;
    }
    .auto-style17 {
        width: 67px;
        color: #000000;
    }
    .auto-style18 {
        height: 47px;
        width: 67px;
        color: #000000;
    }
    .auto-style19 {
        width: 121px;
    }
    .auto-style21 {
        color: #000000;
    }
    .auto-style22 {
        color: #000000;
        background-color: #FFFFFF;
    }
    .auto-style23 {
        height: 49px;
        background-color: #808080;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <script>
        function soloNumeros(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                alert("DIGITE SOLO NUMEROS..!!");
                return false;
            }
            return true;
        }

        function soloLetras(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 32 && (charCode < 46 || charCode > 46) && (charCode < 65 || charCode > 90) &&
          (charCode < 97 || charCode > 122)) {
                alert("DIGITE SOLO LETRAS..!!");
                return false;
            }
            return true;
        }
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <table class="auto-style1">
        <tr>
            <td>&nbsp;</td>
        </tr>
        </table>
    <h1 class="auto-style7" style="text-align: center">
        <strong>MANTENIMIENTO DE PERSONA</strong></h1>
    <table class="auto-style1">
        <tr>
            <td>&nbsp;</td>
            <td colspan="4" class="auto-style9">&nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td colspan="4" class="auto-style9">
                <asp:Button ID="btn_nuevo" runat="server" OnClick="btn_nuevo_Click" Text="NUEVO" />
                <asp:Button ID="btn_guardar" runat="server" OnClick="btn_guardar_Click" Text="GUARDAR" />
                <asp:Button ID="btn_eliminar" runat="server" OnClick="btn_eliminar_Click" Text="ELIMINAR" />
                <asp:Button ID="btn_buscar" runat="server" OnClick="btn_buscar_Click" Text="BUSCAR" />
                <asp:Button ID="btn_cancelar" runat="server" OnClick="btn_cancelar_Click" Text="CANCELAR" />
            </td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style12">NOMBRE:</td>
            <td class="auto-style11">
                <asp:TextBox ID="txt_nombre" onkeypress="return soloLetras(event)" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style10">CELULAR:</td>
            <td class="auto-style19">
                <asp:TextBox ID="txt_celular" onkeypress="return soloNumeros(event)" runat="server" MaxLength="10"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style12">APELIDO:</td>
            <td class="auto-style11">
                <asp:TextBox ID="txt_apellido" onkeypress="return soloLetras(event)" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style10">EMAIL:</td>
            <td class="auto-style19">
                <asp:TextBox ID="txt_email" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td class="auto-style13">
                CEDULA:</td>
            <td class="auto-style15">
                <asp:TextBox ID="txt_cedula" onkeypress="return soloNumeros(event)" runat="server" MaxLength="10"></asp:TextBox>
            </td>
            <td class="auto-style17">
                GENERO:</td>
            <td class="auto-style19">
                <asp:DropDownList ID="ddlis_genero" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlis_genero_SelectedIndexChanged" CssClass="featured">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td class="auto-style13">
                DIRECCION:</td>
            <td class="auto-style15">
                <asp:TextBox ID="txt_direccion" onkeypress="return soloLetras(event)" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style17">
                NACIONALIDAD:</td>
            <td class="auto-style19">
                <asp:DropDownList ID="ddlis_nacionalidad" runat="server" AutoPostBack="True" CssClass="featured">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style5">
                &nbsp;</td>
            <td class="auto-style14">
                TELEFONO:</td>
            <td class="auto-style16">
                <asp:TextBox ID="txt_telefono" onkeypress="return soloNumeros(event)" runat="server" MaxLength="9"></asp:TextBox>
            </td>
            <td class="auto-style18">
                FECHA-NACIMIENTO:</td>
            <td class="auto-style8">
                <asp:DropDownList ID="ddlis_dia" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlis_dia_SelectedIndexChanged" CssClass="featured">
                    <asp:ListItem>Seleccione</asp:ListItem>
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                    <asp:ListItem>5</asp:ListItem>
                    <asp:ListItem Value="6"></asp:ListItem>
                    <asp:ListItem>7</asp:ListItem>
                    <asp:ListItem>8</asp:ListItem>
                    <asp:ListItem>9</asp:ListItem>
                    <asp:ListItem>10</asp:ListItem>
                    <asp:ListItem>11</asp:ListItem>
                    <asp:ListItem>12</asp:ListItem>
                    <asp:ListItem>13</asp:ListItem>
                    <asp:ListItem>14</asp:ListItem>
                    <asp:ListItem>15</asp:ListItem>
                    <asp:ListItem>16</asp:ListItem>
                    <asp:ListItem>17</asp:ListItem>
                    <asp:ListItem Value="18"></asp:ListItem>
                    <asp:ListItem>19</asp:ListItem>
                    <asp:ListItem>20</asp:ListItem>
                    <asp:ListItem>21</asp:ListItem>
                    <asp:ListItem>22</asp:ListItem>
                    <asp:ListItem>23</asp:ListItem>
                    <asp:ListItem>24</asp:ListItem>
                    <asp:ListItem>25</asp:ListItem>
                    <asp:ListItem>26</asp:ListItem>
                    <asp:ListItem>27</asp:ListItem>
                    <asp:ListItem>28</asp:ListItem>
                    <asp:ListItem>29</asp:ListItem>
                    <asp:ListItem>30</asp:ListItem>
                    <asp:ListItem>31</asp:ListItem>
                </asp:DropDownList>
                <asp:DropDownList ID="ddlis_mes" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlis_mes_SelectedIndexChanged" CssClass="featured">
                    <asp:ListItem>Seleccione</asp:ListItem>
                    <asp:ListItem Value="1">ENERO</asp:ListItem>
                    <asp:ListItem Value="2">FEBRERO</asp:ListItem>
                    <asp:ListItem Value="3">MARZO</asp:ListItem>
                    <asp:ListItem Value="4">ABRIL</asp:ListItem>
                    <asp:ListItem Value="5">MAYO</asp:ListItem>
                    <asp:ListItem Value="6">JUNIO</asp:ListItem>
                    <asp:ListItem Value="7">JULIO</asp:ListItem>
                    <asp:ListItem Value="8">AGOSTO</asp:ListItem>
                    <asp:ListItem Value="9">SEPTIEMBRE</asp:ListItem>
                    <asp:ListItem Value="10">OCTUBRE</asp:ListItem>
                    <asp:ListItem Value="11">NOVIEMBRE</asp:ListItem>
                    <asp:ListItem Value="12">DICIEMBRE</asp:ListItem>
                </asp:DropDownList>
                <asp:DropDownList ID="ddlis_año" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlis_año_SelectedIndexChanged" CssClass="featured">
                    <asp:ListItem>Seleccione</asp:ListItem>
                    <asp:ListItem>1980</asp:ListItem>
                    <asp:ListItem>1981</asp:ListItem>
                    <asp:ListItem>1982</asp:ListItem>
                    <asp:ListItem>1983</asp:ListItem>
                    <asp:ListItem>1984</asp:ListItem>
                    <asp:ListItem>1985</asp:ListItem>
                    <asp:ListItem>1986</asp:ListItem>
                    <asp:ListItem>1987</asp:ListItem>
                    <asp:ListItem>1988</asp:ListItem>
                    <asp:ListItem>1989</asp:ListItem>
                    <asp:ListItem>1990</asp:ListItem>
                    <asp:ListItem>1991</asp:ListItem>
                    <asp:ListItem>1992</asp:ListItem>
                    <asp:ListItem>1993</asp:ListItem>
                    <asp:ListItem>1994</asp:ListItem>
                    <asp:ListItem>1995</asp:ListItem>
                    <asp:ListItem>1996</asp:ListItem>
                    <asp:ListItem>1997</asp:ListItem>
                    <asp:ListItem>1998</asp:ListItem>
                    <asp:ListItem>1999</asp:ListItem>
                    <asp:ListItem>2000</asp:ListItem>
                </asp:DropDownList>
            &nbsp;<asp:Label ID="lbl_nacimiento" runat="server" CssClass="auto-style22"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td colspan="4" class="auto-style22">
                <span class="auto-style22">FOTO:&nbsp;&nbsp;&nbsp;
                </span>
                <asp:FileUpload ID="fileup_imagen" runat="server" Width="324px" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td colspan="4" class="auto-style9">
                <asp:Button ID="btn_ver" runat="server" OnClick="btn_ver_Click" Text="VER" />
&nbsp;<span class="auto-style21"><asp:ImageMap ID="imap_foto" runat="server" Height="113px" Width="112px" BorderStyle="Double" style="background-color: #FFFFFF">
                </asp:ImageMap>
                <asp:Label ID="lbl_direccionfoto" runat="server" CssClass="featured"></asp:Label>
                </span>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td colspan="4" class="featured">
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td colspan="4" class="featured">
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td colspan="4" class="featured">
                <asp:Label ID="lbl_titulo" runat="server" Text="OPCIONES DE BUSQUEDA" CssClass="featured"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td colspan="2" class="auto-style9">
                <asp:CheckBox ID="check_todo" runat="server" AutoPostBack="True" Font-Size="6pt" OnCheckedChanged="check_todos_CheckedChanged" Text="TODOS" />
            </td>
            <td colspan="2" class="auto-style9">
                <asp:DropDownList ID="ddlis_tipo" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlis_tipo_SelectedIndexChanged" CssClass="featured">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td colspan="2" class="auto-style9">
                <asp:CheckBox ID="check_tipo" runat="server" AutoPostBack="True" Font-Size="6pt" OnCheckedChanged="check_tipo_CheckedChanged" Text="NACIONALIDAD" />
            </td>
            <td colspan="2" class="featured">
                <asp:Label ID="lbl_buscar" runat="server" Text="INGRESE PARTE DEL DATO A BUSCAR" CssClass="featured"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style6">
                </td>
            <td colspan="2" class="auto-style23">
                <asp:CheckBox ID="check_filtrar" runat="server" AutoPostBack="True" Font-Size="6pt" OnCheckedChanged="check_filtrar_CheckedChanged" Text="FILTRAR" />
            </td>
            <td colspan="2" class="auto-style23">
                <asp:TextBox ID="txt_filtrar" runat="server" AutoPostBack="True" OnTextChanged="txt_filtrar_TextChanged"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td colspan="4">
                <asp:GridView ID="gv_persona" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gv_persona_SelectedIndexChanged" CssClass="featured" Height="145px">
                    <Columns>
                        <asp:BoundField DataField="id_persona" HeaderText="CODIGO" >
                        <HeaderStyle Font-Size="10pt" />
                        </asp:BoundField>
                        <asp:BoundField DataField="nom_persona" HeaderText="NOMBRE" >
                        <HeaderStyle Font-Size="10pt" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ape_persona" HeaderText="APELLIDO" >
                        <HeaderStyle Font-Size="10pt" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ced_persona" HeaderText="CEDULA" >
                        <HeaderStyle Font-Size="10pt" />
                        </asp:BoundField>
                        <asp:BoundField DataField="dir_perdona" HeaderText="DIRECCION">
                        <HeaderStyle Font-Size="10pt" />
                        </asp:BoundField>
                        <asp:BoundField DataField="tel_persona" HeaderText="TELEFONO">
                        <HeaderStyle Font-Size="10pt" />
                        </asp:BoundField>
                        <asp:BoundField DataField="cel_persona" HeaderText="CELULAR" />
                        <asp:BoundField DataField="ema_persona" HeaderText="EMAIL" />
                        <asp:BoundField DataField="gen_persona" HeaderText="GENERO" />
                        <asp:BoundField DataField="genero_persona" HeaderText="GENERO" />
                        <asp:BoundField DataField="nac_persona" HeaderText="NACIONALIDAD">
                        <HeaderStyle Font-Size="7pt" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="nacionalidad_persona" HeaderText="NACIONALIDAD" />
                        <asp:BoundField DataField="fecnac_persona" HeaderText="F.NACIMIENTO">
                        <FooterStyle BackColor="#CC0066" />
                        <HeaderStyle Font-Size="7pt" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="fot_persona" HeaderText="FOTO" />
                        <asp:CommandField ShowSelectButton="True" />
                    </Columns>
                </asp:GridView>
                <asp:Label ID="lbl_id" runat="server" CssClass="featured"></asp:Label>
                <br class="featured" />
                <asp:Label ID="lbl_opciones" runat="server" Visible="False" CssClass="featured"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td colspan="4">&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td colspan="4">&nbsp;</td>
        </tr>
    </table>
</asp:Content>