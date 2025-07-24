using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookRentalSystem.Models; 


namespace BookRentalSystem.Services
{
    public class BookServices : IServicable
    {
        public void RentBook(Book book)
        {
            Console.WriteLine($"{book.title} has been Rented");
        }
        public void ReturnBook(Book book)
        {
            Console.WriteLine($"{book.title} has been Returned");
        }

        public void DisplayAll(List<Book> books)
        {
            int cnt = 0;

            foreach (Book x in  books)
            {
            cnt++;
             Console.WriteLine($"Book {cnt}");
            Console.WriteLine($"Book Id:{x.id}");
            Console.WriteLine($"Book Title:{x.title}");
            Console.WriteLine($"Book Author:{x.author}");
            Console.WriteLine();

        }
        if(cnt==0){
        Console.WriteLine("No Book is Available Write Now! Please Check after some time");
    }
else
{
    Console.WriteLine($"Total Number of Book Available:{cnt }");
}
}
public void Search(List<Book> book, String bookName)
{
    int cnt = 0;
    foreach (Book x in book){
    if(x.title.Equals(bookName)){
    Console.WriteLine($"{bookName}Book is Available");
cnt = 1;
break;
}

}
if (cnt == 0)
{
    Console.WriteLine($"{bookName} book is not Available");
}
}
}

}
