using System;

namespace BookExchange.Core.Model
{
    public class Division
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        
        public Division(Guid id, string title)
        {
            Id = id;
            Title = title;
        }
    }
}