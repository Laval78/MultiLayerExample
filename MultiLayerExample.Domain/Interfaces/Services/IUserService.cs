using MultiLayerExample.Domain.Dtos;

namespace MultiLayerExample.Domain.Interfaces.Services
{
    public interface IUserService
    {
        Task<UserDto> GetUserFullNameAsync(int id);

        Task<UserWithOrdersDto> GetUserWithOrdersAsync(int id);
    }
}
