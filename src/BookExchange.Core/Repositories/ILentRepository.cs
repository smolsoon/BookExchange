using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookExchange.Core.Commands;

namespace BookExchange.Core.Repositories
{
    public interface ILentRepository
    {
        Task<BookDetails> GetLentBook(Guid id);
        Task<ICollection<BookDetails>> BrowseLentBooks();
         //zakocnzyc pozyczanie 

    }
}