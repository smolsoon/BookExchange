using System;

namespace BookExchange.Core.Commands
{
    public class UserDetails
    {
        public Guid Id { get; set; }
        public string Role { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime DateOfBirth  { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}