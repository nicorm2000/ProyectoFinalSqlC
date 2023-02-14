using Microsoft.AspNetCore.Mvc;

namespace ProyectoFinalSqlC.Repository
{
    public class ProductSaleHandler : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
