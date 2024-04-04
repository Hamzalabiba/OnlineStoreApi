namespace OnlineStore.Domain.Entities
{
    public class Products :BaseEntity
    {
        public string Name { get; set; }
        public decimal price { get; set; }
    }
}
