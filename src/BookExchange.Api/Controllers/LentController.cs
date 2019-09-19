using BookExchange.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookExchange.Api.Controllers
{
    public class LentController : Controller
    {
        private readonly ILentService _lentService;
        public LentController(ILentService lentService)
        {
            _lentService = lentService;
        }
    }
}