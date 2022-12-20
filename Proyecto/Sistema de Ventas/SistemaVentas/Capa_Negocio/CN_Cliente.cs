using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocio
{
    public class CN_Cliente
    {
        private CD_Cliente objcd_Cliente = new CD_Cliente();
        //SE OBTIENE LA LISTA DE USUARIOS DESDE LA CAPA DE DATOS
        public List<Cliente> Lista()
        {
            return objcd_Cliente.Listar();
        }
        public int Registar(Cliente obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (obj.NombreCompleto == "")
            {
                Mensaje += "Es necesario el nombre del Cliente\n";
            }
            else if (obj.Documento == "")
            {
                Mensaje += "Es necesario el Documento del Cliente\n";
            }
            else if (obj.Telefono == "")
            {
                Mensaje += "Es necesario una clave del Cliente\n";
            }

            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return objcd_Cliente.Registar(obj, out Mensaje);
            }
        }
        public bool Editar(Cliente obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (obj.NombreCompleto == "")
            {
                Mensaje += "Es necesario el nombre del Cliente\n";
            }
            else if (obj.Documento == "")
            {
                Mensaje += "Es necesario el Documento del Cliente\n";
            }
            else if (obj.Telefono == "")
            {
                Mensaje += "Es necesario una clave del Cliente\n";
            }

            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objcd_Cliente.Editar(obj, out Mensaje);
            }
        }
        public bool Eliminar(Cliente obj, out string Mensaje)
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

            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objcd_Cliente.Eliminar(obj, out Mensaje);
            }
        }
    }
}
