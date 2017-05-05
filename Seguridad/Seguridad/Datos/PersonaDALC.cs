using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Datos
{
    public class PersonaDALC
    {
        Conexion conec = new Conexion();

        //registro de datos
        public DataSet ingresar_persona(string[] dato)
        {
            SqlConnection cnn = new SqlConnection(conec.conexion());
            cnn.Open();

            SqlCommand cmd = new SqlCommand("exec Insertar_Persona '" + dato[0] + "','" + dato[1] + "','" + dato[2] + "','" + dato[3] + "','" + dato[4] + "','" + dato[5] + "','" + dato[6] + "','" + dato[7] + "','" + dato[8] + "','" + dato[9] + "','" + dato[10] + "','" + dato[11] + "'", cnn);
            SqlDataAdapter daDatos = new SqlDataAdapter(cmd);

            DataSet dsDatos = new DataSet();
            daDatos.Fill(dsDatos);

            cnn.Close();
            return dsDatos;
        }
        //modificar de datos
        public DataSet modificar_persona(string[] dato)
        {
            SqlConnection cnn = new SqlConnection(conec.conexion());
            cnn.Open();

            SqlCommand cmd = new SqlCommand("exec Modificar_Persona '" + dato[0] + "','" + dato[1] + "','" + dato[2] + "','" + dato[3] + "','" + dato[4] + "','" + dato[5] + "','" + dato[6] + "','" + dato[7] + "','" + dato[8] + "','" + dato[9] + "','" + dato[10] + "','" + dato[11] + "'", cnn);
            SqlDataAdapter daDatos = new SqlDataAdapter(cmd);

            DataSet dsDatos = new DataSet();
            daDatos.Fill(dsDatos);

            cnn.Close();
            return dsDatos;
        }
        //eliminar datos
        public DataSet eliminar_persona(string[] dato)
        {
            SqlConnection cnn = new SqlConnection(conec.conexion());
            cnn.Open();

            SqlCommand cmd = new SqlCommand("exec Eliminar_Persona '" + dato[0] + "'", cnn);
            SqlDataAdapter daDatos = new SqlDataAdapter(cmd);

            DataSet dsDatos = new DataSet();
            daDatos.Fill(dsDatos);

            cnn.Close();
            return dsDatos;
        }
        //para busqueda de datos
        public DataSet traer_persona(string[] dato)
        {
            SqlConnection cnn = new SqlConnection(conec.conexion());
            cnn.Open();
            SqlCommand cmd = new SqlCommand("exec Buscar_Persona '" + dato[0] + "','" + dato[1] + "'", cnn);

            SqlDataAdapter daDatos = new SqlDataAdapter(cmd);

            DataSet dsDatos = new DataSet();
            daDatos.Fill(dsDatos);

            cnn.Close();
            return dsDatos;
        }
    }
}
