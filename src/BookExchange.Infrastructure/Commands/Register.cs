using System;

namespace BookExchange.Infrastructure.Commands
{
    public class Register
    {
        public string Role { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime DateOfBirth  { get; set; }

    }
}