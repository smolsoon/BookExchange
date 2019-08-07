using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookExchange.Core.Commands;

namespace BookExchange.Core.Repositories
{
    public interface IUserRelationalRepository
    {
        Task<ICollection<UserDetails>> GetFollowingAsync(Guid userId);
        Task<ICollection<UserDetails>> GetFollowersAsync(Guid userId);
        Task<UserDetails> GetFollowingByIdAsync(Guid userId, Guid subscriberId);
        Task<UserDetails> GetFollowersByIdAsync(Guid userId, Guid subscriberId);
        Task<ICollection<BookDetails>> GetBooksByFollowing(Guid userId);
        Task<ICollection<BookDetails>> GetBooksByFollowingById(Guid userId, Guid subscriberId);
        Task<BookDetails> GetBookIdByFollowingById(Guid userId, Guid subscriberId, Guid bookId);
        Task AddSubscriberAsync(Guid userId, Guid subscriberId);
    }
}