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

        [HttpGet("{userId}/following")]
        public async Task<IActionResult> GetFollowing(Guid userId)
            =>Json(await _userRelationalService.GetFollowingAsync(userId));

        [HttpGet("{userId}/following/{subscriberId}")]
        public async Task<IActionResult> GetFollowingById(Guid userId, Guid subscribeId)
            => Json(await _userRelationalService.GetFollowingByIdAsync(userId, subscribeId));          

        [HttpGet("{userId}/followers")]
        public async Task<IActionResult> GetFollowers(Guid userId)
            => Json(await _userRelationalService.GetFollowersAsync(userId));
        

        [HttpGet("{userId}/followers/{subscriberId}")]
        public async Task<IActionResult> GetFollowersById(Guid userId, Guid subscribeId)
            =>Json(await _userRelationalService.GetFollowersByIdAsync(userId, subscribeId)); 
        
        [HttpGet("{userId}/following/books")]
        public async Task<IActionResult> GetBookFollowing(Guid userId)
            =>Json(await _userRelationalService.GetBooksByFollowing(userId));

        [HttpGet("{userId}/following/{subscriberId}/books")]
        public async Task<IActionResult> GetBooksByFollowingById(Guid userId, Guid subscribeId)
           =>Json(await _userRelationalService.GetBooksByFollowingById(userId, subscribeId));
        
        [HttpGet("{userId}/following/{subscriberId}/books/{bookId}")]
        public async Task<IActionResult> GetBookIdByFollowingById(Guid userId, Guid subscribeId, Guid bookId)
            =>Json(await _userRelationalService.GetBookIdByFollowingById(userId, subscribeId, bookId));

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

        [HttpPost("{userId}/{subscriberId}/subscribe")]
        public async Task<IActionResult> Subscribe(Guid userId, Guid subscriberId)
        {
            await _userRelationalService.AddSubscriberAsync(userId, subscriberId);
            return Created("/subscribe", null);
        }
    }
}