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
        private readonly IDivisionRelationalService _divisionRelationalService;
        public AccountController(IUserService userService, IUserRelationalService userRelationalService,
            IDivisionRelationalService DivisionRelationalService)
        {
            _userService = userService;
            _userRelationalService = userRelationalService;
            _divisionRelationalService = DivisionRelationalService;
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
            =>Json(await _userRelationalService.GetBooksByFollowingAsync(userId));

        [HttpGet("{userId}/following/{subscriberId}/books")]
        public async Task<IActionResult> GetBooksByFollowingById(Guid userId, Guid subscribeId)
           =>Json(await _userRelationalService.GetBooksByFollowingByIdAsync(userId, subscribeId));
        
        [HttpGet("{userId}/following/{subscriberId}/books/{bookId}")]
        public async Task<IActionResult> GetBookIdByFollowingById(Guid userId, Guid subscribeId, Guid bookId)
            =>Json(await _userRelationalService.GetBookIdByFollowingByIdAsync(userId, subscribeId, bookId));

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

        [HttpPost("{userId}/following/{subscriberId}/books/{bookId}/lent")]
        public async Task<IActionResult> LentBook([FromBody]LentBook command, Guid userId, Guid divisionId)
        {
            command.Title = $"jakis gosc chce od CIebie pozyczyc ksiazke";

            await _divisionRelationalService.AddDivision(Guid.NewGuid(),command.Title);
            await _divisionRelationalService.AddRelationalDivision(userId, divisionId);
            return Created("/division", null);
        }

        [HttpGet("{userId}/division")]
        public async Task<IActionResult> GetDivision(Guid userId)
            => Json(await _divisionRelationalService.GetDivisionAsync(userId));

        [HttpGet("{userId}/division/{divisionId}")]
        public async Task<IActionResult> GetDivisionId(Guid userId, Guid divisionId)
            => Json(await _divisionRelationalService.GetDivisionIdAsync(userId, divisionId));


        [HttpPost("{userId}/division/{divisionId}/approved")]
        public Task<IActionResult> Approved (Guid userId, Guid divisionId)
        {
            throw new NotImplementedException();
            //await _divisionRelationalService.AddRelationalUserBookDivision(userId, divisionId);
        }
    }
}