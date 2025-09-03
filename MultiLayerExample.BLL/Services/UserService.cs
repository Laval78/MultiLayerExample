using MultiLayerExample.BLL.Mappers;
using MultiLayerExample.Domain.Dtos;
using MultiLayerExample.Domain.Exceptions;
using MultiLayerExample.Domain.Interfaces.Repository;
using MultiLayerExample.Domain.Interfaces.Services;

namespace MultiLayerExample.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDto> GetUserFullNameAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id) ?? throw new NotFoundException("Не знайдено користувача з таким ідентифікаотром.");

            var userDto = user.ToUserDto();

            return userDto;
        }

        public async Task<UserWithOrdersDto> GetUserWithOrdersAsync(int id)
        {
            var userWithOrders = await _userRepository.GetByIdWithOrdersAsync(id) ?? throw new NotFoundException("Не знайдено користувача з таким ідентифікаотром.");

            if (userWithOrders.Orders != null && userWithOrders.Orders.Any())
            {
                foreach (var order in userWithOrders.Orders)
                {
                    if (order.Products == null || !order.Products.Any())
                    {
                        throw new BadRequestException("Виникла проблема при виконані запиту. В замовлені не міститься продуктів.");
                    }
                }
            }

            var userWithOrderDto = userWithOrders.ToUserWithOrdersDto();

            return userWithOrderDto;
        }
    }
}
