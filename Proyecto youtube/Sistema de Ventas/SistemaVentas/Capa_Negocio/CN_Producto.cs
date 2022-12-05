using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocio
{
    public class CN_Producto
    {
        private CD_Productos objcd_Productos = new CD_Productos();
        //SE OBTIENE LA LISTA DE USUARIOS DESDE LA CAPA DE DATOS
        public List<Producto> Lista()
        {
            return objcd_Productos.Listar();
        }
        public int Registar(Producto obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (obj.Nombre == "")
            {
                Mensaje += "Es necesario el Nombre del Producto\n";
            }
            else if (obj.Codigo == "")
            {
                Mensaje += "Es necesario el Codigo del Producto\n";
            }
            else if (obj.Descripcion == "")
            {
                Mensaje += "Es necesario una Descripcion del Producto\n";
            }
            else if (obj.ObjCategoria.Descripcion == "")
            {
                Mensaje += "Es necesario Categoria del Producto\n";
            }
            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return objcd_Productos.Registar(obj, out Mensaje);
            }
        }
        public bool Editar(Producto obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (obj.Nombre == "")
            {
                Mensaje += "Es necesario el nombre del Producto\n";
            }
            else if (obj.Codigo == "")
            {
                Mensaje += "Es necesario el Codigo del Producto\n";
            }
            else if (obj.Descripcion == "")
            {
                Mensaje += "Es necesario una Descripcion del Producto\n";
            }

            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objcd_Productos.Editar(obj, out Mensaje);
            }
        }
        public bool Eliminar(Producto obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (obj.Nombre == "")
            {
                Mensaje += "Es necesario el nombre del Producto\n";
            }
            else if (obj.Codigo == "")
            {
                Mensaje += "Es necesario el Codigo del Producto\n";
            }
            else if (obj.Descripcion == "")
            {
                Mensaje += "Es necesario una Descripcion del Producto\n";
            }

            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objcd_Productos.Eliminar(obj, out Mensaje);
            }
        }
    }
}
