using MultiLayerExample.Domain.Dtos;
using MultiLayerExample.Domain.Entities;

namespace MultiLayerExample.BLL.Mappers
{
    public static class UserMapper
    {
        public static UserDto ToUserDto(this User user)
        {
            return new UserDto
            {
                FullName = user.FullName
            };
        }

        public static UserWithOrdersDto ToUserWithOrdersDto(this User user)
        {
            return new UserWithOrdersDto 
            { 
                FullName = user.FullName,
                Orders = user.Orders?.Select(o => o.ToOrderDto()).ToList() ?? new List<OrderDto>()
            };
        }
    }
}
