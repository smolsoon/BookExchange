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
    public class DivisionRelationalRepository : IDivisionRelationalRepository
    {
        private readonly Neo4JSettings _neo4j;
        private readonly BoltGraphClient _client;
        public DivisionRelationalRepository(IOptions<Neo4JSettings> neo4j)
        {
            _neo4j = neo4j.Value;
            _client = new BoltGraphClient(_neo4j.Uri, _neo4j.User, _neo4j.Password);
        }

        public async Task AddRelationalDivision(Guid userId, Guid divisionId)
        {
            await _client.ConnectAsync();
            await _client.Cypher
            .Match("(user:User)", "(division:Division)")
            .Where((UserDetails user) => user.Id == userId)
            .AndWhere((DivisionDetails division) => division.Id == divisionId)
            .CreateUnique("(user)-[:YOUR_DIVISION]->(division)")
            .ExecuteWithoutResultsAsync();
        }

        public async Task AddDivision(Guid id, string title)
        {
            await _client.ConnectAsync();

            await _client.Cypher
            .Create("(x:Division {division})")
            .WithParam("division", new{
                Id = id,
                Title = title
            })
            .ExecuteWithoutResultsAsync(); 
        }

        public async Task AddQeuryDivision(Guid userId, Guid subscriberId, Guid bookId)
        {
            await _client.ConnectAsync();
            await _client.Cypher
            .Match("(user:User)", "(subscriber:User)" )
            .Where((UserDetails user) => user.Id == userId)
            .AndWhere((UserDetails subscriber) => subscriber.Id == subscriberId)
            .CreateUnique("(user)-[:SUBSCRIBE]->(subscriber)")
            .ExecuteWithoutResultsAsync();
        }

        public Task<ICollection<DivisionDetails>> GetDivisionAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<DivisionDetails> GetDivisionIdAsync(Guid userId, Guid divisionId)
        {
            throw new NotImplementedException();
        }

        public Task AddRelationalDivision(Guid userId, Guid subscriberId, Guid bookId)
        {
            throw new NotImplementedException();
        }

        public Task AddRelationalUserBookDivision(Guid userId, Guid subscriberId, Guid bookId)
        {
            throw new NotImplementedException();
        }
    }
}