using MultiLayerExample.Domain.Entities;

namespace MultiLayerExample.Domain.Interfaces.Repository
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync();

        Task<Product> GetByIdAsync(int id);

        Task AddAsync(Product product);

        Task UpdateAsync(int id, Product product);

        Task RemoveAsync(int id);
    }
}
