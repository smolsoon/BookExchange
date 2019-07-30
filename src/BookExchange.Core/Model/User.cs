using System;
using System.Collections.Generic;

namespace BookExchange.Core.Model
{
    public class User : Entity
    {
        private static List<string> _roles = new List<string>
        {
            "user", "admin"
        };
        public string Role { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime DateOfBirth  { get; set; }
        public DateTime CreatedAt { get; set; }

        protected User()
        {
        }

        public User(Guid id, string role, string name,string email, string password)
        {
        }

    }
}