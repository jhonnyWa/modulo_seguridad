using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using Datos;

namespace Negocio
{
    public class ManejadorPermisos
    {
        PermisosDALC Dpermi = new PermisosDALC();
        //insertar datos
        public DataSet ingresar_permiso(string[] dato)
        {
            return Dpermi.ingresar_permiso(dato);
        }
        //buscar datos
        public DataSet traer_permisos(string[] dato)
        {
            return Dpermi.traer_permisos(dato);
        }
        //modificar datos
        public DataSet modificar_permisos(string[] dato)
        {
            return Dpermi.modificar_permisos(dato);
        }
        //traer menu

        public DataSet traerMenu(string[] datos)
        {
            return Dpermi.traerMenu(datos);
        }
    }
}
