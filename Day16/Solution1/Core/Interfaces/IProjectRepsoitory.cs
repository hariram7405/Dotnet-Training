using BugTracker.Core.Entities;
using System.Collections.Generic;

namespace BugTracker.Core.Interfaces
{
    public interface IProjectRepository
    {
        void Add(Project project);
        Project GetById(int id);
        IEnumerable<Project> GetAll();
    }
}
