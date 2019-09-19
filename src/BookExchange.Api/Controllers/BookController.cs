using System;
using System.Threading.Tasks;
using BookExchange.Infrastructure.Commands;
using BookExchange.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace BookExchange.Api.Controllers
{
    [Route("[controller]")]
    public class BookController : ApiControllerBase
    {
        private readonly IBookService _bookService;
        private readonly IBookRelationalService _relationalService;
        private readonly IUserService _userService;
        
        public BookController(IBookService bookService, IBookRelationalService relationalService,
            IUserService userService)
        {
            _bookService = bookService;
            _relationalService = relationalService;
            _userService = userService;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
            => Json(await _relationalService.BrowseUserBooksAsync(UserId));

        [Authorize]
        [HttpGet("{bookId}")]
        public async Task<IActionResult> GetUserBook(Guid bookId)
            => Json(await _relationalService.GetUserBookAsync(UserId, bookId));

        [Authorize]
        [HttpPost("addBook")]
        public async Task<IActionResult> Post([FromBody]AddBook command)
        {    
            command.Id = Guid.NewGuid();
            await _bookService.AddBook(command.Id, command.Title, command.Author, 
            command.PublishingHouse, command.Year);
            await _relationalService.AddBookRelationalUser(UserId, command.Id);

            return Created("/book/{userId}", null);
        }
    }
}