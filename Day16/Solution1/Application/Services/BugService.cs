using BugTracker.Core.DTOs;
using BugTracker.Core.Entities;
using BugTracker.Core.Interfaces;

namespace BugTracker.Core.Services
{
    public class BugService : IBugService
    {
        private readonly IBugRepository _bugRepository;

        public BugService(IBugRepository bugRepository)
        {
            _bugRepository = bugRepository;
        }

        public int CreateBug(BugRequestDTO request)
        {
            var bug = new Bug
            {
                Title = request.Title,
                Description = request.Description,
                Status = request.Status,
                ProjectId = request.ProjectId
            };

            _bugRepository.Add(bug);
            return bug.Id;
        }

        public void UpdateBug(int id, BugRequestDTO request)
        {
            var bug = _bugRepository.GetById(id);
            if (bug == null)
                throw new Exception("Bug not found.");

            bug.Title = request.Title;
            bug.Description = request.Description;
            bug.Status = request.Status;
            bug.ProjectId = request.ProjectId;

            _bugRepository.Update(bug);
        }

        public void DeleteBug(int id)
        {
            _bugRepository.Delete(id);
        }

        public BugResponseDTO? GetBugById(int id)
        {
            var bug = _bugRepository.GetById(id);
            return bug == null ? null : MapToResponseDTO(bug);
        }

        public IEnumerable<BugResponseDTO> GetAllBugs()
        {
            return _bugRepository.GetAll().Select(MapToResponseDTO);
        }

        private BugResponseDTO MapToResponseDTO(Bug bug)
        {
            return new BugResponseDTO
            {
                Id = bug.Id,
                Title = bug.Title,
                Description = bug.Description,
                Status = bug.Status,
                CreatedOn = bug.CreatedOn,
                ProjectId = bug.ProjectId
            };
        }
    }
}
