namespace ProyectoFinalSqlC.Models
{
    public class Product
    {

        public long Id { get; set; }
        public string Description { get; set; }
        public decimal Cost { get; set; }
        public decimal SalePrice { get; set; }
        public int Stock { get; set; }
        public long UserId { get; set; }

    }
}
