using System.Data.SqlClient;
using ProyectoFinalSqlC.Models;

namespace ProyectoFinalSqlC.Repository
{
    internal static class ProductHandler
    {
        public static string connectionString = "Data Source=DESKTOP-PKSDVOQ;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static List<Product> GetProducts()
        {
            List<Product> productos = new List<Product>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand comand = new SqlCommand("SELECT * FROM Producto", connection);

                connection.Open();

                SqlDataReader reader = comand.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Product productoTemporal = new Product();

                        productoTemporal.Id = reader.GetInt64(0);
                        productoTemporal.Description = reader.GetString(1);
                        productoTemporal.Costo = reader.GetDecimal(2);
                        productoTemporal.PrecioVenta = reader.GetDecimal(3);
                        productoTemporal.Stock = reader.GetInt32(4);
                        productoTemporal.IdUser = reader.GetInt64(5);

                        productos.Add(productoTemporal);
                    }
                }
                return productos;
            }

        }

        public static Product GetProduct(string description)
        {
            Product producto = new Product();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand comand = new SqlCommand($"SELECT * FROM Producto WHERE Descripciones = '{description}' ", connection);

                connection.Open();

                SqlDataReader reader = comand.ExecuteReader();

                if (reader.HasRows)
                {
                    {
                        reader.Read();
                        producto.Id = reader.GetInt64(0);
                        producto.Description = reader.GetString(1);
                        producto.Costo = reader.GetDecimal(2);
                        producto.PrecioVenta = reader.GetDecimal(3);
                        producto.Stock = reader.GetInt32(4);
                        producto.IdUser = reader.GetInt64(5);
                    }
                }
                return producto;
            }
        }

        public static int InsertProduct(Product producto)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand comand = new SqlCommand($"INSERT INTO Producto(Descripciones, Costo, PrecioVenta, Stock, IdUsuario)" + $" VALUES('{producto.Description}',{producto.Costo},{producto.PrecioVenta},{producto.Stock},{producto.IdUser})", connection);

                return comand.ExecuteNonQuery();
            }
        }

        public static List<Product> GetProductsUploadedByUsers(long IdUser)
        {
            List<Product> productos = new List<Product>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand comand = new SqlCommand($"Select * From Producto Where IdUsuario = {IdUser} ", connection);

                connection.Open();

                SqlDataReader reader = comand.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Product productoTemporal = new Product();

                        productoTemporal.Id = reader.GetInt64(0);
                        productoTemporal.Description = reader.GetString(1);
                        productoTemporal.Costo = reader.GetDecimal(2);
                        productoTemporal.PrecioVenta = reader.GetDecimal(3);
                        productoTemporal.Stock = reader.GetInt32(4);
                        productoTemporal.IdUser = reader.GetInt64(5);

                        productos.Add(productoTemporal);
                    }
                }
                return productos;
            }
        }

        public static Product GetProduct(long id)
        {
            Product producto = new Product();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand comand = new SqlCommand($"SELECT * FROM Producto WHERE id = '{id}' ", connection);

                connection.Open();

                SqlDataReader reader = comand.ExecuteReader();

                if (reader.HasRows)
                {
                    {
                        reader.Read();
                        producto.Id = reader.GetInt64(0);
                        producto.Description = reader.GetString(1);
                        producto.Costo = reader.GetDecimal(2);
                        producto.PrecioVenta = reader.GetDecimal(3);
                        producto.Stock = reader.GetInt32(4);
                        producto.IdUser = reader.GetInt64(5);
                    }
                }
                return producto;
            }

        }


        public static int DeleteProduct(long id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand($"DELETE From ProductoVendido WHERE IdProducto = {id}", connection);
                    SqlCommand command1 = new SqlCommand($"DELETE FROM PRODUCTO WHERE id = {id}", connection);

                    connection.Open();
                    command.ExecuteNonQuery();

                    return command1.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine("" + e.Message);
                    return -1;
                }
            }
        }

        public static int UpdateProduct(Product product)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand($"UPDATE Producto SET Descripciones = '{product.Description}', Costo = {product.Costo}, PrecioVenta = {product.PrecioVenta}, Stock = {product.Stock}, IdUsuario = {product.IdUser}  WHERE Id = {product.Id}", connection);

                return command.ExecuteNonQuery();
            }
        }


    }
}
