using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Datos
{
    public class PermisosDALC
    {
        Conexion conec = new Conexion();

        //insertar datos
        public DataSet ingresar_permiso(string[] dato)
        {
            SqlConnection cnn = new SqlConnection(conec.conexion());
            cnn.Open();

            SqlCommand cmd = new SqlCommand("exec Insertar_Permisos '" + dato[0] + "','" + dato[1] + "','" + dato[2] + "'", cnn);
            SqlDataAdapter daDatos = new SqlDataAdapter(cmd);

            DataSet dsDatos = new DataSet();
            daDatos.Fill(dsDatos);

            cnn.Close();
            return dsDatos;
        }
        //para busqueda de datos
        public DataSet traer_permisos(string[] dato)
        {
            SqlConnection cnn = new SqlConnection(conec.conexion());
            cnn.Open();
            SqlCommand cmd = new SqlCommand("exec Buscar_Permisos '" + dato[0] + "','" + dato[1] + "'", cnn);

            SqlDataAdapter daDatos = new SqlDataAdapter(cmd);

            DataSet dsDatos = new DataSet();
            daDatos.Fill(dsDatos);

            cnn.Close();
            return dsDatos;
        }
        //modificar de permiso
        public DataSet modificar_permisos(string[] dato)
        {
            SqlConnection cnn = new SqlConnection(conec.conexion());
            cnn.Open();

            SqlCommand cmd = new SqlCommand("exec Modificar_Permisos '" + dato[0] + "','" + dato[1] + "'", cnn);
            SqlDataAdapter daDatos = new SqlDataAdapter(cmd);

            DataSet dsDatos = new DataSet();
            daDatos.Fill(dsDatos);

            cnn.Close();
            return dsDatos;
        }

        //para traer el menu
        public DataSet traerMenu(string[] dato)
        {
            SqlConnection cnn = new SqlConnection(conec.conexion());
            cnn.Open();
            SqlCommand cmd = null;


            cmd = new SqlCommand("select id_menu,nom_men,gru_men,link_men from Vi_Permisos  where cod_rol='" + dato[0] + "' and est_rol='1'", cnn);

            SqlDataAdapter sqlDA = new SqlDataAdapter(cmd);
            DataSet dsDatos = new DataSet();
            sqlDA.Fill(dsDatos);
            cnn.Close();
            return dsDatos;
        }
    }
}
