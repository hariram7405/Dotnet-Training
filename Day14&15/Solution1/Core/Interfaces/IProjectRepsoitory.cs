using BugTracker.Core.Entities;

namespace BugTracker.Core.Interfaces
{
    public interface IProjectRepository
    {
        Project? GetById(int id);
    }
}
