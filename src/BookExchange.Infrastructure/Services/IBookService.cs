using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookExchange.Core.Model;
using BookExchange.Infrastructure.DTO;

namespace BookExchange.Infrastructure.Services
{
    public interface IBookService
    {
        Task<BookDetailsDTO> GetAsync(Guid id);
        Task<BookDetailsDTO> GetAsync(string title);
        Task<ICollection<BookDetailsDTO>> BrowseAsync();
        Task AddBook(Guid id, string title, string author, string publishingHouse, int year);
    }
}