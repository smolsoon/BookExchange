using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookExchange.Core.Commands;

namespace BookExchange.Core.Repositories
{
    public interface IDivisionRelationalRepository
    {
        Task<ICollection<DivisionDetails>> GetDivisionAsync(Guid userId);
        Task<DivisionDetails> GetDivisionIdAsync(Guid userId, Guid divisionId);
        Task AddDivision(Guid id, string title);
        Task AddRelationalDivision(Guid userId, Guid divisionId);
        Task AddRelationalUserBookDivision(Guid userId, Guid subscriberId, Guid bookId);
    }
}