using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Compra
    {
        public int IdCompra { get; set; }
        public Usuario ObjUsuario { get; set; }
        public Proveedor ObjProveedor { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocuemnto { get; set; }
        public decimal MontoTotal { get; set; }
        public List<Detalle_Compra> ObjDetalleCompra { get; set; }
        public string FechaRegistro { get; set; }
    }
}
