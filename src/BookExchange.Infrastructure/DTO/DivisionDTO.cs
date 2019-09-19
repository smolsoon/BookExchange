using System;

namespace BookExchange.Infrastructure.DTO
{
    public class DivisionDTO
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid BookId { get; set;}
        public string Title { get; set; }
    }
}