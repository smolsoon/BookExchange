using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BookExchange.Core.Repositories;
using BookExchange.Infrastructure.DTO;

namespace BookExchange.Infrastructure.Services
{
    public class UserRelationalService : IUserRelationalService
    {
        private readonly IUserRelationalRepository _userRelationalRepository;
        private readonly IMapper _mapper;

        public UserRelationalService(IUserRelationalRepository userRelationalRepository, IMapper mapper)
        {
            _userRelationalRepository = userRelationalRepository;
            _mapper = mapper;
        }
        
        public async Task<SubscriberDTO> GetSubscriberAsync(Guid userId, Guid subscriberId)
        {
            var subscriber = await _userRelationalRepository.GetSubscriberAsync(userId, subscriberId);
            return _mapper.Map<SubscriberDTO>(subscriber);
        }

        public async Task<ICollection<SubscriberDTO>> BrowseSubscribersAsync(Guid id)
        {
            var subscribers = await _userRelationalRepository.BrowseSubscribersAsync(id);
            return _mapper.Map<ICollection<SubscriberDTO>>(subscribers);
        }
        
        public async Task AddSubscriberAsync(Guid userId, Guid subscriberId)
        {
            await _userRelationalRepository.AddSubscriberAsync(userId, subscriberId);
        }
    }
}