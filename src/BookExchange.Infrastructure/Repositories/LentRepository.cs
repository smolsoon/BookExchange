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
    public class LentRepository : ILentRepository
    {
        private readonly Neo4JSettings _neo4j;
        private readonly BoltGraphClient _client;
        public LentRepository(IOptions<Neo4JSettings> neo4j)
        {
            _neo4j = neo4j.Value;
            _client = new BoltGraphClient(_neo4j.Uri, _neo4j.User, _neo4j.Password);
        }
        public Task<ICollection<BookDetails>> BrowseLentBooks()
        {
            throw new NotImplementedException();
        }

        public Task<BookDetails> GetLentBook(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}