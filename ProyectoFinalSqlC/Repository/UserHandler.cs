using System.Data.SqlClient;
using ProyectoFinalSqlC.Models;

namespace ProyectoFinalSqlC.Repository
{
    internal static class UserHandler
    {
        public static string connectionString = "Data Source=DESKTOP-PKSDVOQ;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static User GetUser(string username)
        {
            User usuario = new User();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand($"SELECT * FROM Usuario Where NombreUsuario = '{username}'", conn);

                conn.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();

                    usuario.Id = reader.GetInt64(0);
                    usuario.Name = reader.GetString(1);
                    usuario.Lastname = reader.GetString(2);
                    usuario.Username = reader.GetString(3);
                    usuario.Password = reader.GetString(4);
                    usuario.Email = reader.GetString(5);
                }

                return usuario;
            }
        }

        public static User Login(string username, string password)
        {
            User usuario = new User();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand comand = new SqlCommand($"Select * FROM Usuario WHERE NombreUsuario = '{username}' AND Contraseña = '{password}' ", conn);
                
                conn.Open();
                
                SqlDataReader reader = comand.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();

                    usuario.Id = reader.GetInt64(0);
                    usuario.Name = reader.GetString(1);
                    usuario.Lastname = reader.GetString(2);
                    usuario.Username = reader.GetString(3);
                    usuario.Password = reader.GetString(4);
                    usuario.Email = reader.GetString(5);
                    
                    return usuario;
                }
                else
                {
                    return null;
                }
            }
        }

        public static int Register(User usuario)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                
                SqlCommand comand = new SqlCommand($"INSERT INTO Usuario(Nombre, Apellido, NombreUsuario, Contraseña, Mail)" + $" VALUES('{usuario.Name}','{usuario.Lastname}','{usuario.Username}','{usuario.Password}','{usuario.Email}')", connection);

                return comand.ExecuteNonQuery();
            }
        }

        public static int UpdateUser(User usuario)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand($"UPDATE Usuario SET Nombre = '{usuario.Name}', Apellido = '{usuario.Lastname}', NombreUsuario = '{usuario.Username}', Contraseña = '{usuario.Password}', Mail='{usuario.Email}' WHERE Id='{usuario.Id}'", connection);

                return command.ExecuteNonQuery();
            }
        }




    }
}
