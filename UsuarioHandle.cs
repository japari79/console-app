using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace console_app
{
    internal class UsuarioHandle
    {
        public static Usuario getUsuario(string connectionString, long id)
        {
            Usuario usuario = new Usuario();

            string qry = "SELECT * FROM dbo.Usuario WHERE id = @id";

            using (SqlConnection conex = new SqlConnection(connectionString))
            {
                SqlCommand comando = new SqlCommand(qry, conex);
                comando.Parameters.AddWithValue("@id", id);

                conex.Open();

                using (SqlDataReader reader = comando.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        usuario.Id = reader.GetInt64(0);
                        usuario.Nombre = reader.GetString(1);
                        usuario.Apellido = reader.GetString(2);
                        usuario.Mail = reader.GetString(5);
                    }
                }

                return usuario;
            }
        }

        public static Usuario Login(string connectionString, long id, string contrasena)
        {
            Usuario usuario = new Usuario();

            string qry = "SELECT * FROM dbo.Usuario WHERE id = @id AND contraseña = @contrasena";

            using (SqlConnection conex = new SqlConnection(connectionString))
            {
                SqlCommand comando = new SqlCommand(qry, conex);
                comando.Parameters.AddWithValue("@id", id);
                comando.Parameters.AddWithValue("@contrasena", contrasena);

                conex.Open();

                using (SqlDataReader reader = comando.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        usuario.Id = reader.GetInt64(0);
                        usuario.Nombre = reader.GetString(1);
                        usuario.Apellido = reader.GetString(2);
                        usuario.NombreUsuario = reader.GetString(3);
                        usuario.Contrasena = reader.GetString(4);
                        usuario.Mail = reader.GetString(5);
                    }
                }

                return usuario;
            }
        }
    }
}
