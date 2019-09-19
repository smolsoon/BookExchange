using System;
using System.Security.Claims;
using System.Threading.Tasks;
using BookExchange.Infrastructure.Commands;
using BookExchange.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookExchange.Api.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class FollowingController : ApiControllerBase
    {
        private readonly IUserRelationalService _userRelationalService;
        public FollowingController(IUserRelationalService userRelationalService)
        {
            _userRelationalService = userRelationalService;
        }

        [HttpGet]
        public async Task<IActionResult> GetFollowing()
            => Json(await _userRelationalService.GetFollowingAsync(UserId ));

        [HttpGet("{subscriberId}")]
        public async Task<IActionResult> GetFollowingById(Guid subscribeId)          
            => Json(await _userRelationalService.GetFollowingByIdAsync(UserId, subscribeId));          

        [HttpGet("followers")]
        public async Task<IActionResult> GetFollowers()
            => Json (await _userRelationalService.GetFollowersAsync(UserId));

        [HttpGet("followers/{subscriberId}")]
        public async Task<IActionResult> GetFollowersById(Guid subscribeId)
            =>Json(await _userRelationalService.GetFollowersByIdAsync(UserId, subscribeId));
        
        [HttpGet("books")]
        public async Task<IActionResult> GetBookFollowing()
            =>Json(await _userRelationalService.GetBooksByFollowingAsync(UserId));

        [HttpGet("{subscriberId}/books")]
        public async Task<IActionResult> GetBooksByFollowingById( Guid subscribeId)
           =>Json(await _userRelationalService.GetBooksByFollowingByIdAsync(UserId, subscribeId));
        
        [HttpGet("{subscriberId}/books/{bookId}")]
        public async Task<IActionResult> GetBookIdByFollowingById(Guid subscribeId, Guid bookId)
            =>Json(await _userRelationalService.GetBookIdByFollowingByIdAsync(UserId, subscribeId, bookId));

        [HttpPost("{subscriberId}/subscribe")]
        public async Task<IActionResult> Subscribe(Guid subscriberId)
        {
            await _userRelationalService.AddSubscriberAsync(UserId, subscriberId);
            return Created("/subscribe", null);
        }
    }
}