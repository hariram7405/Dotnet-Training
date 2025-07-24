using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookRentalSystem.Models; 

namespace BookRentalSystem.Models
{
    public interface IRentable
    {
       public void Rent();
       public void Return();
       public  void ReportStatus();
    }
}
