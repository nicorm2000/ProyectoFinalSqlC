using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ProyectoFinalSqlC.Models;
using ProyectoFinalSqlC.Repository;

namespace ProyectoFinalSqlC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ProductSaleController
    {
        [HttpGet("{idUsuario}")]
        public List<Product> GetSaleProducts(long idUsuario)
        {
            return ProductSaleHandler.GetSaleProducts(idUsuario);
        }
    }
}
