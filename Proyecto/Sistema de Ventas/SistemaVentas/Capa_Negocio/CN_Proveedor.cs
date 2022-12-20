using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocio
{
    public class CN_Proveedor
    {
        private CD_Proveedores objcd_proveedor = new CD_Proveedores();
        //SE OBTIENE LA LISTA DE USUARIOS DESDE LA CAPA DE DATOS
        public List<Proveedor> Lista()
        {
            return objcd_proveedor.Listar();
        }
        public int Registar(Proveedor obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (obj.RazonSocial == "")
            {
                Mensaje += "Es necesario el nombre del Proveedor\n";
            }
            else if (obj.Documento == "")
            {
                Mensaje += "Es necesario el Documento del Proveedor\n";
            }
            else if (obj.Telefono == "")
            {
                Mensaje += "Es necesario una clave del Proveedor\n";
            }

            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return objcd_proveedor.Registar(obj, out Mensaje);
            }
        }
        public bool Editar(Proveedor obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (obj.RazonSocial == "")
            {
                Mensaje += "Es necesario el nombre del Proveedor\n";
            }
            else if (obj.Documento == "")
            {
                Mensaje += "Es necesario el Documento del Proveedor\n";
            }
            else if (obj.Telefono == "")
            {
                Mensaje += "Es necesario una clave del Proveedor\n";
            }

            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objcd_proveedor.Editar(obj, out Mensaje);
            }
        }
        public bool Eliminar(Proveedor obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (obj.RazonSocial == "")
            {
                Mensaje += "Es necesario el nombre del Proveedor\n";
            }
            else if (obj.Documento == "")
            {
                Mensaje += "Es necesario el Documento del Proveedor\n";
            }
            else if (obj.Telefono == "")
            {
                Mensaje += "Es necesario una clave del Proveedor\n";
            }

            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objcd_proveedor.Eliminar(obj, out Mensaje);
            }
        }
    }
}
