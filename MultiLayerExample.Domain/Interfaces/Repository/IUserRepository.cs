using MultiLayerExample.Domain.Entities;

namespace MultiLayerExample.Domain.Interfaces.Repository
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync();

        Task<User?> GetByIdAsync(int id);

        Task<User?> GetByIdWithOrdersAsync(int id);
    }
}
