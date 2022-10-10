using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaEntidad;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_Permiso
    {
        public string Permiso(int idusuario)
        {
            string tipomenu = "";

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {

                    StringBuilder query = new StringBuilder();

                    query.AppendLine("select IdRol from USUARIO");
                    query.AppendLine("where IdUsuario = @idusuario");

                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.Parameters.AddWithValue("@idusuario", idusuario);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Permiso permiso = new Permiso();

                            permiso.NombreMenu = dr["IdRol"].ToString();
                            tipomenu = permiso.NombreMenu;
                        }
                    }
                }
                catch (Exception ex)
                {
                    tipomenu = null;
                }
            }
            return tipomenu;
        }
    }
}
