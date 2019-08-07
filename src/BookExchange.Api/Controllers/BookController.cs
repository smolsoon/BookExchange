using System;
using System.Threading.Tasks;
using BookExchange.Infrastructure.Commands;
using BookExchange.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookExchange.Api.Controllers
{
    [Route("[controller]")]
    public class BookController : Controller
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

        [HttpGet]
        public async Task<IActionResult> Get()
            => Json(await _bookService.BrowseAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
            => Json(await _bookService.GetAsync(id));

        [HttpGet("{userId}/yourslibrary")]
        public async Task<IActionResult> GetAllBooks(Guid userId)
            =>Json(await _relationalService.BrowseUserBooksAsync(userId));

        [HttpGet("{userId}/yourslibrary/{bookId}")]
        public async Task<IActionResult> GetUserBook(Guid userId, Guid bookId)
            =>Json(await _relationalService.GetUserBookAsync(userId, bookId));

        [HttpPost("{userId}/yourslibrary/addBook")]
        public async Task<IActionResult> Post([FromBody]AddBook command, Guid userId)
        {    
            command.Id = Guid.NewGuid();
            await _bookService.AddBook(command.Id, command.Title, command.Author, 
            command.PublishingHouse, command.Year);
            await _relationalService.AddBookRelationalUser(userId, command.Id);

            return Created("/book/{userId}", null);
        }
    }
}