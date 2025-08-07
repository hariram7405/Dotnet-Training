using BugTracker.Core.DTOs;
using BugTracker.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Core.Interfaces
{
public  interface IBugService
    {
        public void DeleteBug(int id);
        public void UpdateBug(BugRequestDTO dto);
        public void AddBug(BugRequestDTO dto);
        public BugRequestDTO? GetBugById(int id);
        public void GetAllBugs();
    }
}
