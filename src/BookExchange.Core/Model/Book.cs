using System;

namespace BookExchange.Core.Model
{
    public class Book 
    {
        public Guid Id { get; protected set; }
        public string Title { get; protected set; }
        public string  Author { get; protected set; }
        public string PublishingHouse { get; protected set; }
        public int Year { get; protected set; }

        public Book(Guid id, string title, string author, string publishingHouse, int year)
        {
            Id = id;
            Title = title;
            Author = author;
            PublishingHouse = publishingHouse;
            Year = year;
        }
    }
}