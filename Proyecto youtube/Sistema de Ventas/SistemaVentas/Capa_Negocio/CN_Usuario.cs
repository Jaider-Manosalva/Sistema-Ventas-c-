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
    }
}
