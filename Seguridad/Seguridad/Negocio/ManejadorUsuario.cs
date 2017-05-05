using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Datos;

namespace Negocio
{
    public class ManejadorUsuario
    {
        UsuarioDALC Dusuario = new UsuarioDALC();
        //ingresar datos
        public DataSet ingresar_usuario(string[] dato)
        {
            return Dusuario.ingresar_uasuario(dato);
        }
        //modificar datos
        public DataSet modificar_usuario(string[] dato)
        {
            return Dusuario.modificar_usuario(dato);
        }
        //eliminar_usuario
        public DataSet eliminar_usuario(string[] dato)
        {
            return Dusuario.eliminar_usuario(dato);
        }
        //buscar datos
        public DataSet traer_usuario(string[] dato)
        {
            return Dusuario.traer_usuario(dato);
        }

        //conectar con el usuario para el login
        public DataSet conectarUsuario(string[] datos)
        {
            return Dusuario.conectarUsuario(datos);
        }
    }
}
