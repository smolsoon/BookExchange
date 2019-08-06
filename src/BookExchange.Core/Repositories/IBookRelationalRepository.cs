using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookExchange.Core.Commands;

namespace BookExchange.Core.Repositories
{
    public interface IBookRelationalRepository
    {
        Task<BookDetails> GetUserBookAsync(Guid userId, Guid bookId);
        Task<ICollection<BookDetails>> BrowseUserBooksAsync(Guid userId);
        Task AddBookRelationalUser(Guid userId, Guid bookId);
    }
}