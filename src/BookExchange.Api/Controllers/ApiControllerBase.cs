using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace BookExchange.Api.Controllers
{
    public class ApiControllerBase : Controller
    {
        protected Guid UserId => User?.Identity.IsAuthenticated == true ?
            Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)) :
            Guid.Empty;
    }
}