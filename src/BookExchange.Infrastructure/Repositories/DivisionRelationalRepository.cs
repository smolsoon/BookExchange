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
    public class DivisionRelationalRepository : IDivisionRelationalRepository
    {
        private readonly Neo4JSettings _neo4j;
        private readonly BoltGraphClient _client;
        public DivisionRelationalRepository(IOptions<Neo4JSettings> neo4j)
        {
            _neo4j = neo4j.Value;
            _client = new BoltGraphClient(_neo4j.Uri, _neo4j.User, _neo4j.Password);
        }

        public async Task<ICollection<DivisionDetails>> GetDivisionAsync(Guid userId)
        {
            await _client.ConnectAsync();
            var query = _client.Cypher 
                .OptionalMatch("(user:User)-[:YOUR_DIVISION]->(division:Division)")
                .Where((DivisionDetails user) => user.Id == userId)
                .Return(division=> division.As<DivisionDetails>());

            return (await query.ResultsAsync).ToList();
        }

        public async Task<DivisionDetails> GetDivisionIdAsync(Guid userId, Guid divisionId)
        {
            await _client.ConnectAsync();
            var query = _client.Cypher
                .OptionalMatch("(user:User)-[:YOUR_DIVISION]->(division:Division)")
                .Where((UserDetails user) => user.Id == userId)
                .AndWhere((DivisionDetails division) => division.Id == divisionId)
                .Return(division => division.As<DivisionDetails>());

            return (await query.ResultsAsync).FirstOrDefault();
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

        public async Task AddDivision(Guid id, string title, Guid bookId, Guid userId)
        {
            await _client.ConnectAsync();

            await _client.Cypher
            .Create("(x:Division {division})")
            .WithParam("division", new{
                Id = id,
                UserId = userId,
                Title = title,
                BookId = bookId 
            })
            .ExecuteWithoutResultsAsync(); 
        }

        public async Task AddRelationalUserBookDivision(Guid subscriberId, Guid bookId)
        {
            await _client.ConnectAsync();
            await _client.Cypher
            .Match("(subscriber:User)", "(book:Book)" )
            .Where((UserDetails subscriber) => subscriber.Id == subscriberId)
            .AndWhere((BookDetails book) => book.Id == bookId)
            .CreateUnique("(subscriber)-[:LENT]->(book)")
            .ExecuteWithoutResultsAsync();
        }
    }
}