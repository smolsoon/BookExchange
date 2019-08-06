using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BookExchange.Core.Model;
using BookExchange.Core.Repositories;
using BookExchange.Infrastructure.DTO;

namespace BookExchange.Infrastructure.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public BookService(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<BookDetailsDTO> GetAsync(Guid id)
        {
            var book = await _bookRepository.GetBookAsync(id);
            return _mapper.Map<BookDetailsDTO>(book);
        }

        public async Task<BookDetailsDTO> GetAsync(string title)
        {
            var book = await _bookRepository.GetBookAsync(title);
            return _mapper.Map<BookDetailsDTO>(book);
        }

        public async Task<ICollection<BookDetailsDTO>> BrowseAsync()
        {
            var books = await _bookRepository.BrowseBooksAsync();
            return _mapper.Map<ICollection<BookDetailsDTO>>(books);
        }

        public async Task AddBook(Guid id, string title, string author, string publishingHouse, int year)
        {
            var book = new Book(id, title, author, publishingHouse, year);
            await _bookRepository.AddBookAsync(book);
        }
    }
}