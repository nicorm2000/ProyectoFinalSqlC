namespace ProyectoFinalSqlC.Models
{
    public class Product
    {
        private long id;
        private string description;
        private decimal cost;
        private decimal salePrice;
        private int stock;
        private long userId;

        public long Id { get => id; set => id = value; }
        public string Description { get => description; set => description = value; }
        public decimal Cost { get => cost; set => cost = value; }
        public decimal SalePrice { get => salePrice; set => salePrice = value; }
        public int Stock { get => stock; set => stock = value; }
        public long UserId { get => userId; set => userId = value; }
    }
}
