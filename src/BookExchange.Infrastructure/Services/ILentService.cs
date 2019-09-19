using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookExchange.Infrastructure.DTO;

namespace BookExchange.Infrastructure.Services
{
    public interface ILentService
    {
         Task<BookDTO> GetBook(Guid id);
         Task<ICollection<BookDTO>> BrowseBooks();
    }
}