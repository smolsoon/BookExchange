using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookExchange.Core.Commands;
using BookExchange.Core.Model;
using BookExchange.Core.Repositories;
using BookExchange.Infrastructure.Settings;
using Microsoft.Extensions.Options;
using Neo4jClient;

namespace BookExchange.Infrastructure.Repositories
{
    public class BookRelationalRepository : IBookRelationalRepository
    {
        private readonly Neo4JSettings _neo4j;
        private readonly BoltGraphClient _client;
        public BookRelationalRepository(IOptions<Neo4JSettings> neo4j)
        {
            _neo4j = neo4j.Value;
            _client = new BoltGraphClient(_neo4j.Uri, _neo4j.User, _neo4j.Password);
        }

        public async Task<BookDetails> GetUserBookAsync(Guid userId, Guid bookId)
        {
            await _client.ConnectAsync();
            var query = _client.Cypher
                .OptionalMatch("(user:User)-[:HAVE]->(book:Book)")
                .Where((UserDetails user) => user.Id == userId)
                .AndWhere((BookDetails book) => book.Id == bookId)
                .Return(book => book.As<BookDetails>())
                .Limit(1);

            return (await query.ResultsAsync).FirstOrDefault();
        }
        
        public async Task<ICollection<BookDetails>> BrowseUserBooksAsync(Guid userId)
        {
            await _client.ConnectAsync();
            var query = _client.Cypher 
                .OptionalMatch("(user:User)-[:HAVE]->(book:Book)")
                .Where((UserDetails user) => user.Id == userId)
                .Return(book=> book.As<BookDetails>());

            return (await query.ResultsAsync).ToList();           
        }

        public async Task AddBookRelationalUser(Guid userId, Guid bookId)
        {
            await _client.ConnectAsync();
            await _client.Cypher
            .Match("(user:User)", "(book:Book)")
            .Where((UserDetails user) => user.Id == userId)
            .AndWhere((BookDetails book) => book.Id == bookId)
            .CreateUnique("(user)-[:HAVE]->(book)")
            .ExecuteWithoutResultsAsync();
        } 
    }
}