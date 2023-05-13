using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using SQLite;
using BookTracker.Models;
using System.ComponentModel;
using System;

namespace BookTracker
{
    public class BooksViewModel : INotifyPropertyChanged
    {
        BookRepository db;
        public ObservableCollection<Book> Books { get; set; }
        public Command AddBookCommand { get; set; }

        public BooksViewModel()
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "BooksDB.db3");
            db = new BookRepository(dbPath);
            Books = new ObservableCollection<Book>(db.GetBooks());
            AddBookCommand = new Command(AddBook);
        }


        void AddBook()
        {
            var book = new Book() { Title = "New book", Author = "Unknown", DateRead = DateTime.Now };
            db.SaveBook(book);
            Books.Add(book);
        }

        // Реализуйте INotifyPropertyChanged для обновления UI при изменении данных
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
