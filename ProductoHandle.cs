using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace console_app
{
    internal static class ProductoHandle
    {
        public static List<Producto> getProductosXUsuario(string connectionString, long idUsuario)
        {
            List<Producto> producto = new List<Producto>();

            string qry = "SELECT * FROM dbo.Producto WHERE IdUsuario = @idUsuario";

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
                            producto.Add(new Producto(Convert.ToInt64(reader["Id"]), Convert.ToString(reader["Descripciones"]), Convert.ToDecimal(reader["Costo"]), Convert.ToDecimal(reader["PrecioVenta"]), Convert.ToInt32(reader["Stock"]), Convert.ToInt64(reader["IdUsuario"])));
                        }
                    }
                }

                return producto;
            }
        }
    }
}
