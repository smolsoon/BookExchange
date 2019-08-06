using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookExchange.Core.Commands;
using BookExchange.Core.Model;

namespace BookExchange.Core.Repositories
{
    public interface IBookRepository
    {
        Task<BookDetails> GetBookAsync(Guid id);
        Task<BookDetails> GetBookAsync(string title);
        Task<ICollection<BookDetails>> BrowseBooksAsync();
        Task AddBookAsync(Book book);
        Task UpdateBookAsync(Book book);
        Task DeleteBookAsync(Book book); 
    }
}