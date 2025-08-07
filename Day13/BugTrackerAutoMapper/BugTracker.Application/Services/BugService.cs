using AutoMapper;
using BugTracker.Core.DTOs;
using BugTracker.Core.Entities;
using BugTracker.Core.Interfaces;


namespace BugTracker.Application.Services
{
    public class BugService:IBugService
    {
        private readonly IBugRepository _bugRepository;
        private readonly IMapper _mapper;

        public BugService(IBugRepository bugRepository, IMapper mapper)
        {
            _bugRepository = bugRepository;
            _mapper = mapper;
        }

        public void AddBug(BugRequestDTO dto)
        {
            var bug = _mapper.Map<Bug>(dto);
            _bugRepository.Add(bug);
        }

        public void GetAllBugs()
        {
            var bugs = _bugRepository.GetAll();
            var dtos = _mapper.Map<List<BugResponseDTO>>(bugs);
            foreach (var b in dtos)
            {
                Console.WriteLine($"Id: {b.Id}, Title: {b.Title}, Status: {b.Status}, DueDate: {b.DueDate}");
            }
        }

        public BugRequestDTO? GetBugById(int id)
        {
            var bug = _bugRepository.GetById(id);
            return bug != null ? _mapper.Map<BugRequestDTO>(bug) : null;
        }

        public void UpdateBug(BugRequestDTO dto)
        {
            var bug = _mapper.Map<Bug>(dto);
            _bugRepository.Update(bug);
        }

        public void DeleteBug(int id)
        {
            _bugRepository.Delete(id);
        }
    }
}
