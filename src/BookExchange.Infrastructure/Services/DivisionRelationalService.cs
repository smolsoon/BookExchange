using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BookExchange.Core.Repositories;
using BookExchange.Infrastructure.DTO;

namespace BookExchange.Infrastructure.Services
{
    public class DivisionRelationalService : IDivisionRelationalService
    {
        private readonly IDivisionRelationalRepository _divisionRelationalRepository;
        private readonly IMapper _mapper;

        public DivisionRelationalService(IDivisionRelationalRepository divisionRelationalRepository, IMapper mapper)
        {
            _divisionRelationalRepository = divisionRelationalRepository;
            _mapper = mapper;
        }

        public async Task AddDivision(Guid id, string title)
        {
            await _divisionRelationalRepository.AddDivision(id, title);
        }

        public async Task AddRelationalDivision(Guid userId, Guid divisionId)
        {
            await _divisionRelationalRepository.AddRelationalDivision(userId, divisionId);
        }

        public async Task AddRelationalUserBookDivision(Guid userId, Guid subscriberId, Guid bookId)
        {
            await _divisionRelationalRepository.AddRelationalUserBookDivision(userId, subscriberId, bookId);
        }

        public async Task<ICollection<DivisionDTO>> GetDivisionAsync(Guid userId)
        {
            var divisions = await _divisionRelationalRepository.GetDivisionAsync(userId);
            return _mapper.Map<ICollection<DivisionDTO>>(divisions);
        }

        public async Task<DivisionDTO> GetDivisionIdAsync(Guid userId, Guid divisionId)
        {
            var division = await _divisionRelationalRepository.GetDivisionIdAsync(userId, divisionId);
            return _mapper.Map<DivisionDTO>(division);
        }
    }
}