using System;

namespace BookExchange.Infrastructure.DTO
{
    public class SubscriberDTO
    {
        public Guid Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }
}