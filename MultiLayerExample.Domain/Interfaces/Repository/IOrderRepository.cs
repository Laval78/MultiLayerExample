using MultiLayerExample.Domain.Entities;

namespace MultiLayerExample.Domain.Interfaces.Repository
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetAllAsync();

        Task<Order> GetByIdAsync(int id);

        Task AddAsync(Order order);

        Task UpdateAsync(int id, Order order);

        Task DeleteAsync(int id);
    }
}