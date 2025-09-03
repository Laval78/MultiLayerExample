namespace MultiLayerExample.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }

        public decimal TotalAmount { get; set; }

        public int IdUser { get; set; }

        public User? User { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
