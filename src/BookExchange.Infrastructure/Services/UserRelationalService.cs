using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BookExchange.Core.Commands;
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
        
        public async Task<ICollection<SubscriberDTO>> GetFollowersAsync(Guid userId)
        {
            var subscriber = await _userRelationalRepository.GetFollowersAsync(userId);
            return _mapper.Map<ICollection<SubscriberDTO>>(subscriber);
        }

        public async Task<ICollection<SubscriberDTO>> GetFollowingAsync(Guid userId)
        {
            var subscriber = await _userRelationalRepository.GetFollowingAsync(userId);
            return _mapper.Map<ICollection<SubscriberDTO>>(subscriber);
        }

        public async Task<SubscriberDTO> GetFollowingByIdAsync(Guid userId, Guid subscriberId)
        {
            var subscriber = await _userRelationalRepository.GetFollowingByIdAsync(userId, subscriberId);
            return _mapper.Map<SubscriberDTO>(subscriber);
        }

        public async Task<SubscriberDTO> GetFollowersByIdAsync(Guid userId, Guid subscriberId)
        {
            var subscriber = await _userRelationalRepository.GetFollowersByIdAsync(userId, subscriberId);
            return _mapper.Map<SubscriberDTO>(subscriber);
        }

        public async Task<ICollection<BookDetailsDTO>> GetBooksByFollowing(Guid userId)
        {
            var booksByFollowing = await _userRelationalRepository.GetBooksByFollowing(userId);
            return _mapper.Map<ICollection<BookDetailsDTO>>(booksByFollowing);
        }

        public async Task<ICollection<BookDetailsDTO>> GetBooksByFollowingById(Guid userId, Guid subscriberId)
        {
            var booksByFollowingId = await _userRelationalRepository.GetBooksByFollowingById(userId, subscriberId);
            return _mapper.Map<ICollection<BookDetailsDTO>>(booksByFollowingId);
        }

        public async Task<BookDetailsDTO> GetBookIdByFollowingById(Guid userId, Guid subscriberId, Guid bookId)
        {
            var booksIdByFollowingId = await _userRelationalRepository.GetBookIdByFollowingById(userId, subscriberId, bookId);
            return _mapper.Map<BookDetailsDTO>(booksIdByFollowingId);
        }

        public async Task AddSubscriberAsync(Guid userId, Guid subscriberId)
        {
            await _userRelationalRepository.AddSubscriberAsync(userId, subscriberId);
        }
    }
}