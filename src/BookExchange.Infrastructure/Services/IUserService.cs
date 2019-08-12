using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookExchange.Core.Model;
using BookExchange.Infrastructure.DTO;

namespace BookExchange.Infrastructure.Services
{
    public interface IUserService
    {
        Task<ICollection<UserDetailsDTO>> BrowseAsync();
        Task<UserDetailsDTO> GetAccountAsync (Guid userId);
        Task RegisterAsync(Guid userId, string email, string firstname, string lastname, 
            string password, DateTime dateOfBirth, string role = "user");
        Task<TokenDTO> LoginAsync(string email, string password);
        UserDetailsDTO GetUser(Guid userId);
    }
}