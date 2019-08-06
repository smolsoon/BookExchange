using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookExchange.Core.Commands;
using BookExchange.Core.Model;

namespace BookExchange.Core.Repositories
{
    public interface IUserRepository
    {
        Task<UserDetails> GetUserAsync(Guid id);
        Task<UserDetails> GetUserAsync(string email);
        Task<ICollection<UserDetails>> BrowseUsersAsync();
        Task AddUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(User user); 
    }
}