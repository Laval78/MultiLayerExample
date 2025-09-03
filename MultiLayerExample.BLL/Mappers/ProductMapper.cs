using MultiLayerExample.Domain.Dtos;
using MultiLayerExample.Domain.Entities;

namespace MultiLayerExample.BLL.Mappers
{
    public static class ProductMapper
    {
        public static ProductDto ToProductDto(this Product product)
        {
            return new ProductDto
            {
                Id = product.Id,
                Title = product.Title,
                Price = product.Price
            };
        }
    }
}
