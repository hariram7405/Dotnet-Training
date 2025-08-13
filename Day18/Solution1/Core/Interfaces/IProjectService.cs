using BugTracker.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BugTracker.Core.Interfaces
{
    public interface IProjectService
    {
        // Sync
        void CreateProject(ProjectRequestDTO request);
        ProjectResponseDTO? GetProjectById(int id);
        IEnumerable<ProjectResponseDTO> GetAllProjects();
        void UpdateProject(int id, ProjectRequestDTO request);
        void DeleteProject(int id);

        // Async
        Task CreateProjectAsync(ProjectRequestDTO request);
        Task<ProjectResponseDTO?> GetProjectByIdAsync(int id);
        Task<IEnumerable<ProjectResponseDTO>> GetAllProjectsAsync();
        Task UpdateProjectAsync(int id, ProjectRequestDTO request);
        Task DeleteProjectAsync(int id);
    }
}
