using System.Data.SqlClient;
using ProyectoFinalSqlC.Models;

namespace ProyectoFinalSqlC.Repository
{
    internal class ProductSaleHandler
    {
        public static string connectionString = "Data Source=DESKTOP-PKSDVOQ;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static List<Product> GetSaleProducts(long idUsuario)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                List<long> idProductos = new List<long>();

                SqlCommand comand = new SqlCommand($"SELECT IdProducto FROM Venta INNER JOIN ProductoVendido ON Venta.Id = ProductoVendido.IdVenta WHERE IdUsuario = {idUsuario}", connection);
                
                connection.Open();

                SqlDataReader reader = comand.ExecuteReader();
                
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        idProductos.Add(reader.GetInt64(0));
                    }
                }
                
                List<Product> productos = new List<Product>();

                foreach (var item in idProductos)
                {
                    Product prodTemp = ProductHandler.GetProduct(item);

                    productos.Add(prodTemp);
                }

                return productos;
            }
        }
    }
}
