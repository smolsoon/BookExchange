using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookExchange.Core.Commands;
using BookExchange.Core.Model;
using BookExchange.Core.Repositories;
using BookExchange.Infrastructure.DTO;
using BookExchange.Infrastructure.Settings;
using Microsoft.Extensions.Options;
using Neo4j.Driver.V1;
using Neo4jClient;

namespace BookExchange.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly Neo4JSettings _neo4j;
        private readonly BoltGraphClient _client;
        public UserRepository(IOptions<Neo4JSettings> neo4j)
        {
            _neo4j = neo4j.Value;
            _client = new BoltGraphClient(_neo4j.Uri, _neo4j.User, _neo4j.Password);
        }

        public async Task<UserDetails> GetUserAsync(Guid id)
        {
            await _client.ConnectAsync();
            var query = _client.Cypher
                .Match("(user:User)")
                .Where((UserDetails user) => user.Id == id)
                .Return(user => user.As<UserDetails>())
                .Limit(1);

            return (await query.ResultsAsync).FirstOrDefault();
        }

        public async Task<UserDetails> GetUserAsync(string email)
        {
            await _client.ConnectAsync();
            var query = _client.Cypher
                .Match("(user:User)")
                .Where((UserDetails user) => user.Email == email)
                .Return(user => user.As<UserDetails>())
                .Limit(1);

            return (await query.ResultsAsync).FirstOrDefault();
        }

        public async Task<ICollection<UserDetails>> BrowseUsersAsync()
        {
            await _client.ConnectAsync();
            var query = _client.Cypher 
                .Match("(n:User)")
                .Return(n=> n.As<UserDetails>());

            return (await query.ResultsAsync).ToList();
        }

        public async Task AddUserAsync(User user)
        {
            await _client.ConnectAsync();
            await _client.Cypher
            .Create("(x:User {user})")
            .WithParam("user", new{
                Id = user.Id,
                Email = user.Email,
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                Password = user.Password,
                DateOfBirth = user.DateOfBirth,
                Role = user.Role
            })
            .ExecuteWithoutResultsAsync(); 
        }

        public Task UpdateUserAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteUserAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}