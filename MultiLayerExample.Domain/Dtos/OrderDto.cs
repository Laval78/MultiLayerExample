namespace MultiLayerExample.Domain.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }

        public decimal TotalAmount { get; set; }

        public List<ProductDto>? Products { get; set; }
    }
}
