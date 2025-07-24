using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRentalSystem.Models
{
   public class Book
    {
        public int id { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public string isAvailable { get; set; }
        public Book (int id,string title,string author,string isAvailable)
        {
            this.id = id;
            this.title = title;
            this.author = author;
            this.isAvailable= isAvailable;
        }
        public virtual void Display()
        {
            Console.WriteLine($"Book Id :{id}");
            Console.WriteLine($"Book Title: {title}");
            Console.WriteLine($"Book Author: {author}");
            Console.WriteLine($"Book Status:{isAvailable}");
        }
    }
}
