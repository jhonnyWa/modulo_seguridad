using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Negocio;

namespace Web_Presentacion.Formularios
{
    public partial class Persona : System.Web.UI.Page
    {
        ManejadorPersona Mpersona = new ManejadorPersona();
        ManejadorUsuario Musuario = new ManejadorUsuario();

       

        //bloquear y desbloquear cajas de texto
        private void bloquear()
        {
            txt_nombre.Enabled = false;
            txt_apellido.Enabled = false;
            txt_cedula.Enabled = false;
            txt_direccion.Enabled = false;
            txt_telefono.Enabled = false;
            fileup_imagen.Enabled = false;
            btn_ver.Enabled = false;
            txt_celular.Enabled = false;
            txt_email.Enabled = false;
            ddlis_genero.Enabled = false;
            ddlis_nacionalidad.Enabled = false;
            ddlis_dia.Enabled = false;
            ddlis_mes.Enabled = false;
            ddlis_año.Enabled = false;
        }
        private void desbloquear()
        {
            txt_nombre.Enabled = true;
            txt_apellido.Enabled = true;
            txt_cedula.Enabled = true;
            txt_direccion.Enabled = true;
            txt_telefono.Enabled = true;
            fileup_imagen.Enabled = true;
            btn_ver.Enabled = true;
            txt_celular.Enabled = true;
            txt_email.Enabled = true;
            ddlis_genero.Enabled = true;
            ddlis_nacionalidad.Enabled = true;
            ddlis_dia.Enabled = true;
            ddlis_mes.Enabled = true;
            ddlis_año.Enabled = true;
        }
        //ocultar columna

