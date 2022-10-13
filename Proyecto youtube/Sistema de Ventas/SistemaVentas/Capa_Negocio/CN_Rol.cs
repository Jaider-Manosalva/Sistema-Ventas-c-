using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using CapaEntidad;
using CapaDatos;

namespace Capa_Negocio
{
    public class CN_Rol
    {
         private CD_Rol objcd_Rol = new CD_Rol();
        //SE OBTIENE LA LISTA DE ROLES DESDE LA CAPA DE DATOS
         public List<Rol> Lista()
         {
            return objcd_Rol.Listar();
         }
    }
}
