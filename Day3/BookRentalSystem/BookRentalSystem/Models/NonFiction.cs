using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookRentalSystem.Models; 

namespace BookRentalSystem.Models
{
    public class NonFiction : Book,IRentable
    {
        public string category;
        public NonFiction(int id, string title, string author, string isAvailable, string category)
            : base(id, title, author, isAvailable)
        {
         this.category=category;

        }
        public override void Display()
        {
            Console.WriteLine("-----------Non Fiction----------");
            Console.WriteLine($"Book Id :{id}");
            Console.WriteLine($"Book Title: {title}");
            Console.WriteLine($"Book Author: {author}");
            Console.WriteLine($"Book category:{category}");
            Console.WriteLine();
        }
      
        public void Rent()
        {
            isAvailable="   Not Available";
        }
        public void Return()
        {
            isAvailable = "Available";
        }
        public void ReportStatus()
        {
            Console.WriteLine("*************Report**************");
            Console.WriteLine("Report Generated as on :" + DateTime.Now);
            Console.WriteLine($"Book Id :{id}");
            Console.WriteLine($"Book Title: {title}");
            Console.WriteLine($"Book Author: {author}");
            Console.WriteLine($"Book Category:{category}");
            Console.WriteLine($"Book Status:{isAvailable}");
            Console.WriteLine();
        }

    }
}
