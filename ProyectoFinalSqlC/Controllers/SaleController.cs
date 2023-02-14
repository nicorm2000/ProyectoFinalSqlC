using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ProyectoFinalSqlC.Models;
using ProyectoFinalSqlC.Repository;
using System;

namespace ProyectoFinalSqlC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class SaleController
    {
        [HttpPost]
        public void CrearVenta(List<Product> productos, long idUser)
        {
            SaleHandler.InsertSale(productos, idUser);
        }

        [HttpGet("{idUsuario}")]
        public List<Sale> TraerVentas(long idUsuario)
        {
            return SaleHandler.GetSales(idUsuario);
        }
    }
}
