using System;
using System.Threading.Tasks;
using BookExchange.Core.Model;
using BookExchange.Infrastructure.Commands;
using BookExchange.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookExchange.Api.Controllers
{
    [Route("[controller]")]
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly IUserRelationalService _userRelationalService;
        public AccountController(IUserService userService, IUserRelationalService userRelationalService)
        {
            _userService = userService;
            _userRelationalService = userRelationalService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
            => Json(await _userService.BrowseAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(Guid id)
            =>Json(await _userService.GetAccountAsync(id));        

        [HttpPost("register")]
        public async Task<IActionResult> Post([FromBody]Register command)
        {
            await _userService.RegisterAsync(Guid.NewGuid(), command.Email,command.Firstname, command.Lastname, 
                command.Password, command.DateOfBirth, command.Role);

            return Created("/account", null);
        }
        
        [HttpPost("login")]
        public async Task<IActionResult> Post([FromBody]Login command)
            => Json(await _userService.LoginAsync(command.Email, command.Password));

    }
}