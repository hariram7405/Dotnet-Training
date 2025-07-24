using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookRentalSystem.Models; 

namespace BookRentalSystem.Models
{
   public class Fiction:Book,IRentable
    {
        public string genre;
        public Fiction(int id, string title, string author, string isAvailable,string genre)
            :base(id,  title, author,  isAvailable)
        {
             this.genre=genre;

        }
        public override void Display()
        {
            Console.WriteLine("-----------Fiction----------");
            Console.WriteLine($"Book Id :{id}");
            Console.WriteLine($"Book Title: {title}");
            Console.WriteLine($"Book Author: {author}");
            Console.WriteLine($"Book Genre:{genre}");
            Console.WriteLine();
        }
          
        public void Rent()
        {
            isAvailable="Not Available";
        }
        public void Return()
        {
            isAvailable="Available";
        }
        public void ReportStatus()
        {
            Console.WriteLine("*************Report**************");
            Console.WriteLine("Report Generated as on :" + DateTime.Now);
            Console.WriteLine($"Book Id :{id}");
            Console.WriteLine($"Book Title: {title}");
            Console.WriteLine($"Book Author: {author}");
            Console.WriteLine($"Book Genre:{genre}");
            Console.WriteLine($"Book Status:{isAvailable}");
            Console.WriteLine();
        }
    }
}
