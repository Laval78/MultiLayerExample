using Microsoft.EntityFrameworkCore;
using MultiLayerExample.DAL.Data;
using MultiLayerExample.Domain.Entities;
using MultiLayerExample.Domain.Interfaces.Repository;

namespace MultiLayerExample.DAL.Repositories
{
    internal class UserRepository : IUserRepository
    {
        private readonly ExampleDbContext _context;

        public UserRepository(ExampleDbContext context) 
        {
            _context = context;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User?> GetByIdWithOrdersAsync(int id)
        {
            return await _context.Users
                .Where(u => u.Id == id)
                .Include(u => u.Orders)
                    .ThenInclude(o => o.Products)
                .AsSplitQuery()
                .FirstOrDefaultAsync();
        }
    }
}
