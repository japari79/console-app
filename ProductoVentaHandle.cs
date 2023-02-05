using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace console_app
{
    internal class ProductoVentaHandle
    {
        public static List<ProductoVenta> getProductosVendidosXUsuario(string connectionString, long idUsuario)
        {
            List<ProductoVenta> productoVenta = new List<ProductoVenta>();

            string qry = "SELECT PV.Id, PV.Stock, PV.IdProducto, PV.IdVenta " +
                         "FROM dbo.ProductoVendido PV " +
                         "INNER JOIN dbo.Venta V ON PV.IdVenta = V.Id " +
                         "WHERE V.IdUsuario = @idUsuario";

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
                            productoVenta.Add(new ProductoVenta(Convert.ToInt64(reader["Id"]), Convert.ToInt64(reader["IdProducto"]), Convert.ToInt32(reader["Stock"]), Convert.ToInt64(reader["IdVenta"])));
                        }
                    }
                }

                return productoVenta;
            }
        }
    }
}
