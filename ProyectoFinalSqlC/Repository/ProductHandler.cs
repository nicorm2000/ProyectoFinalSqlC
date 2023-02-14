using System.Data.SqlClient;
using ProyectoFinalSqlC.Models;

namespace ProyectoFinalSqlC.Repository
{
    public class ProductHandler : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
