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
using Neo4jClient;

namespace BookExchange.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly Neo4JSettings _neo4j;
        private readonly BoltGraphClient _client;
        public BookRepository(IOptions<Neo4JSettings> neo4j)
        {
            _neo4j = neo4j.Value;
            _client = new BoltGraphClient(_neo4j.Uri, _neo4j.User, _neo4j.Password);
        }


        public async Task<BookDetails> GetBookAsync(Guid id)
        {
            await _client.ConnectAsync();
            var query = _client.Cypher
                .Match("(book:Book)")
                .Where((BookDetails book) => book.Id == id)
                .Return(book => book.As<BookDetails>())
                .Limit(1);

            return (await query.ResultsAsync).FirstOrDefault();
        }

        public async Task<BookDetails> GetBookAsync(string title)
        {
            await _client.ConnectAsync();
            var query = _client.Cypher
                .Match("(book:Book)")
                .Where((BookDetails book) => book.Title == title)
                .Return(book => book.As<BookDetails>())
                .Limit(1);

            return (await query.ResultsAsync).FirstOrDefault();
        }

        public async Task<ICollection<BookDetails>> BrowseBooksAsync()
        {
            await _client.ConnectAsync();

            var query = _client.Cypher 
                .Match("(n:Book)")
                .Return(n=> n.As<BookDetails>());

            return (await query.ResultsAsync).ToList();
        }

        public async Task AddBookAsync(Book book)
        {
            await _client.ConnectAsync();

            await _client.Cypher
            .Create("(x:Book {book})")
            .WithParam("book", new{
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                PublishingHouse = book.PublishingHouse,
                Year = book.Year
            })
            .ExecuteWithoutResultsAsync(); 
        }

        public Task UpdateBookAsync(Book book)
        {
            throw new NotImplementedException();
        }
        public Task DeleteBookAsync(Book book)
        {
            throw new NotImplementedException();
        }

        
    }
}