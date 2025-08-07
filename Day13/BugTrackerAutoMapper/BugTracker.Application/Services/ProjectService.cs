using AutoMapper;
using BugTracker.Core.DTOs;
using BugTracker.Core.Entities;
using BugTracker.Core.Interfaces;




namespace BugTracker.Application.Services
{
    public class ProjectService:IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IMapper _mapper;

        public ProjectService(IProjectRepository projectRepository, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
        }

        public void AddProject(ProjectRequestDTO dto)
        {
            var proj = _mapper.Map<Project>(dto);
            _projectRepository.Add(proj);
        }

        public void GetAllProjects()
        {
            var projs = _projectRepository.GetAll();
            var dtos = _mapper.Map<List<ProjectResponseDTO>>(projs);
            foreach (var p in dtos)
            {
                Console.WriteLine($"Id: {p.Id}, Name: {p.Name}, Description: {p.Description}, StartDate: {p.StartDate}");
            }
        }

        public ProjectRequestDTO? GetProjectById(int id)
        {
            var proj = _projectRepository.GetById(id);
            return proj != null ? _mapper.Map<ProjectRequestDTO>(proj) : null;
        }

        public void UpdateProject(ProjectRequestDTO dto)
        {
            var proj = _mapper.Map<Project>(dto);
            _projectRepository.Update(proj);
        }

        public void DeleteProject(int id)
        {
            _projectRepository.Delete(id);
        }
    }
}

