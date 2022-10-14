using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;

namespace Capa_Negocio
{
    public class CN_Usuario
    {
        private CD_Usuarios objcd_usuario = new CD_Usuarios();
        //SE OBTIENE LA LISTA DE USUARIOS DESDE LA CAPA DE DATOS
        public List<Usuario> Lista()
        {
            return objcd_usuario.Listar();
        }
        public int Registar(Usuario obj,out string Mensaje)
        {
            Mensaje = string.Empty;
            if (obj.NombreCompleto == "")
            {
                Mensaje += "Es necesario el nombre del Usuario\n";
            }
            else if (obj.Documento == "")
            {
                Mensaje += "Es necesario el Documento del Usuario\n";
            }
            else if (obj.Clave == "")
            {
                Mensaje += "Es necesario una clave del Usuario\n";
            }

            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return objcd_usuario.Registar(obj, out Mensaje);
            }
        }
        public bool Editar(Usuario obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (obj.NombreCompleto == "")
            {
                Mensaje += "Es necesario el nombre del Usuario\n";
            }
            else if (obj.Documento == "")
            {
                Mensaje += "Es necesario el Documento del Usuario\n";
            }
            else if (obj.Clave == "")
            {
                Mensaje += "Es necesario una clave del Usuario\n";
            }

            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objcd_usuario.Editar(obj, out Mensaje);
            }
        }
        public bool Eliminar(Usuario obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (obj.NombreCompleto == "")
            {
                Mensaje += "Es necesario el nombre del Usuario\n";
            }
            else if (obj.Documento == "")
            {
                Mensaje += "Es necesario el Documento del Usuario\n";
            }
            else if (obj.Clave == "")
            {
                Mensaje += "Es necesario una clave del Usuario\n";
            }

            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objcd_usuario.Eliminar(obj, out Mensaje);
            }
        }
    }
}
