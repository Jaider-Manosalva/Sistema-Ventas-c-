using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Negocio
    {
        public Negocio ObtenerDatos()
        {
			Negocio obj = new Negocio();
			try
			{
				using(SqlConnection conexion = new SqlConnection(Conexion.cadena))
				{
					conexion.Open();

					string query = "select IdNegocio,Nombre,Ruc,Direccion from Negocio where IdNegocio = 1";
					SqlCommand cmd = new SqlCommand(query, conexion);
					cmd.CommandType  = CommandType.Text;

					using(SqlDataReader dr = cmd.ExecuteReader())
					{
						while (dr.Read())
						{
							obj = new Negocio()
							{
								IdNegocio = int.Parse(dr["IdNegocio"].ToString()),
								Nombre = dr["Nombre"].ToString(),
								Ruc = dr["Ruc"].ToString(),
								Direccion = dr["Direccion"].ToString()
							};
						}
					}
				}
			}
			catch
			{
				obj = new Negocio();
			}
			return obj;
        }

		public bool GuardarDatos(Negocio obj, out string mensaje)
		{
			mensaje = string.Empty;
			bool Respuesta = true;
            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
                {
                    conexion.Open();

                    StringBuilder query = new StringBuilder();
                    query.AppendLine("update NEGOCIO set Nombre = @Nombre,");
                    query.AppendLine("Ruc = @Ruc,");
                    query.AppendLine("Direccion = @Direccion ");
                    query.AppendLine("where IdNegocio = 1");
                    query.AppendLine();

                    SqlCommand cmd = new SqlCommand(query.ToString(), conexion);
                    cmd.Parameters.AddWithValue("@Nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("@Ruc", obj.Ruc);
                    cmd.Parameters.AddWithValue("@Direccion", obj.Direccion);
                    cmd.CommandType = CommandType.Text;

					if (cmd.ExecuteNonQuery() < 1)
					{
						mensaje = "No se puedo Guardar los datos";
						Respuesta = false;
					}
                }
            }
            catch(Exception ex) 
            {
				Respuesta = false;
			    mensaje = ex.Message;
            }

			return Respuesta;
        }

		public byte [] ObtenerLogo(out bool obtenido)
		{
			obtenido = true;
			byte[] LogoByte = new byte[0];

            try
            {
				using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
				{
					conexion.Open();
					string query = "select Logo from NEGOCIO where IdNegocio = 1";
					SqlCommand cmd = new SqlCommand(query, conexion);
                    cmd.CommandType = CommandType.Text;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
							LogoByte = (byte[])dr["Logo"];
                        }
                    }
                }
            }
            catch
            {
                obtenido = false;
                LogoByte = new byte[0];
            }
			
			return LogoByte;
        }

		public bool ActualizarLogo(byte[] image,out string mensaje)
		{
            mensaje = string.Empty;
            bool Respuesta = true;
            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
                {
                    conexion.Open();

                    StringBuilder query = new StringBuilder();
                    query.AppendLine("update NEGOCIO set Logo = @Imagen");
                    query.AppendLine("where IdNegocio = 1");

                    SqlCommand cmd = new SqlCommand(query.ToString(), conexion);
                    cmd.Parameters.AddWithValue("@Imagen", image);
                    cmd.CommandType = CommandType.Text;

                    if (cmd.ExecuteNonQuery() < 1)
                    {
                        mensaje = "No se puedo altualizar el logo";
                        Respuesta = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Respuesta = false;
                mensaje = ex.Message;
            }

            return Respuesta;
        }
    }
}
