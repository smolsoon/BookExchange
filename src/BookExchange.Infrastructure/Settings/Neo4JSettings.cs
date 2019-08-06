using System;

namespace BookExchange.Infrastructure.Settings
{
    public class Neo4JSettings
    {
        public Uri Uri { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
    }
}