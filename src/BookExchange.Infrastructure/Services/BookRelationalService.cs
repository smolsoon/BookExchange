using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BookExchange.Core.Repositories;
using BookExchange.Infrastructure.DTO;

namespace BookExchange.Infrastructure.Services
{
    public class BookRelationalService : IBookRelationalService
    {
        private readonly IBookRelationalRepository _relationalRepository;
        private readonly IMapper _mapper;

        public BookRelationalService(IBookRelationalRepository relationalRepository, IMapper mapper)
        {
           _relationalRepository = relationalRepository;
           _mapper = mapper;
        }
    
        public async Task<BookDetailsDTO> GetUserBookAsync(Guid userId, Guid bookId)
        {
            var book = await _relationalRepository.GetUserBookAsync(userId, bookId);
            return _mapper.Map<BookDetailsDTO>(book);
        }
    
        public async Task<ICollection<BookDetailsDTO>> BrowseUserBooksAsync(Guid userId)
        {
            var books = await _relationalRepository.BrowseUserBooksAsync(userId);
            return _mapper.Map<ICollection<BookDetailsDTO>>(books);
        }

        public async Task AddBookRelationalUser(Guid userId, Guid bookId)
        {
            await _relationalRepository.AddBookRelationalUser(userId, bookId);
        }    
    }
}