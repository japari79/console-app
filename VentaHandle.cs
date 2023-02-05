using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace console_app
{
    internal class VentaHandle
    {
        public static List<Venta> getVentasXUsuario(string connectionString, long idUsuario)
        {
            List<Venta> ventas = new List<Venta>();

            string qry = "SELECT * FROM dbo.Venta WHERE IdUsuario = @idUsuario";

            using (SqlConnection conex = new SqlConnection(connectionString))
            {
                SqlCommand comando = new SqlCommand(qry, conex);
                comando.Parameters.AddWithValue("@idUsuario", idUsuario);

                conex.Open();

                using (SqlDataReader reader = comando.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ventas.Add(new Venta(Convert.ToInt64(reader["Id"]), reader["Comentarios"].ToString(), Convert.ToInt64(reader["IdUsuario"])));
                        }
                    }
                }

                return ventas;
            }
        }
    }
}
