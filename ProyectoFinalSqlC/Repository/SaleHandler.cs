using Microsoft.AspNetCore.Mvc;

namespace ProyectoFinalSqlC.Repository
{
    public class SaleHandler : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
