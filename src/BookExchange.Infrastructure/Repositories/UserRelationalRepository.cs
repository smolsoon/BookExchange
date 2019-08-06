using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookExchange.Core.Commands;
using BookExchange.Core.Repositories;
using BookExchange.Infrastructure.Settings;
using Microsoft.Extensions.Options;
using Neo4jClient;

namespace BookExchange.Infrastructure.Repositories
{
    public class UserRelationalRepository : IUserRelationalRepository
    {
        private readonly Neo4JSettings _neo4j;
        private readonly BoltGraphClient _client;
        public UserRelationalRepository(IOptions<Neo4JSettings> neo4j)
        {
            _neo4j = neo4j.Value;
            _client = new BoltGraphClient(_neo4j.Uri, _neo4j.User, _neo4j.Password);
        }
        public Task<UserDetails> GetSubscriberAsync(Guid userId, Guid subscriberId)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<UserDetails>> BrowseSubscribersAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public async Task AddSubscriberAsync(Guid userId, Guid subscriberId)
        {
            await _client.ConnectAsync();
            await _client.Cypher
            .Match("(user:User)", "(subscriber:User)")
            .Where((UserDetails user) => user.Id == userId)
            .AndWhere((UserDetails subscriber) => subscriber.Id == subscriberId)
            .CreateUnique("(user)-[:SUBSCRIBE]->(subscriber)")
            .ExecuteWithoutResultsAsync();
        }      
    }
}