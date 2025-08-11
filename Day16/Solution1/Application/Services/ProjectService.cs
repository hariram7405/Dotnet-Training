using BugTracker.Core.DTOs;
using BugTracker.Core.Entities;
using BugTracker.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BugTracker.Core.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public void CreateProject(ProjectRequestDTO request)
        {
            var project = new Project
            {
                Name = request.Name,
                Description = request.Description
            };

            _projectRepository.Add(project);
        }

        public ProjectResponseDTO? GetProjectById(int id)
        {
            var project = _projectRepository.GetById(id);
            if (project == null)
            {
                return null;
            }

            return new ProjectResponseDTO
            {
                Id = project.Id,
                Name = project.Name,
                Description = project.Description
            };
        }


        public IEnumerable<ProjectResponseDTO> GetAllProjects()
        {
            // Assuming this method name is wrong (GetAllBugs in ProjectService), but sticking to your interface
            return _projectRepository.GetAll().Select(p => new ProjectResponseDTO
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description
            });
        }
    }
}
