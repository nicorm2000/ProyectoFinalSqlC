using System.Data;
using System.Data.SqlClient;

namespace ProyectoFinalSqlC.Data
{
    public class DbController
    {

        protected SqlConnection conn = new SqlConnection();
        protected SqlCommand command = new SqlCommand();
        protected string query;
        private protected string connectionstring = "Data Source=DESKTOP-PKSDVOQ;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public DbController()
        {
            conn.ConnectionString = connectionstring;
            command.Connection = conn;
            command.CommandType = CommandType.Text;
        }

    }
}