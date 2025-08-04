using BugDashboardStats.Core.Entities;
using System.Collections.Generic;

namespace BugDashboardStats.Core.Interfaces;

public interface IBugRepository
{
    List<Bug> GetAllBugs();
}
