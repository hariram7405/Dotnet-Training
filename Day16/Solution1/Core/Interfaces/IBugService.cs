using BugTracker.Core.DTOs;

namespace BugTracker.Core.Interfaces
{
    public interface IBugService
    {
        int CreateBug(BugRequestDTO request);
        void UpdateBug(int id, BugRequestDTO request);
        void DeleteBug(int id);
        BugResponseDTO? GetBugById(int id);
        IEnumerable<BugResponseDTO> GetAllBugs();
    }
}
