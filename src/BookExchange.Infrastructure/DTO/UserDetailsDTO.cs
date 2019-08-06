using System;

namespace BookExchange.Infrastructure.DTO
{
    public class UserDetailsDTO
    {
        public Guid Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth  { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}