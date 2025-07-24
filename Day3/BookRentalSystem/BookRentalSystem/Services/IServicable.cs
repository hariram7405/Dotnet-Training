using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookRentalSystem.Models; // Add this at the top

namespace BookRentalSystem.Services
{
    public interface IServicable
    {
        public void RentBook(Book book);
        public void ReturnBook(Book book);
        public void DisplayAll(List<Book> books);
        public void Search(List <Book> books,string bookName);
        


    }
}
