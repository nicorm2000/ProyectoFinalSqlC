namespace ProyectoFinalSqlC.Models
{
    public class Sale
    {
        private long id;
        private string comment;
        private long userId;

        public long Id { get => id; set => id = value; }
        public string Comment { get => comment; set => comment = value; }
        public long UserId { get => userId; set => userId = value; }
    }
}
