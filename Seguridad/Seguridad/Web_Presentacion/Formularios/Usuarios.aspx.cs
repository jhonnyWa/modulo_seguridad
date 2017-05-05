using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace Web_Presentacion.Formularios
{
    public partial class Usuarios : System.Web.UI.Page
    {
        ManejadorUsuario Muser = new ManejadorUsuario();
        private void validarpass()
        {
            string pass = txt_password.Text;
            char[] caracteres = pass.ToArray();
            if (caracteres.Length < 8)
            {
                string script = @"<script type='text/javascript'>alert('NUEVO PASSWORD DEMACIADO CORTO..!! MINIMO 8 CARACTERES');</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", script, false);
                txt_password.Text = "";
            }
            else
            {
                char[] MAYUSCULAS ={'A','B','C','D','E','F','G','H','I','J','K','L','M','N',
                                        'O','P','Q','R','S','T','U','V','W','X','Y','Z'};
                char[] NUMEROS = { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
                string letras = "";
                string numeros = "";
                string cadena = txt_password.Text;
                //for para verificar existe letras//
                for (int i = 0; i < 26; i++)
                {

                    if (cadena.IndexOf(MAYUSCULAS[i]) != -1)
                    {
                        i = 26;
                        letras = "si";
                    }
                }
                //for para identificar si esxiste numeros//
                for (int j = 0; j < 10; j++)
                {

                    if (cadena.IndexOf(NUMEROS[j]) != -1)
                    {
                        j = 10;
                        numeros = "si";
                    }
                }
                //si existen numero y letras//
                if (letras == "si" && numeros == "si")
                {

                }
                else
                {
                    string script = @"<script type='text/javascript'>alert('Los Passwords Deben tener Minimo 1 letra MAYUSCULA y 1 NUMERO..!!');</script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", script, false);
                    txt_password.Text = "";
                    txt_password.Focus();
                }


            }
        }

        //bloquear y desbloquear cajas de texto
        private void bloquear()
        {
            txt_nombre.Enabled = false;
            txt_password.Enabled = false;
            txt_codigo.Enabled = false;
            ddlis_rol.Enabled = false;
            check_activo.Enabled = false;
            check_inactivo.Enabled = false;
        }
        private void desbloquear()
        {
            txt_nombre.Enabled = true;
            txt_password.Enabled = true;
            txt_codigo.Enabled = true;
            ddlis_rol.Enabled = true;
            check_activo.Enabled = true;
            check_inactivo.Enabled = true;
        }
        //ocultar y desocultar opciones busqueda
        private void ocultar()
        {
            check_todos.Visible = false;
            check_tipo.Visible = false;
            check_filtrar.Visible = false;
            lbl_titulo.Visible = false;
            lbl_buscar.Visible = false;
            txt_filtrar.Visible = false;
            ddlis_tipo.Visible = false;
        }
        private void desocultar()
        {
            check_todos.Visible = true;
            check_tipo.Visible = true;
            check_filtrar.Visible = true;
            lbl_titulo.Visible = true;
            //lbl_buscar.Visible = true;
            //txt_filtrar.Visible = true;
            //ddlis_tipo.Visible = true;
        }
        public void limpiar()
        {
            txt_codigo.Text = "";
            txt_nombre.Text = "";
            txt_password.Text = "";
            ddlis_rol.ClearSelection();
            check_activo.Checked = false;
            check_inactivo.Checked = false;
        }
        //funcion para mostrar mensajes
        private void mostrarMensaje(string mensaje)
        {
            Response.Write("<script languaje='JavaScript'>alert('" + mensaje.ToString() + "');</script>");

        }

        //funcion para traer datos
        private void cargar_user(string[] datos)
        {
            try
            {
                DataSet dsDatos = new DataSet();

                dsDatos = Muser.traer_usuario(datos);

                DataTable dtDatos = new DataTable();
                dtDatos = dsDatos.Tables[0];

                if (dtDatos.Rows.Count != 0 && dtDatos != null)
                {
                    gv_usuarios.DataSource = dtDatos;
                    gv_usuarios.DataBind();
                }
                else
                {
                    mostrarMensaje("No se ha encontrado información,.. Inicie una nueva búsqueda");
                }

            }

            catch (Exception ex)
            {
                mostrarMensaje(ex.Message.ToString());
            }
        }
        //llenar combobox por tipo
        private void cargar_rol(string[] datos)
        {
            try
            {
                DataSet dsDatos = new DataSet();

                dsDatos = Muser.traer_usuario(datos);

                DataTable dtDatos = new DataTable();
                dtDatos = dsDatos.Tables[0];


                if (dtDatos.Rows.Count != 0 && dtDatos != null)
                {
                    ddlis_tipo.DataSource = dtDatos;
                    ddlis_tipo.DataValueField = "cod";
                    ddlis_tipo.DataTextField = "rol";
                    ddlis_tipo.DataBind();
                    ddlis_tipo.Items.Insert(0, "Seleccione");
                }
                else
                {
                    mostrarMensaje("No se ha encontrado información,.. Inicie una nueva búsqueda");
                }

            }
            catch (Exception ex)
            {
                mostrarMensaje(ex.Message.ToString());
            }
        }
        //llenar combobox por rol
        private void cargar_roles(string[] datos)
        {
            try
            {
                DataSet dsDatos = new DataSet();

                dsDatos = Muser.traer_usuario(datos);

                DataTable dtDatos = new DataTable();
                dtDatos = dsDatos.Tables[0];


                if (dtDatos.Rows.Count != 0 && dtDatos != null)
                {
                    ddlis_rol.DataSource = dtDatos;
                    ddlis_rol.DataValueField = "cod_segdat";
                    ddlis_rol.DataTextField = "nom_segdat";
                    ddlis_rol.DataBind();
                    ddlis_rol.Items.Insert(0, "Seleccione");
                }
                else
                {
                    mostrarMensaje("No se ha encontrado información,.. Inicie una nueva búsqueda");
                }

            }
            catch (Exception ex)
            {
                mostrarMensaje(ex.Message.ToString());
            }
        }
        //ver todos los registros
        public void ver_todos()
        {
            string[] dato = {
                                    "*",
                                    "parametro"
                                };
            cargar_user(dato);
        }
        //inicio de pagina
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack){
                this.Form.Attributes.Add("autocomplete", "off");
                string[] dato = {
                                    "rl",
                                    "rl"
                                };
                cargar_roles(dato);
                ver_todos();
                limpiar();
                bloquear();
                ocultar();
                check_todos.Checked = true;
                //control de botones
                btn_guardar.Enabled = false;
                btn_cancelar.Enabled = false;
            }
        }
        //botones
        protected void btn_guardar_Click(object sender, EventArgs e)
        {
            try
            {
                string[] datos = {
                                         txt_codigo.Text,
                                         txt_nombre.Text,
                                         txt_password.Text,
                                         ddlis_rol.SelectedValue,
                                         lbl_opciones.Text,
                                         "Admin"
                                     };
                Muser.modificar_usuario(datos);
                mostrarMensaje("Usuario Modificado Exitosamente");
                ver_todos();
                limpiar();
                bloquear();
                //control de botones
                btn_guardar.Enabled = false;
                btn_cancelar.Enabled = false;

                btn_buscar.Enabled = true;
            }
            catch (Exception ex)
            {
                mostrarMensaje("Error al Modificar");
            }
        }

        protected void btn_buscar_Click(object sender, EventArgs e)
        {
            ver_todos();
            check_todos.Checked = true;

            //control de botones
            btn_cancelar.Enabled = true;
        }

        protected void btn_cancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Usuarios.aspx");
        }

        protected void check_activo_CheckedChanged(object sender, EventArgs e)
        {
            check_activo.Checked = true;
            check_inactivo.Checked = false;
            lbl_opciones.Text = "1";
        }

        protected void check_inactivo_CheckedChanged(object sender, EventArgs e)
        {
            check_activo.Checked = false;
            check_inactivo.Checked = true;
            lbl_opciones.Text = "0";
        }
        //check de la opciones de busqueda
        protected void check_todos_CheckedChanged(object sender, EventArgs e)
        {
            check_todos.Checked = true;
            check_tipo.Checked = false;
            check_filtrar.Checked = false;
            string[] dato = {
                                    "*",
                                    "parametro"
                                };
            cargar_user(dato);

            txt_filtrar.Visible = false;
            lbl_buscar.Visible = false;
            ddlis_tipo.Visible = false;
            txt_filtrar.Text = "";
        }

        protected void check_tipo_CheckedChanged(object sender, EventArgs e)
        {
            check_todos.Checked = false;
            check_tipo.Checked = true;
            check_filtrar.Checked = false;
            string[] dato = {
                                    "t",
                                    "parametro"
                                };
            cargar_rol(dato);

            txt_filtrar.Visible = false;
            lbl_buscar.Visible = false;
            ddlis_tipo.Visible = true;
            txt_filtrar.Text = "";
        }

        protected void check_filtrar_CheckedChanged(object sender, EventArgs e)
        {
            check_todos.Checked = false;
            check_tipo.Checked = false;
            check_filtrar.Checked = true;

            txt_filtrar.Visible = true;
            lbl_buscar.Visible = true;
            ddlis_tipo.Visible = false;
            txt_filtrar.Text = "";
        }
        //ddlis de la busqueda
        protected void ddlis_tipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] dato = {
                                    "r",
                                    ddlis_tipo.SelectedValue
                            };
            cargar_user(dato);
        }
        //txt para filtrar la busqueda
        protected void txt_filtrar_TextChanged(object sender, EventArgs e)
        {
            string[] dato = {
                                    "op",
                                    txt_filtrar.Text
                                };
            cargar_user(dato);
        }
        //cargar los datos del ddlist
        protected void gv_usuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                int fila = gv_usuarios.SelectedIndex;

                txt_codigo.Text = gv_usuarios.Rows[fila].Cells[0].Text;
                txt_nombre.Text = gv_usuarios.Rows[fila].Cells[5].Text;
                txt_password.Text = gv_usuarios.Rows[fila].Cells[6].Text;
                ddlis_rol.SelectedValue = gv_usuarios.Rows[fila].Cells[3].Text;
                if (gv_usuarios.Rows[fila].Cells[4].Text == "1")
                {
                    check_activo.Checked = true;
                    check_inactivo.Checked = false;
                    lbl_opciones.Text = "1";
                }
                else
                {
                    check_activo.Checked = false;
                    check_inactivo.Checked = true;
                    lbl_opciones.Text = "0";
                }
                desbloquear();
                //contol de botones

                btn_guardar.Enabled = true;
                btn_cancelar.Enabled = true;

                btn_buscar.Enabled = false;

                txt_codigo.Enabled = false;
            }
            catch (Exception ex)
            {
                mostrarMensaje(ex.Message.ToString());
            }
        }

        protected void txt_password_TextChanged(object sender, EventArgs e)
        {
            validarpass();
        }

        protected void ddlis_rol_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}