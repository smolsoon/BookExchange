using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BookExchange.Core.Repositories;
using BookExchange.Infrastructure.DTO;

namespace BookExchange.Infrastructure.Services
{
    public class LentService : ILentService
    {
        private readonly ILentRepository _lentRepository;
        private readonly IMapper _mapper;
        public LentService(ILentRepository lentRepository, IMapper mapper)
        {
            _lentRepository = lentRepository;
            _mapper = mapper;
        }
        public async Task<ICollection<BookDTO>> BrowseBooks()
        {
            var lent = await _lentRepository.BrowseLentBooks();
            return _mapper.Map<ICollection<BookDTO>>(lent);
        }
        public async Task<BookDTO> GetBook(Guid id)
        {
            var lent = await _lentRepository.GetLentBook(id);
            return _mapper.Map<BookDTO>(lent);
        }
    }
}