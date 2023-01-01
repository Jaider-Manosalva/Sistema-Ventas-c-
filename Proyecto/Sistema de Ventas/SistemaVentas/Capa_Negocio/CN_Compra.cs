using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocio
{
    public class CN_Compra
    {

        private CD_Compra objcd_Compra = new CD_Compra();
        public int Correlativo()
        {
            return objcd_Compra.ObtenerCorrelativo();
        }
        public bool Registar(Compra obj,DataTable detalleCompra, out string Mensaje)
        {
            return objcd_Compra.Registrar(obj, detalleCompra, out Mensaje);
        }
    }
}
