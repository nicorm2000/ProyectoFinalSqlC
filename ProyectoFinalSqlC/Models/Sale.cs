namespace ProyectoFinalSqlC.Models
{
    public class Sale
    {

        public long Id { get; set; }
        public string Comment { get; set; } = String.Empty;
        public long UserId { get; set; }

    }
}
