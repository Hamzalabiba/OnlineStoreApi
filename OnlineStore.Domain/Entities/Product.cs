namespace OnlineStore.Domain.Entities
{
    public class Product :BaseEntity
    {
        public string Name { get; set; }
        public decimal price { get; set; }
    }
}
