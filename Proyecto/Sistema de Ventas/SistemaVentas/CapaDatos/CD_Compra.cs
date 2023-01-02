using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using System.Collections;
using System.ComponentModel;

namespace CapaDatos
{
    public class CD_Compra
    {
        //FUNCION PARA OBTENER EL CORRELATIVO DE LA ULTIMA COMPRA
        public int ObtenerCorrelativo()
        {
            int correlativo = 0;

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select count(*) + 1 from COMPRA");
                    SqlCommand cmd = new SqlCommand(query.ToString(),oconexion);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();

                    correlativo = Convert.ToInt32(cmd.ExecuteScalar());
                }
                catch (Exception)
                {
                    correlativo= 0;
                }
            }
            return correlativo;
        }
        //FUNCION PARA REGISTRAR UNA COMPRA
        public bool Registrar(Compra obj, DataTable DetalleCompra, out string Mensaje)
        {
            bool Respuesta = false; 
            Mensaje = string.Empty;

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_REGISTRARCOMPRA",oconexion);
                    cmd.Parameters.AddWithValue("IdUsuario", obj.ObjUsuario.IdUsuario);
                    cmd.Parameters.AddWithValue("IdProveedor", obj.ObjProveedor.IdProveedor);
                    cmd.Parameters.AddWithValue("TipoDocumento", obj.TipoDocumento);
                    cmd.Parameters.AddWithValue("NumeroDocumento", obj.NumeroDocuemnto);
                    cmd.Parameters.AddWithValue("MontoTotal",obj.MontoTotal);
                    cmd.Parameters.AddWithValue("DetalleCompra", DetalleCompra);

                    cmd.Parameters.Add("resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    cmd.ExecuteNonQuery();

                    Respuesta = Convert.ToBoolean(cmd.Parameters["resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
                catch (Exception e)
                {
                    Respuesta = false;
                    Mensaje = e.Message;
                }
            }
            return Respuesta;
        }
        //FUNCION PARA OBTENER DATOS DE LA COMPRA
        public Compra ObtenerCompra(string correlativo)
        {
            Compra obj = new Compra();

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select c.IdCompra,u.NombreCompleto,p.Documento,p.RazonSocial,c.TipoDocumento,c.NumeroDocumento,c.MontoTotal,CONVERT(char(10),c.FechaRegistro,103)[fechaRegistro]");
                    query.AppendLine("from COMPRA as c inner join USUARIO as u on u.IdUsuario = c.IdUsuario inner join PROVEEDOR as p on p.IdProveedor = c.IdProveedor");
                    query.AppendLine("where c.NumeroDocumento = @numero");

                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.Parameters.AddWithValue("@numero",correlativo);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            obj = new Compra()
                            {
                                IdCompra = Convert.ToInt32(dr["IdCompra"]),
                                ObjUsuario = new Usuario() { NombreCompleto = dr["NombreCompleto"].ToString() },
                                ObjProveedor = new Proveedor() { Documento = dr["Documento"].ToString(), RazonSocial = dr["RazonSocial"].ToString() },
                                TipoDocumento = dr["TipoDocumento"].ToString(),
                                NumeroDocuemnto = dr["NumeroDocumento"].ToString(),
                                MontoTotal = Convert.ToDecimal(dr["MontoTotal"]),
                                FechaRegistro = dr["FechaRegistro"].ToString()
                            };
                        }
                    }
                }
                catch (Exception ex)
                {
                   obj = new Compra();
                }
            }
             return obj;
        }
        //FUNCION PARA OBTENER EL DETALLE DE COMPRA
        public List<Detalle_Compra> ObtenerDetalle(string correlativo)
        {
            List<Detalle_Compra> lista = new List<Detalle_Compra>();

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select  p.Nombre,dc.PrecioCompra,dc.Cantidad,dc.MontoTotal");
                    query.AppendLine("from DETALLE_COMPRA dc inner join PRODUCTO p on p.IdProducto = dc.IdProducto");
                    query.AppendLine("where dc.IdCompra = @numero");

                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.Parameters.AddWithValue("@numero", correlativo);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Detalle_Compra()
                            {
                                ObjProducto = new Producto() { Nombre = dr["Nombre"].ToString()},
                                PrecioCompra = Convert.ToDecimal(dr["PrecioCompra"]),
                                Cantidad = Convert.ToInt32(dr["Cantidad"]),
                                MontoTotal = Convert.ToDecimal(dr["MotoTotal"])
                                
                            });
                            
                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<Detalle_Compra>();
                }
            }
            return lista;
        }
    }
}
