namespace ProyectoFinalSqlC.Models
{
    public class ProductoSale
    {
        private long id;
        private int stock;
        private long productId;
        private long saleId;

        public long Id { get => id; set => id = value; }
        public int Stock { get => stock; set => stock = value; }
        public long ProductId { get => productId; set => productId = value; }
        public long SaleId { get => saleId; set => saleId = value; }
    }
}
