using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ProyectoFinalSqlC.Models;
using ProyectoFinalSqlC.Repository;

namespace ProyectoFinalSqlC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ProductController
    {
        [HttpPost]
        public void CreateProduct(Product producto)
        {
            ProductHandler.InsertProduct(producto);
        }

        [HttpPut]
        public void UpdateProduct(Product producto)
        {
            ProductHandler.UpdateProduct(producto);
        }

        [HttpDelete("{id}")]
        public void DeleteProduct(long id)
        {
            ProductHandler.DeleteProduct(id);
        }

        [HttpGet("{id}")]
        public Product GetProduct(long id)
        {
            return ProductHandler.GetProduct(id);
        }
    }
}
