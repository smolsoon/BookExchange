using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BookExchange.Core.Model;
using BookExchange.Core.Repositories;
using BookExchange.Infrastructure.DTO;

namespace BookExchange.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtHandler _jwtHandler;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IJwtHandler jwtHandler, IMapper mapper)
        {
            _userRepository = userRepository;
            _jwtHandler = jwtHandler;
            _mapper = mapper;
        }

        public async Task<ICollection<AccountDTO>> BrowseAsync()
        {
            var users = await _userRepository.BrowseUsersAsync();
            return _mapper.Map<ICollection<AccountDTO>>(users);
        }

        public async Task<UserDetailsDTO> GetAccountAsync (Guid userId)
        {
            var user = await _userRepository.GetUserAsync(userId);
            return _mapper.Map<UserDetailsDTO>(user);
        }

        public async Task<TokenDTO> LoginAsync(string email, string password)
        {
            var user = (await _userRepository.GetUserAsync(email));
            if(user == null)
            {
                throw new Exception("Invalid credentials.");
            }
            if(user.Password != password)
            {
                throw new Exception("Invalid credentials.");
            }
            var jwt = _jwtHandler.CreateToken(user.Id, user.Role);

            return new TokenDTO
            {
                Token = jwt.Token,
                Expires = jwt.Expires,
                Role = user.Role
            };            
        }

        public async Task RegisterAsync(Guid userId, string email, string firstname, string lastname, 
            string password, DateTime dateOfBirth, string role = "user")
        {
            var user = new User(userId, role, firstname,lastname, email, password, dateOfBirth);
            await _userRepository.AddUserAsync(user); 
        }
    }
}