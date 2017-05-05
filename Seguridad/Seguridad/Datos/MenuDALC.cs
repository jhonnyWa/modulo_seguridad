using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Datos
{
    public class MenuDALC
    {
        Conexion conec = new Conexion();
        //registro de datos
        public DataSet ingresar_menu(string[] dato)
        {
            SqlConnection cnn = new SqlConnection(conec.conexion());
            cnn.Open();

            SqlCommand cmd = new SqlCommand("exec Insertar_Menu '" + dato[0] + "','" + dato[1] + "','" + dato[2] + "','" + dato[3] + "','" + dato[4] + "'", cnn);
            SqlDataAdapter daDatos = new SqlDataAdapter(cmd);

            DataSet dsDatos = new DataSet();
            daDatos.Fill(dsDatos);

            cnn.Close();
            return dsDatos;
        }
        //modificar de datos
        public DataSet modificar_menu(string[] dato)
        {
            SqlConnection cnn = new SqlConnection(conec.conexion());
            cnn.Open();

            SqlCommand cmd = new SqlCommand("exec Modificar_Menu '" + dato[0] + "','" + dato[1] + "','" + dato[2] + "','" + dato[3] + "','" + dato[4] + "'", cnn);
            SqlDataAdapter daDatos = new SqlDataAdapter(cmd);

            DataSet dsDatos = new DataSet();
            daDatos.Fill(dsDatos);

            cnn.Close();
            return dsDatos;
        }
        //eliminar datos
        public DataSet eliminar_menu(string[] dato)
        {
            SqlConnection cnn = new SqlConnection(conec.conexion());
            cnn.Open();

            SqlCommand cmd = new SqlCommand("exec Eliminar_Menu '" + dato[0] + "'", cnn);
            SqlDataAdapter daDatos = new SqlDataAdapter(cmd);

            DataSet dsDatos = new DataSet();
            daDatos.Fill(dsDatos);

            cnn.Close();
            return dsDatos;
        }
        //para busqueda de datos
        public DataSet traer_menu(string[] dato)
        {
            SqlConnection cnn = new SqlConnection(conec.conexion());
            cnn.Open();
            SqlCommand cmd = new SqlCommand("exec Buscar_Mene '" + dato[0] + "','" + dato[1] + "'", cnn);

            SqlDataAdapter daDatos = new SqlDataAdapter(cmd);

            DataSet dsDatos = new DataSet();
            daDatos.Fill(dsDatos);

            cnn.Close();
            return dsDatos;
        }
    }
}
