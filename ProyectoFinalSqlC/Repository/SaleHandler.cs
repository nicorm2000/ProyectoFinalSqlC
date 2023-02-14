using System.Data.SqlClient;
using ProyectoFinalSqlC.Models;

namespace ProyectoFinalSqlC.Repository
{
    internal static class SaleHandler
    {
        public static string connectionString = "Data Source=DESKTOP-PKSDVOQ;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static List<Sale> GetSales(long idUsuario)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                List<Sale> ventas = new List<Sale>();
                
                SqlCommand comand = new SqlCommand($"SELECT * FROM Venta WHERE Venta.IdUsuario = {idUsuario}", conn);
                
                conn.Open();

                
                SqlDataReader reader = comand.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Sale ventaTemporal = new Sale();

                        ventaTemporal.Id = reader.GetInt64(0);
                        ventaTemporal.Comment = reader.GetString(1);
                        ventaTemporal.UserId = reader.GetInt64(2);

                        ventas.Add(ventaTemporal);
                    }
                }

                return ventas;
            }
        }

        public static void InsertSale(List<Product> productos, long IdUsuario)
        {
            Sale venta = new Sale();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand($"INSERT INTO Venta(Comentarios, IdUsuario) VALUES ('venta por usuario {IdUsuario}', {IdUsuario})", conn);

                command.ExecuteNonQuery();
                
                venta.Id = GetId.Get(command);
                
                venta.UserId = IdUsuario;

                foreach (Product producto in productos)
                {
                    SqlCommand command2 = new SqlCommand($"INSERT INTO ProductoVendido(Stock, IdProducto, IdVenta) VALUES({producto.Stock},{producto.Id},{venta.Id})", conn);
                    
                    command2.ExecuteNonQuery();
                    
                    command2.Parameters.Clear();

                    SqlCommand command3 = new SqlCommand($" UPDATE Producto SET Stock = (Stock - {producto.Stock}) WHERE Id = {producto.Id}", conn);

                    command3.ExecuteNonQuery();
                    
                    command3.Parameters.Clear();
                }
            }
        }
    }
}
