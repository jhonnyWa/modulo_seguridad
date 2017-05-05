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
    public partial class Permisos : System.Web.UI.Page
    {
        ManejadorPermisos Mpermi = new ManejadorPermisos();

        //funcion para mostrar mensajes
        private void mostrarMensaje(string mensaje)
        {
            Response.Write("<script languaje='JavaScript'>alert('" + mensaje.ToString() + "');</script>");

        }

        //bloquear y desbloquear cajas de texto
        private void bloquear()
        {
            ddlis_menu.Enabled = false;
            ddlis_perfil.Enabled = false;
            check_estado.Enabled = false;
        }
        private void desbloquear()
        {
            ddlis_menu.Enabled = true;
            ddlis_perfil.Enabled = true;
            check_estado.Enabled = true;
        }
        //ocultar y desocultar opciones busqueda
        private void ocultar()
        {
            check_todos.Visible = false;
            check_xper.Visible = false;
            //check_filtrar.Visible = false;
            lbl_titulo.Visible = false;
            //lbl_buscar.Visible = false;
            //txt_filtrar.Visible = false;
            ddlis_xper.Visible = false;
        }
        private void desocultar()
        {
            check_todos.Visible = true;
            check_xper.Visible = true;
            //check_filtrar.Visible = false;
            lbl_titulo.Visible = true;
            //lbl_buscar.Visible = true;
            //txt_filtrar.Visible = true;
            //ddlis_xper.Visible = true;
        }
        public void limpiar()
        {
            ddlis_menu.ClearSelection();
            ddlis_perfil.ClearSelection();
            check_estado.Checked = false;
            lbl_estado.Text = "0";
        }
        //funcion para traer datos
        private void cargar_permisos(string[] datos)
        {
            try
            {
                DataSet dsDatos = new DataSet();

                dsDatos = Mpermi.traer_permisos(datos);

                DataTable dtDatos = new DataTable();
                dtDatos = dsDatos.Tables[0];

                if (dtDatos.Rows.Count != 0 && dtDatos != null)
                {
                    gv_permisos.DataSource = dtDatos;
                    gv_permisos.DataBind();

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
        //recorrer el greadview
        public void recorrer()
        {
            int row = gv_permisos.Rows.Count;
            for (int X = 0; X < row; X++)
            {
                string val = gv_permisos.Rows[X].Cells[3].Text;
                if (val == "1")
                {

                    ((CheckBox)gv_permisos.Rows[X].FindControl("check_permiso")).Checked = true;
                }
                else
                {
                    ((CheckBox)gv_permisos.Rows[X].FindControl("check_permiso")).Checked = false;
                }

            }
        }

        //ocultarcolumnas
        private void ocultacolum()
        {
            this.gv_permisos.Columns[1].Visible = false;
            this.gv_permisos.Columns[2].Visible = false;

        }
        private void desocultacolum()
        {
            this.gv_permisos.Columns[1].Visible = true;
            this.gv_permisos.Columns[2].Visible = true;

        }
        //llenar combobox MENU y ROLES
        private void cargar_menu(string[] datos)
        {
            try
            {
                DataSet dsDatos = new DataSet();

                dsDatos = Mpermi.traer_permisos(datos);

                DataTable dtDatos = new DataTable();
                dtDatos = dsDatos.Tables[0];


                if (dtDatos.Rows.Count != 0 && dtDatos != null)
                {
                    ddlis_menu.DataSource = dtDatos;
                    ddlis_menu.DataValueField = "id_menu";
                    ddlis_menu.DataTextField = "nom_men";
                    ddlis_menu.DataBind();
                    ddlis_menu.Items.Insert(0, "Seleccione");
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
        private void cargar_roles(string[] datos)
        {
            try
            {
                DataSet dsDatos = new DataSet();

                dsDatos = Mpermi.traer_permisos(datos);

                DataTable dtDatos = new DataTable();
                dtDatos = dsDatos.Tables[0];


                if (dtDatos.Rows.Count != 0 && dtDatos != null)
                {
                    ddlis_perfil.DataSource = dtDatos;
                    ddlis_perfil.DataValueField = "cod_segdat";
                    ddlis_perfil.DataTextField = "nom_segdat";
                    ddlis_perfil.DataBind();
                    ddlis_perfil.Items.Insert(0, "Seleccione");

                    ddlis_xper.DataSource = dtDatos;
                    ddlis_xper.DataValueField = "cod_segdat";
                    ddlis_xper.DataTextField = "nom_segdat";
                    ddlis_xper.DataBind();
                    ddlis_xper.Items.Insert(0, "Seleccione");
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
        private void cargar_rolesbus(string[] datos)
        {
            try
            {
                DataSet dsDatos = new DataSet();

                dsDatos = Mpermi.traer_permisos(datos);

                DataTable dtDatos = new DataTable();
                dtDatos = dsDatos.Tables[0];


                if (dtDatos.Rows.Count != 0 && dtDatos != null)
                {
                    ddlis_xper.DataSource = dtDatos;
                    ddlis_xper.DataValueField = "cod_segdat";
                    ddlis_xper.DataTextField = "nom_segdat";
                    ddlis_xper.DataBind();
                    ddlis_xper.Items.Insert(0, "Seleccione");
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
        public void ver_todos()
        {
            string[] dato = {
                                    "*",
                                    "parametro"
                                };
            cargar_permisos(dato);
        }
        //inicio de pagina
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                //cargar ddlis
                string[] dato = {
                                    "men",
                                    "parametro"
                                };
                cargar_menu(dato);
                string[] datos = {
                                    "rol",
                                    "parametro"
                                };
                cargar_roles(datos);
                ver_todos();
                recorrer();

                ocultacolum();

                limpiar();
                bloquear();
                ocultar();
                check_todos.Checked = true;
                //control de botones
                btn_guardar.Enabled = false;
                btn_eliminar.Enabled = false;
                btn_cancelar.Enabled = false;
            }
        }
        //check del estado
        protected void check_estado_CheckedChanged(object sender, EventArgs e)
        {
            if(check_estado.Checked)
            {
                lbl_estado.Text = "1";
            }
            else
            {
                lbl_estado.Text = "0";
            }
        }
        //botones de control
        protected void btn_nuevo_Click(object sender, EventArgs e)
        {
            desbloquear();
            ocultar();
            //control de botones
            btn_nuevo.Enabled = false;
            btn_eliminar.Enabled = false;
            btn_buscar.Enabled = false;

            btn_guardar.Enabled = true;
            btn_cancelar.Enabled = true;
        }

        protected void btn_guardar_Click(object sender, EventArgs e)
        {
            try
            {
                string[] datos = {
                                         ddlis_menu.SelectedValue,
                                         ddlis_perfil.SelectedValue,
                                         lbl_estado.Text
                                     };
                Mpermi.ingresar_permiso(datos);
                lbl_opciones.Text = "";
                mostrarMensaje("Dato Registrado Exitosamente");
                desocultacolum();

                ver_todos();
                limpiar();
                bloquear();
                recorrer();
                ocultacolum();
                //control de botones
                btn_guardar.Enabled = false;
                btn_cancelar.Enabled = false;

                btn_nuevo.Enabled = true;
                btn_buscar.Enabled = true;
            }
            catch (Exception ex)
            {
                mostrarMensaje("Error al Registrar");
            }
        }
        protected void btn_eliminar_Click(object sender, EventArgs e)
        {

        }

        protected void btn_buscar_Click(object sender, EventArgs e)
        {
            desocultar();
            ver_todos();
            recorrer();
            check_todos.Checked = true;

            //control de botones
            btn_cancelar.Enabled = true;
        }

        protected void btn_cancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Permisos.aspx");
        }
        //check dentro del greadview
        protected void check_permiso_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < gv_permisos.Rows.Count; i++)
            {
                CheckBox ch = (CheckBox)gv_permisos.Rows[i].FindControl("check_permiso");
                if (ch.Checked == false)
                {
                    //TextBox2.Text = gv_permisos.Rows[i].Cells[0].Text;
                    string[] datos = {
                                        gv_permisos.Rows[i].Cells[0].Text,
                                        "0"
                                     };
                    Mpermi.modificar_permisos(datos);
                    
                }else
                {
                    string[] datos = {
                                        gv_permisos.Rows[i].Cells[0].Text,
                                        "1"
                                     };
                    Mpermi.modificar_permisos(datos);
                   
                }
            }
            ver_todos();
            desocultacolum();
            recorrer();
            ocultacolum();
        }
        //check y ddlist de la busquedas
        protected void check_xper_CheckedChanged(object sender, EventArgs e)
        {
            check_todos.Checked = false;
            check_xper.Checked = true;
            string[] dato = {
                                    "rol",
                                    "parametro"
                                };
            cargar_rolesbus(dato);
            ddlis_xper.Visible = true;
        }

        protected void check_todos_CheckedChanged(object sender, EventArgs e)
        {
            ddlis_xper.Visible = false;
            check_todos.Checked = true;
            check_xper.Checked = false;
            string[] dato = {
                                    "*",
                                    "parametro"
                                };
            cargar_permisos(dato);
            recorrer();
        }

        protected void ddlis_xper_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] dato = {
                                    "xpe",
                                    ddlis_xper.SelectedValue
                            };
            cargar_permisos(dato);
            recorrer();
        }

    }
}