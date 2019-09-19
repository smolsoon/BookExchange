using System;

namespace BookExchange.Infrastructure.Commands
{
    public class LentBook
    {
        public Guid Id { get; set; }
        public Guid BookId { get; set; }
        public Guid UserId { get; set; }
        public string Title { get; set; }
    }
}