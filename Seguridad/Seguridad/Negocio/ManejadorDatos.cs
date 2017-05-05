using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using Datos;

namespace Negocio
{
    public class ManejadorDatos
    {
        DatosDALC Ddato = new DatosDALC();
        //ingresar datos
        public DataSet ingresar_dato(string[] dato)
        {
            return Ddato.ingresar_dato(dato);
        }
        //modificar datos
        public DataSet modificar_dato(string[] dato)
        {
            return Ddato.modificar_dato(dato);
        }
        //eliminar datos
        public DataSet eliminar_dato(string[] dato)
        {
            return Ddato.eliminar_dato(dato);
        }
        //buscar datos
        public DataSet traer_datos(string[] dato)
        {
            return Ddato.traer_datos(dato);
        }
    }
}
