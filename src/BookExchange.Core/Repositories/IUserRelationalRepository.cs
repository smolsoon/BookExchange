using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookExchange.Core.Commands;

namespace BookExchange.Core.Repositories
{
    public interface IUserRelationalRepository
    {
        Task<UserDetails> GetSubscriberAsync(Guid userId, Guid subscriberId);
        Task<ICollection<UserDetails>> BrowseSubscribersAsync(Guid userId);
        Task AddSubscriberAsync(Guid userId, Guid subscriberId);
    }
}