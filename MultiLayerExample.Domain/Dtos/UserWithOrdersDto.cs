namespace MultiLayerExample.Domain.Dtos
{
    public class UserWithOrdersDto
    {
        public string FullName { get; set; } = string.Empty;

        public List<OrderDto>? Orders { get; set; }
    }
}
