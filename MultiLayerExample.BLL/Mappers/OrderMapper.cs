using MultiLayerExample.Domain.Dtos;
using MultiLayerExample.Domain.Entities;

namespace MultiLayerExample.BLL.Mappers
{
    public static class OrderMapper
    {
        public static OrderDto ToOrderDto(this Order order)
        {
            return new OrderDto 
            { 
                Id = order.Id,
                TotalAmount = order.TotalAmount,
                Products = order.Products.Select(p => p.ToProductDto()).ToList() ?? new List<ProductDto>()
            };
        }
    }
}
