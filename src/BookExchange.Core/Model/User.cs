using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace BookExchange.Core.Model
{
    public class User 
    {
        public Guid Id { get; set; }
        public string Role { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime DateOfBirth  { get; set; }
        public DateTime CreatedAt { get; set; }

        private static List<string> _roles = new List<string>
        {
            "user", "admin"
        };

         protected User()
        {
        }
        
        public User(Guid id)
        {
            Id = id;
        }

        public User(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }

        public User(Guid id, string role, string firstname, string lastname, string email, 
            string password, DateTime dateOfBirth)
        {
            Id = id;
            Role = role;
            Firstname = firstname;
            Lastname = lastname;
            Email = email;
            Password = password;
            DateOfBirth = dateOfBirth;
            CreatedAt = DateTime.UtcNow;
        }

    }
}