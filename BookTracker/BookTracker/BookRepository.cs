using SQLite;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using BookTracker.Models;

namespace BookTracker
{
    public class BookRepository
    {
        SQLiteConnection database;

        public BookRepository(string filename)
        {
            string databasePath = DependencyService.Get<ISQLite>().GetDatabasePath(filename);
            database = new SQLiteConnection(databasePath);
            database.CreateTable<Book>();
        }

        public IEnumerable<Book> GetBooks()
        {
            return (from i in database.Table<Book>() select i).ToList();
        }

        public int DeleteBook(int id)
        {
            return database.Delete<Book>(id);
        }

        public int SaveBook(Book item)
        {
            if (item.ID != 0)
            {
                database.Update(item);
                return item.ID;
            }
            else
            {
                return database.Insert(item);
            }
        }
    }
}
