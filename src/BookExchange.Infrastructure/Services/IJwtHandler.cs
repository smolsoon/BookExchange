using System;
using BookExchange.Infrastructure.DTO;

namespace BookExchange.Infrastructure.Services
{
    public interface IJwtHandler
    {
        JwtDTO CreateToken(Guid userId, string role); 
    }
}