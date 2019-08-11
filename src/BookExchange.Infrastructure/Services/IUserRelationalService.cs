using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookExchange.Core.Commands;
using BookExchange.Infrastructure.DTO;

namespace BookExchange.Infrastructure.Services
{
    public interface IUserRelationalService
    {
        Task<ICollection<SubscriberDTO>> GetFollowingAsync(Guid userId);
        Task<ICollection<SubscriberDTO>> GetFollowersAsync(Guid userId);
        Task<SubscriberDTO> GetFollowingByIdAsync(Guid userId, Guid subscriberId);
        Task<SubscriberDTO> GetFollowersByIdAsync(Guid userId, Guid subscriberId);
        Task<ICollection<BookDetailsDTO>> GetBooksByFollowingAsync(Guid userId);
        Task<ICollection<BookDetailsDTO>> GetBooksByFollowingByIdAsync(Guid userId, Guid subscriberId);
        Task<BookDetailsDTO> GetBookIdByFollowingByIdAsync(Guid userId, Guid subscriberId, Guid bookId);
        Task AddSubscriberAsync(Guid userId, Guid subscriberId);
    }
}