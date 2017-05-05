using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Datos;

namespace Negocio
{
    public class ManejadorPersona
    {
        PersonaDALC Dpersona = new PersonaDALC();
        //ingresar datos
        public DataSet ingresar_persona(string[] dato)
        {
            return Dpersona.ingresar_persona(dato);
        }
        //modificar datos
        public DataSet modificar_persona(string[] dato)
        {
            return Dpersona.modificar_persona(dato);
        }
        //eliminar datos
        public DataSet eliminar_persona(string[] dato)
        {
            return Dpersona.eliminar_persona(dato);
        }
        //buscar datos
        public DataSet traer_persona(string[] dato)
        {
            return Dpersona.traer_persona(dato);
        }
    }
}
