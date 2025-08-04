using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BugStatistics.Core.Entities;

namespace BugStatistics.Core.Interface
{
   public interface IBugRepository
    {
        IReadOnlyList<Bug> GetBugs();

    }
}
