using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace Datos
{
    public class Conexion
    {
        private string cadenaconexion;
        public string conexion()
        {
            StreamReader leerArchivo = new StreamReader("C:\\Users\\jhonny\\Documents\\Visual Studio 2013\\Projects\\Seguridad\\Conf_In\\CONEC.txt");
            cadenaconexion = leerArchivo.ReadToEnd();
            return cadenaconexion;
        }


        public object consultas(string sql)
        {
            throw new NotImplementedException();
        }
    }
}