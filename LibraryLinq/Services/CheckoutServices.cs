using LibraryLinq.DataContext;
using LibraryLinq.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryLinq.Services
{
    public class CheckoutServices
    {
        public LibraryContext Database = new LibraryContext();

        public List<Book> GetCheckedOutBooks()
        {
            return Database.Books
                .Where(w => w.IsCheckedout == true)
                .Select(s => new Book { ID = s.ID, Title = s.Title, DueBackDate = s.DueBackDate })
                .ToList<Book>();
        }

        public List<Book> GetAvailableBooks()
        {
            return Database.Books.Where(w => w.IsCheckedout == false).ToList();
        }

        public void CheckOutBook(int id)
        {
            Book editBook = Database.Books.First(w => w.ID == id);
            editBook.IsCheckedout = true;
            editBook.DueBackDate = DateTime.Now.AddDays(10);
            Database.SaveChanges();        
        }
    }
}