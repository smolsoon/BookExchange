using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookExchange.Infrastructure.DTO;

namespace BookExchange.Infrastructure.Services
{
    public interface IDivisionRelationalService
    {
        Task<ICollection<DivisionDTO>> GetDivisionAsync(Guid userId);
        Task<DivisionDTO> GetDivisionIdAsync(Guid userId, Guid divisionId);
        Task AddDivision(Guid id, string title, Guid bookId, Guid userId);
        Task AddRelationalDivision(Guid userId, Guid divisionId);
        Task AddRelationalUserBookDivision(Guid subscriberId, Guid bookId);
    }
}