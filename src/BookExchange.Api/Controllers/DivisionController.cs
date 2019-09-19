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
    public class DivisionController : ApiControllerBase
    {
        private readonly IDivisionRelationalService _divisionRelationalService;
        public DivisionController(IDivisionRelationalService divisionRelationalService)
        {
            _divisionRelationalService = divisionRelationalService;
        }

        [HttpGet]
        public async Task<IActionResult> GetDivision()
            => Json(await _divisionRelationalService.GetDivisionAsync(UserId));

        

        [HttpGet("{divisionId}")]
        public async Task<IActionResult> GetDivisionId(Guid divisionId)
            => Json(await _divisionRelationalService.GetDivisionAsync(UserId));

        [HttpPost("following/{subscriberId}/books/{bookId}/lent")]
        public async Task<IActionResult> LentBook(LentBook command, Guid divisionId, Guid subscriberId)
        {
            command.UserId = UserId;
            command.Title = $"ksiazka";
            divisionId = Guid.NewGuid();
            await _divisionRelationalService.AddDivision(divisionId,command.Title, command.BookId, command.UserId);
            await _divisionRelationalService.AddRelationalDivision(subscriberId, divisionId);
            return Created("/division", null);
        }
        
        [HttpPost("{divisionId}/{bookId}/approved")]
        public async Task<IActionResult> Approved (Guid divisionId, Guid bookId)
        {
            var division = await _divisionRelationalService.GetDivisionIdAsync(UserId,divisionId);
            await _divisionRelationalService.AddRelationalUserBookDivision(UserId, bookId);
            return Created("/approved", null);
        }
    }
}