        //ocultar y desocultar opciones busqueda
        private void ocultar()
        {
            check_todo.Visible = false;
            check_tipo.Visible = false;
            check_filtrar.Visible = false;
            lbl_titulo.Visible = false;
            lbl_buscar.Visible = false;
            txt_filtrar.Visible = false;
            ddlis_tipo.Visible = false;
        }
        private void desocultar()
        {
            check_todo.Visible = true;
            check_tipo.Visible = true;
            check_filtrar.Visible = true;
            lbl_titulo.Visible = true;
            //lbl_buscar.Visible = true;
            //txt_filtrar.Visible = true;
            //ddlis_tipo.Visible = true;
        }
        public void limpiar()
        {
            txt_nombre.Text = "";
            txt_apellido.Text = "";
            txt_cedula.Text = "";
            txt_direccion.Text = "";
            txt_telefono.Text = "";
            imap_foto.ImageUrl = "";
            //btn_ver.Enabled = false;
            txt_celular.Text = "";
            txt_email.Text = "";
            ddlis_genero.ClearSelection();
            ddlis_nacionalidad.ClearSelection();
            ddlis_dia.ClearSelection();
            ddlis_mes.ClearSelection();
            ddlis_año.ClearSelection();
            lbl_nacimiento.Text = "";
            lbl_direccionfoto.Text = "";
        }
        //funcion para mostrar mensajes
        private void mostrarMensaje(string mensaje)
        {
            Response.Write("<script languaje='JavaScript'>alert('" + mensaje.ToString() + "');</script>");

        }
        //OBTENER DIRECCION DE IMAGEN//
        public string direccionimagen()
        {
            string patch = Server.MapPath("Fotos/");
            if (fileup_imagen.HasFile)
            {
                string ext = Path.GetExtension(fileup_imagen.FileName);

                if (ext == ".jpg" || ext == ".png" || ext == ".gif")
                {
                    string name = "~/Fotos/" + fileup_imagen.FileName;
                    return name;

                }
                else { return "~/Fotos/no disponible.jpg"; }
            }
            else { return "~/Fotos/no disponible.jpg"; }
        }
        //funcion para traer datos
        private void cargar_personas(string[] datos)
        {
            try
            {
                DataSet dsDatos = new DataSet();

                dsDatos = Mpersona.traer_persona(datos);

                DataTable dtDatos = new DataTable();
                dtDatos = dsDatos.Tables[0];

                if (dtDatos.Rows.Count != 0 && dtDatos != null)
                {
                    gv_persona.DataSource = dtDatos;
                    gv_persona.DataBind();
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

        //llenar combobox por nacionalidad y sexo,nacionalidadtipo
        private void cargar_nacionalidad(string[] datos)
        {
            try
            {
                DataSet dsDatos = new DataSet();

                dsDatos = Mpersona.traer_persona(datos);

                DataTable dtDatos = new DataTable();
                dtDatos = dsDatos.Tables[0];


                if (dtDatos.Rows.Count != 0 && dtDatos != null)
                {
                    ddlis_nacionalidad.DataSource = dtDatos;
                    ddlis_nacionalidad.DataValueField = "cod_segdat";
                    ddlis_nacionalidad.DataTextField = "nom_segdat";
                    ddlis_nacionalidad.DataBind();
                    ddlis_nacionalidad.Items.Insert(0, "Seleccione");
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
        private void cargar_sexo(string[] datos)
        {
            try
            {
                DataSet dsDatos = new DataSet();

                dsDatos = Mpersona.traer_persona(datos);

                DataTable dtDatos = new DataTable();
                dtDatos = dsDatos.Tables[0];


                if (dtDatos.Rows.Count != 0 && dtDatos != null)
                {
                    ddlis_genero.DataSource = dtDatos;
                    ddlis_genero.DataValueField = "cod_segdat";
                    ddlis_genero.DataTextField = "nom_segdat";
                    ddlis_genero.DataBind();
                    ddlis_genero.Items.Insert(0, "Seleccione");
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
        private void cargar_tipo(string[] datos)
        {
            try
            {
                DataSet dsDatos = new DataSet();

                dsDatos = Mpersona.traer_persona(datos);

                DataTable dtDatos = new DataTable();
                dtDatos = dsDatos.Tables[0];


                if (dtDatos.Rows.Count != 0 && dtDatos != null)
                {
                    ddlis_tipo.DataSource = dtDatos;
                    ddlis_tipo.DataValueField = "cod";
                    ddlis_tipo.DataTextField = "nac";
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
            cargar_personas(dato);
        }
        //inicio de pagina
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                this.Form.Attributes.Add("autocomplete", "off");
                //llenar los ddlis nacionalidad sexo
                string[] dato = {
                                    "ns",
                                    "nc"
                                };
                cargar_nacionalidad(dato);
                string[] datosx = {
                                    "ns",
                                    "sx"
                                };
                cargar_sexo(datosx);
                string[] datos = {
                                    "d",
                                    "parametro"
                                };
                

                ver_todos();
                limpiar();
                bloquear();
                ocultar();
                check_todo.Checked = true;
                //control de botones
                btn_guardar.Enabled = false;
                btn_eliminar.Enabled = false;
                btn_cancelar.Enabled = false;
            }
        }
        //botones
        protected void btn_nuevo_Click(object sender, EventArgs e)
        {
            txt_nombre.Focus();

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
                                         txt_nombre.Text,
                                         txt_apellido.Text,
                                         txt_cedula.Text,
                                         txt_direccion.Text,
                                         txt_telefono.Text,
                                         txt_celular.Text,
                                         txt_email.Text,
                                         ddlis_genero.SelectedValue,
                                         ddlis_nacionalidad.SelectedValue,
                                         lbl_nacimiento.Text,
                                         lbl_direccionfoto.Text,
                                         "Admin"
                                     };
                    Mpersona.ingresar_persona(datos);

                    string[] datos2 = {
                                         txt_nombre.Text.Split(' ').First() + "." + txt_apellido.Text.Split(' ').First(),
                                         txt_cedula.Text,
                                         "Admin"
                                     };
                    Musuario.ingresar_usuario(datos2);
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
                catch (Exception ex)
                {
                    mostrarMensaje("Error al Registrar");
                }
            }
            else
            {
                try
                {
                    string[] datos = {
                                         txt_nombre.Text,
                                         txt_apellido.Text,
                                         txt_cedula.Text,
                                         txt_direccion.Text,
                                         txt_telefono.Text,
                                         txt_celular.Text,
                                         txt_email.Text,
                                         ddlis_genero.SelectedValue,
                                         ddlis_nacionalidad.SelectedValue,
                                         lbl_nacimiento.Text,
                                         lbl_direccionfoto.Text,
                                         "Admin"
                                     };
                    Mpersona.modificar_persona(datos);
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
                                        txt_cedula.Text,
                                 };
                Mpersona.eliminar_persona(datos);
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
            check_todo.Checked = true;

            //control de botones
            btn_cancelar.Enabled = true;
        }

        protected void btn_cancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Persona.aspx");
        }

        protected void btn_ver_Click(object sender, EventArgs e)
        {
            lbl_direccionfoto.Text = direccionimagen();
            imap_foto.ImageUrl = lbl_direccionfoto.Text;
        }
        //check box opciones
        protected void check_todos_CheckedChanged(object sender, EventArgs e)
        {
            check_todo.Checked = true;
            check_tipo.Checked = false;
            check_filtrar.Checked = false;
            string[] dato = {
                                    "*",
                                    "parametro"
                                };
            cargar_personas(dato);

            txt_filtrar.Visible = false;
            lbl_buscar.Visible = false;
            ddlis_tipo.Visible = false;
            txt_filtrar.Text = "";
        }

        protected void check_tipo_CheckedChanged(object sender, EventArgs e)
        {
            check_todo.Checked = false;
            check_tipo.Checked = true;
            check_filtrar.Checked = false;
            string[] dato = {
                                    "n",
                                    "parametro"
                                };
            cargar_tipo(dato);

            txt_filtrar.Visible = false;
            lbl_buscar.Visible = false;
            ddlis_tipo.Visible = true;
            txt_filtrar.Text = "";
        }

        protected void check_filtrar_CheckedChanged(object sender, EventArgs e)
        {
            check_todo.Checked = false;
            check_tipo.Checked = false;
            check_filtrar.Checked = true;

            txt_filtrar.Visible = true;
            lbl_buscar.Visible = true;
            ddlis_tipo.Visible = false;
            txt_filtrar.Text = "";
        }
        //ddlis todos
        protected void ddlis_genero_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       
        protected void ddlis_dia_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbl_nacimiento.Text = ddlis_dia.SelectedValue + "/" + ddlis_mes.SelectedValue + "/" + ddlis_año.SelectedValue;
        }

        protected void ddlis_mes_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbl_nacimiento.Text = ddlis_dia.SelectedValue + "/" + ddlis_mes.SelectedValue + "/" + ddlis_año.SelectedValue;
        }

        protected void ddlis_año_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbl_nacimiento.Text = ddlis_dia.SelectedValue + "/" + ddlis_mes.SelectedValue + "/" + ddlis_año.SelectedValue;
        }

        protected void ddlis_tipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] dato = {
                                    "op",
                                    ddlis_tipo.SelectedValue
                            };
            cargar_personas(dato);
        }
        //filtart txt para busqueda
        protected void txt_filtrar_TextChanged(object sender, EventArgs e)
        {
            string[] dato = {
                                    "op",
                                    txt_filtrar.Text
                                };
            cargar_personas(dato);
        }
        //selecionar los datos del gread
        protected void gv_persona_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                int fila = gv_persona.SelectedIndex;

                lbl_id.Text = gv_persona.Rows[fila].Cells[0].Text;
                txt_nombre.Text = gv_persona.Rows[fila].Cells[1].Text;
                txt_apellido.Text = gv_persona.Rows[fila].Cells[2].Text;
                txt_cedula.Text = gv_persona.Rows[fila].Cells[3].Text;
                txt_direccion.Text = gv_persona.Rows[fila].Cells[4].Text;
                txt_telefono.Text = gv_persona.Rows[fila].Cells[5].Text;
                txt_celular.Text = gv_persona.Rows[fila].Cells[6].Text;
                txt_email.Text = gv_persona.Rows[fila].Cells[7].Text;

                ddlis_genero.SelectedValue = gv_persona.Rows[fila].Cells[8].Text;
                ddlis_nacionalidad.SelectedValue = gv_persona.Rows[fila].Cells[10].Text;

                lbl_nacimiento.Text = gv_persona.Rows[fila].Cells[12].Text;
                lbl_direccionfoto.Text = gv_persona.Rows[fila].Cells[13].Text;
                imap_foto.ImageUrl = lbl_direccionfoto.Text;

                lbl_opciones.Text = "MODIFICAR";
                desbloquear();
                //contol de botones

                btn_guardar.Enabled = true;
                btn_eliminar.Enabled = true;
                btn_cancelar.Enabled = true;

                btn_nuevo.Enabled = false;
                btn_buscar.Enabled = false;

                txt_cedula.Enabled = false;
            }
            catch (Exception ex)
            {
                mostrarMensaje(ex.Message.ToString());
            }
        }

        ////private void lista_persona(string[] datos)
        ////{
        //    try
        //    {
        //        DataSet dsDatos = new DataSet();

        //        dsDatos = Mpersona.traer_persona(datos);

        //        DataTable dtDatos = new DataTable();
        //        dtDatos = dsDatos.Tables[0];

        //        if (dtDatos.Rows.Count != 0 && dtDatos != null)
        //        {
        //            list_persona.DataSource = dtDatos;
        //            list_persona.DataValueField = "cod_segdat";
        //            list_persona.DataTextField = "nom_segdat";
        //            list_persona.DataBind();
        //            list_persona.Items.Insert(0, "Seleccione");
        //        }
        //        else
        //        {
        //            mostrarMensaje("No se ha encontrado información,.. Inicie una nueva búsqueda");
        //        }

        //    }

        //    catch (Exception ex)
        //    {
        //        mostrarMensaje(ex.Message.ToString());
        //    }
        //}
        protected void list_persona_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        
    }
}