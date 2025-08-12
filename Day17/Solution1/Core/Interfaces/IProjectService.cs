using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BugTracker.Core.DTOs;


namespace BugTracker.Core.Interfaces
{
  public interface IProjectService
    {
        void CreateProject(ProjectRequestDTO request);
        ProjectResponseDTO? GetProjectById(int id);
        IEnumerable<ProjectResponseDTO> GetAllProjects();

        void UpdateProject(int id, ProjectRequestDTO request);
        void DeleteProject(int id);
    }
}
