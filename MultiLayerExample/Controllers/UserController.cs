using Microsoft.AspNetCore.Mvc;
using MultiLayerExample.Domain.Dtos;
using MultiLayerExample.Domain.Interfaces.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MultiLayerExample.Web.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
             _userService = userService;
        }

        // GET api/user/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> Get(int id)
        {
            var response = await _userService.GetUserFullNameAsync(id);

            return Ok(response);
        }

        // GET api/user/5/orders
        [HttpGet("{id}/orders")]
        public async Task<ActionResult<UserWithOrdersDto>> GetWithOrders(int id)
        {
            var response = await _userService.GetUserWithOrdersAsync(id);

            return Ok(response);
        }
    }
}
