using System;

namespace BookExchange.Infrastructure.Commands
{
    public class AddBook
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string  Author { get; set; }
        public string PublishingHouse { get; set; }
        public int Year { get; set; }
    }
}