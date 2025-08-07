using BugTracker.Core.Entities;
using BugTracker.Core.Interfaces;
using System.Collections.Generic;

namespace BugTracker.Application.Services
{
    public class ProjectService
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public void CreateProject(Project project) => _projectRepository.Add(project);

        public List<Project> GetAllProjects() => _projectRepository.GetAll();
    }
}
