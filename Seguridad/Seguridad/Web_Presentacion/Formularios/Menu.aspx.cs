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
    public partial class Menu : System.Web.UI.Page
    {
        ManejadorMenu Mmen = new ManejadorMenu();
        //bloquear y desbloquear cajas de texto
        private void bloquear()
        {
            txt_codigo.Enabled = false;
            txt_nombre.Enabled = false;
            txt_link.Enabled = false;
            txt_grupo.Enabled = false;
            txt_funcion.Enabled = false;
        }
        private void desbloquear()
        {
            txt_codigo.Enabled = true;
            txt_nombre.Enabled = true;
            txt_link.Enabled = true;
            txt_grupo.Enabled = true;
            txt_funcion.Enabled = true;
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
        //limiar cajas de texto
        public void limpiar()
        {
            txt_codigo.Text = "";
            txt_nombre.Text = "";
            txt_link.Text = "";
            txt_grupo.Text = "";
            txt_funcion.Text = "";
        }
        //funcion para mostrar mensajes
        private void mostrarMensaje(string mensaje)
        {
            Response.Write("<script languaje='JavaScript'>alert('" + mensaje.ToString() + "');</script>");

        }
        //funcion para traer datos
        private void cargar_menu(string[] datos)
        {
            try
            {
                DataSet dsDatos = new DataSet();

                dsDatos = Mmen.traer_menu(datos);

                DataTable dtDatos = new DataTable();
                dtDatos = dsDatos.Tables[0];

                if (dtDatos.Rows.Count != 0 && dtDatos != null)
                {
                    gv_menu.DataSource = dtDatos;
                    gv_menu.DataBind();
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
        private void cargar_grupo(string[] datos)
        {
            try
            {
                DataSet dsDatos = new DataSet();

                dsDatos = Mmen.traer_menu(datos);

                DataTable dtDatos = new DataTable();
                dtDatos = dsDatos.Tables[0];


                if (dtDatos.Rows.Count != 0 && dtDatos != null)
                {
                    ddlis_tipo.DataSource = dtDatos;
                    ddlis_tipo.DataValueField = "gru_men";
                    ddlis_tipo.DataTextField = "gru_men";
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
        //ver todos los registros
        public void ver_todos()
        {
            string[] dato = {
                                    "*",
                                    "parametro"
                                };
            cargar_menu(dato);
        }
        //pagina de inicio
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                this.Form.Attributes.Add("autocomplete", "off");
                ver_todos();
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
        //botones de control
        protected void btn_nuevo_Click(object sender, EventArgs e)
        {
            txt_codigo.Focus();

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
            if (lbl_opciones.Text != "MODIFICAR")
            {
                try
                {
                    string[] datos = {
                                         txt_codigo.Text,
                                         txt_nombre.Text,
                                         txt_link.Text,
                                         txt_grupo.Text,
                                         txt_funcion.Text
                                     };
                    Mmen.ingresar_menu(datos);
                    lbl_opciones.Text = "";
                    mostrarMensaje("Dato Registrado Exitosamente");
                    ver_todos();
                    limpiar();
                    bloquear();

                    //control de botones
                    btn_guardar.Enabled = false;
                    btn_cancelar.Enabled = false;

                    btn_nuevo.Enabled = true;
                    btn_buscar.Enabled = true;
                }
                catch (Exception )
                {
                    mostrarMensaje("Error al Registrar");
                }
            }
            else
            {
                try
                {
                    string[] datos = {
                                         txt_codigo.Text,
                                         txt_nombre.Text,
                                         txt_link.Text,
                                         txt_grupo.Text,
                                         txt_funcion.Text
                                     };
                    Mmen.modificar_menu(datos);
                    lbl_opciones.Text = "";
                    mostrarMensaje("Dato Modificado Exitosamente");
                    ver_todos();
                    limpiar();
                    bloquear();

                    //control de botones
                    btn_guardar.Enabled = false;
                    btn_cancelar.Enabled = false;

                    btn_nuevo.Enabled = true;
                    btn_buscar.Enabled = true;
                }
                catch (Exception ex)
                {
                    mostrarMensaje("Error al Modificar");
                }
            }
        }

        protected void btn_eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                string[] datos = {
                                         txt_codigo.Text,
                                     };
                Mmen.eliminar_menu(datos);
                mostrarMensaje("Dato Eliminado correctamente");
                ver_todos();
                limpiar();

                //control de botones
                btn_guardar.Enabled = false;
                btn_eliminar.Enabled = false;
                btn_cancelar.Enabled = false;

                btn_nuevo.Enabled = true;
                btn_buscar.Enabled = true;
            }
            catch (Exception ex)
            {
                mostrarMensaje("Error al Eliminar");
            }
        }

        protected void btn_buscar_Click(object sender, EventArgs e)
        {
            desocultar();
            ver_todos();
            check_todos.Checked = true;

            //control de botones
            btn_cancelar.Enabled = true;
        }

        protected void btn_cancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Menu.aspx");
        }
        //rbuton de las opciones de busqueda
        protected void check_todos_CheckedChanged(object sender, EventArgs e)
        {
            check_todos.Checked = true;
            check_tipo.Checked = false;
            check_filtrar.Checked = false;
            string[] dato = {
                                    "*",
                                    "parametro"
                                };
            cargar_menu(dato);

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
            cargar_grupo(dato);

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
        //ddlis de las opciones de busqueda
        protected void ddlis_tipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] dato = {
                                    "gr",
                                    ddlis_tipo.SelectedItem.ToString()
                            };
            cargar_menu(dato);
        }
        //texbox filtrar la busqueda
        protected void txt_filtrar_TextChanged(object sender, EventArgs e)
        {
            string[] dato = {
                                    "op",
                                    txt_filtrar.Text
                                };
            cargar_menu(dato);
        }
        //selecciona datos de gread
        protected void gv_menu_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                int fila = gv_menu.SelectedIndex;

                txt_codigo.Text = gv_menu.Rows[fila].Cells[0].Text;
                txt_nombre.Text = gv_menu.Rows[fila].Cells[1].Text;
                txt_link.Text = gv_menu.Rows[fila].Cells[2].Text;
                txt_grupo.Text = gv_menu.Rows[fila].Cells[3].Text;
                txt_funcion.Text = gv_menu.Rows[fila].Cells[4].Text;

                lbl_opciones.Text = "MODIFICAR";
                desbloquear();
                //contol de botones

                btn_guardar.Enabled = true;
                btn_eliminar.Enabled = true;
                btn_cancelar.Enabled = true;

                btn_nuevo.Enabled = false;
                btn_buscar.Enabled = false;

                txt_codigo.Enabled = false;
            }
            catch (Exception ex)
            {
                mostrarMensaje(ex.Message.ToString());
            }
        }
    }
}