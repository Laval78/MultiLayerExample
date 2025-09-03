using Moq;
using MultiLayerExample.Domain.Entities;
using MultiLayerExample.Domain.Interfaces.Repository;
using MultiLayerExample.BLL.Services;
using MultiLayerExample.Domain.Interfaces.Services;
using MultiLayerExample.Domain.Exceptions;
using MultiLayerExample.Domain.Dtos;
using FluentAssertions;

namespace MultiLayerExample.Tests
{
    public class UserServiceTest
    {
        private readonly Mock<IUserRepository> _userRepositoryMock;

        private readonly IUserService _userService;

        public UserServiceTest()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _userService = new UserService(_userRepositoryMock.Object);
        }

        [Fact]
        public async Task GetUserFullNameById_UserExists_ReturnUserDto()
        {
            //Arrange
            var id = 1;
            _userRepositoryMock.Setup(repo => repo.GetByIdAsync(id))
                .ReturnsAsync(new User { Id = 1, FullName = "John Doe" });

            //Act
            var result = await _userService.GetUserFullNameAsync(id);

            //Assert
            Assert.Equal("John Doe", result.FullName);
        }

        [Fact]
        public async Task GetUserFullNameById_UserNotFound_ThrowNotFoundException()
        {
            //Arrange
            int id = 999999999;
            _userRepositoryMock.Setup(repo => repo.GetByIdAsync(id))
                .ReturnsAsync((User)null);

            //Act & Assert
            await Assert.ThrowsAsync<NotFoundException>(() => 
                _userService.GetUserFullNameAsync(id));
        }

        [Fact]
        public async Task GetUserWithOrders_ObjectNotNull_ShouldReturnUserWithOrders()
        {
            //Arrange
            int id = 1;

            var user = new User
            {
                Id =1,
                FullName = "John Doe",
                Orders = new List<Order> 
                {
                    new Order 
                    { 
                        Id = 1,
                        TotalAmount = 2350,
                        Products = new List<Product>
                        { 
                            new Product { Id = 1, Title = "Iphone 16 pro", Price = 1350},
                            new Product { Id = 2, Title = "Samsung s25", Price = 1000},
                        }
                    }

                }
            };
            
            _userRepositoryMock.Setup(r => r.GetByIdWithOrdersAsync(id))
                .ReturnsAsync(user);

            //Act
            var result = await _userService.GetUserWithOrdersAsync(id);

            //Assert
            result.Should().NotBeNull();
            result.FullName.Should().Be("John Doe");
            result.Orders.Should().HaveCount(1);
            result.Orders.First().Products.Should().HaveCount(2);
        }

        [Fact]
        public async Task GetUserWithOrders_UserNotFound_ThrowNotFoundException()
        {
            //Arrange
            int id = 999999999;
            _userRepositoryMock.Setup(repo => repo.GetByIdWithOrdersAsync(id))
                .ReturnsAsync((User)null);

            //Act & Assert
            await Assert.ThrowsAsync<NotFoundException>(() =>
                _userService.GetUserWithOrdersAsync(id));
        }

        [Fact]
        public async Task GetUserWithOrders_OrderWithoutProduct_ThrowBadrequestException()
        {
            //Arrange
            int id = 3;

            var user = new User
            {
                Id = 1,
                FullName = "Test Test",
                Orders = new List<Order>
                {
                    new Order
                    {
                        Products = new List<Product>()
                    }

                }
            };

            _userRepositoryMock.Setup(r => r.GetByIdWithOrdersAsync(id))
                .ReturnsAsync(user);

            // Act & Assert
            await Assert.ThrowsAsync<BadRequestException>(() =>
                _userService.GetUserWithOrdersAsync(id));
        }
    }
}