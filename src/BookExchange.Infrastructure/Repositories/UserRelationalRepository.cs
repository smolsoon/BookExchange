using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<ICollection<UserDetails>> GetFollowingAsync(Guid userId)
        {
            await _client.ConnectAsync();
            var query = _client.Cypher
                .OptionalMatch("(user:User)-[SUBSCRIBE]->(subscriber:User)")
                .Where((UserDetails user) => user.Id == userId)
                .Return(subscriber=> subscriber.As<UserDetails>());

            return (await query.ResultsAsync).ToList();        
        }

        public async Task<ICollection<UserDetails>> GetFollowersAsync(Guid userId)
        {
            await _client.ConnectAsync();
            var query = _client.Cypher
                .OptionalMatch("(subscriber:User)-[:SUBSCRIBE]->(user:User)")
                .Where((UserDetails user) => user.Id == userId)
                .Return(subscriber=> subscriber.As<UserDetails>());
                
            return (await query.ResultsAsync).ToList();
        }

        public async Task<UserDetails> GetFollowingByIdAsync(Guid userId, Guid subscriberId)
        {
            await _client.ConnectAsync();
            var query = _client.Cypher
                .OptionalMatch("(user:User)-[SUBSCRIBE]->(subscriber:User)")
                .Where((UserDetails user) => user.Id == userId)
                .Return(subscriber=> subscriber.As<UserDetails>());
                
            return (await query.ResultsAsync).FirstOrDefault();
        }

        public async Task<UserDetails> GetFollowersByIdAsync(Guid userId, Guid subscriberId)
        {
            await _client.ConnectAsync();
            var query = _client.Cypher
                .OptionalMatch("(subscriber:User)-[:SUBSCRIBE]->(user:User)")
                .Where((UserDetails user) => user.Id == userId)
                .AndWhere((UserDetails subscriber)=> subscriber.Id == subscriberId)
                .Return(subscriber=> subscriber.As<UserDetails>());
                
            return (await query.ResultsAsync).FirstOrDefault();
        }

        public async Task<ICollection<BookDetails>> GetBooksByFollowing(Guid userId)
        {
            await _client.ConnectAsync();
            var query = _client.Cypher
                .Match("(subscriber:User)-[:HAVE]->(book:Book)", "(user:User)-[:SUBSCRIBE]->(subscriber:User)")
                .Where((UserDetails user) => user.Id == userId)
                .Return(book => book.As<BookDetails>());
                
            return (await query.ResultsAsync).ToList();
        }

        public async Task<ICollection<BookDetails>> GetBooksByFollowingById(Guid userId, Guid subscriberId)
        {
            await _client.ConnectAsync();
            var query = _client.Cypher
                .Match("(user:User{Id:"+ $"userId"+"})-[:SUBSCRIBE]->(subscriber:User{Id:"+$"subscriberId"+"})-[:HAVE]->(book:Book)")
                .Return(book => book.As<BookDetails>());
            //do poprawy
            return (await query.ResultsAsync).ToList();
        }

        public Task<BookDetails> GetBookIdByFollowingById(Guid userId, Guid subscriberId, Guid bookId)
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