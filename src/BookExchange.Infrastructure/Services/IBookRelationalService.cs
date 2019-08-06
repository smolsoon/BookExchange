using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookExchange.Infrastructure.DTO;

namespace BookExchange.Infrastructure.Services
{
    public interface IBookRelationalService
    {
        Task<BookDetailsDTO> GetUserBookAsync(Guid userId, Guid bookId);
        Task<ICollection<BookDetailsDTO>> BrowseUserBooksAsync(Guid userId);        
        Task AddBookRelationalUser(Guid userId, Guid bookId);
    }
}