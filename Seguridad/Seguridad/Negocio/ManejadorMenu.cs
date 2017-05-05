using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using Datos;

namespace Negocio
{
    public class ManejadorMenu
    {
        MenuDALC Dmenu = new MenuDALC();
        //ingresar datos
        public DataSet ingresar_menu(string[] dato)
        {
            return Dmenu.ingresar_menu(dato);
        }
        //modificar datos
        public DataSet modificar_menu(string[] dato)
        {
            return Dmenu.modificar_menu(dato);
        }
        //eliminar datos
        public DataSet eliminar_menu(string[] dato)
        {
            return Dmenu.eliminar_menu(dato);
        }
        //buscar datos
        public DataSet traer_menu(string[] dato)
        {
            return Dmenu.traer_menu(dato);
        }
    }
}
