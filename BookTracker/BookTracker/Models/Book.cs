using SQLite;
using System;

namespace BookTracker.Models
{
    public class Book
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime DateRead { get; set; }
    }
}
