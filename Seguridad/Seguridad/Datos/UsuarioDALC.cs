using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace Datos
{
    public class UsuarioDALC
    {
        Conexion conec = new Conexion();

        //registro de datos
        public DataSet ingresar_uasuario(string[] dato)
        {
            SqlConnection cnn = new SqlConnection(conec.conexion());
            cnn.Open();

            SqlCommand cmd = new SqlCommand("exec Insertar_Usuario '" + dato[0] + "','" + dato[1] + "','" + dato[2] + "'", cnn);
            SqlDataAdapter daDatos = new SqlDataAdapter(cmd);

            DataSet dsDatos = new DataSet();
            daDatos.Fill(dsDatos);

            cnn.Close();
            return dsDatos;
        }
        //modificar de datos
        public DataSet modificar_usuario(string[] dato)
        {
            SqlConnection cnn = new SqlConnection(conec.conexion());
            cnn.Open();

            SqlCommand cmd = new SqlCommand("exec Modificar_Usuario '" + dato[0] + "','" + dato[1] + "','" + dato[2] + "','" + dato[3] + "','" + dato[4] + "','" + dato[5] + "'", cnn);
            SqlDataAdapter daDatos = new SqlDataAdapter(cmd);

            DataSet dsDatos = new DataSet();
            daDatos.Fill(dsDatos);

            cnn.Close();
            return dsDatos;
        }
        //para busqueda de datos
        public DataSet traer_usuario(string[] dato)
        {
            SqlConnection cnn = new SqlConnection(conec.conexion());
            cnn.Open();
            SqlCommand cmd = new SqlCommand("exec Buscar_Usuario '" + dato[0] + "','" + dato[1] + "'", cnn);

            SqlDataAdapter daDatos = new SqlDataAdapter(cmd);

            DataSet dsDatos = new DataSet();
            daDatos.Fill(dsDatos);

            cnn.Close();
            return dsDatos;
        }

        //eliminar usuario
        public DataSet eliminar_usuario(string[] dato)
        {
            SqlConnection cnn = new SqlConnection(conec.conexion());
            cnn.Open();

            SqlCommand cmd = new SqlCommand("exec Eliminar_Usuario '" + dato[0] + "','" + dato[1] + "','" + dato[2] + "','" + dato[3] + "','" + dato[4] + "','" + dato[5] + "'", cnn);
            SqlDataAdapter daDatos = new SqlDataAdapter(cmd);

            DataSet dsDatos = new DataSet();
            daDatos.Fill(dsDatos);

            cnn.Close();
            return dsDatos;
        }
        public DataSet conectarUsuario(string[] datos)
        {
            SqlConnection cnn = new SqlConnection(conec.conexion());
            cnn.Open();
            SqlCommand cmd = null;


            cmd = new SqlCommand("select u.cod_usuario,u.rol_usuario,dbo.DESENCRIPTAR(u.nom_usuario)NICK,dbo.DESENCRIPTAR(u.pass_usuario)PASS,u.est_usuario,p.nom_persona from TBL_USUARIO u, TBL_PERSONA p where dbo.DESENCRIPTAR(u.nom_usuario)='" + datos[0] + "' and dbo.DESENCRIPTAR(u.pass_usuario)='" + datos[1] + "' AND u.est_usuario='1' AND p.id_persona=u.cod_usuario", cnn);

            SqlDataAdapter sqlDA = new SqlDataAdapter(cmd);
            DataSet dsDatos = new DataSet();
            sqlDA.Fill(dsDatos);
            cnn.Close();
            return dsDatos;
        }
    }
}
