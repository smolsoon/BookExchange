using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookExchange.Infrastructure.DTO;

namespace BookExchange.Infrastructure.Services
{
    public interface IUserRelationalService
    {
        Task<SubscriberDTO> GetSubscriberAsync(Guid userId, Guid subscriberId);
        Task<ICollection<SubscriberDTO>> BrowseSubscribersAsync(Guid userId);
        Task AddSubscriberAsync (Guid userId, Guid subscriberId);
    }
}