using System;

namespace BookExchange.Core.Commands
{
    public class DivisionDetails
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid BookId { get; set;}
        public string Title { get; set; }

    }
}