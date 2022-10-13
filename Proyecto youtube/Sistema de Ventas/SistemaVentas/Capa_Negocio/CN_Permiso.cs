using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaEntidad;
using CapaDatos;

namespace Capa_Negocio
{
    public class CN_Permiso
    {
        private CD_Permiso objcd_permiso = new CD_Permiso();
        //SE OBTIENE EL ID DEL USUARIO PARA SABER QUE PERMISO TENDRA
        public string tipopermiso(int idusuario)
        {
            return objcd_permiso.Permiso(idusuario);
        }
    }
}
