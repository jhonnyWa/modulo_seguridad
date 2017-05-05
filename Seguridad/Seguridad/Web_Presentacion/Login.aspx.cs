using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using System.Web.Security;

namespace Web_Presentacion.Formularios
{
    public partial class Login : System.Web.UI.Page
    {
        ManejadorUsuario Muser = new ManejadorUsuario();
        //funcion para mostrar mensajes
        private void mostrarMensaje(string mensaje)
        {
            Response.Write("<script languaje='JavaScript'>alert('" + mensaje.ToString() + "');</script>");

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Application["Privilegio"] = "";
            }
        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            if (IsValid)
            {
                try
                {
                    string[] usuario = {
                                           Login1.UserName,
                                           Login1.Password
                                       };
                    DataSet dsUsuario = new DataSet();
                    dsUsuario = Muser.conectarUsuario(usuario);

                    DataTable dtUsuario = new DataTable();
                    dtUsuario = dsUsuario.Tables[0];

                    if (dtUsuario.Rows.Count != 0 && dtUsuario != null)
                    {

                        foreach (DataRow drDataRow in dtUsuario.Rows)
                        {
                            mostrarMensaje("Bienvenido :  " + drDataRow[5].ToString());
                           
                            FormsAuthentication.RedirectFromLoginPage(Login1.UserName, Login1.RememberMeSet);

                            Application["Privilegio"] = drDataRow[1].ToString();
                            Response.Redirect("~/Formularios/Inicio.aspx");
                            //    IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                           
                        }

                    }
                    else
                    {
                        mostrarMensaje("NO SE ENCONTRO COINCIDENCIAS");

                    }

                }
                catch (Exception ex)
                {
                    mostrarMensaje(ex.Message.ToString());
                }
            }

        }
    }
}