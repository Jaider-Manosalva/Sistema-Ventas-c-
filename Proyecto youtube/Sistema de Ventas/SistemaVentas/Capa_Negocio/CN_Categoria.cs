using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocio
{
    public class CN_Categoria
    {
        private CD_Categoria objcd_Categoria = new CD_Categoria();
        //SE OBTIENE LA LISTA DE USUARIOS DESDE LA CAPA DE DATOS
        public List<Categoria> Lista()
        {
            return objcd_Categoria.Listar();
        }
        public int Registar(Categoria obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (obj.Descripcion == "")
            {
                Mensaje += "Es necesario el nombre de la Categoria\n";
            }
            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return objcd_Categoria.Registar(obj, out Mensaje);
            }
        }
        public bool Editar(Categoria obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (obj.Descripcion == "")
            {
                Mensaje += "Es necesario el nombre de la Categoria\n";
            }
            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objcd_Categoria.Editar(obj, out Mensaje);
            }
        }
        public bool Eliminar(Categoria obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (obj.Descripcion == "")
            {
                Mensaje += "Es necesario el nombre de la Categoria\n";
            }
            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objcd_Categoria.Eliminar(obj, out Mensaje);
            }
        }
    }
}
