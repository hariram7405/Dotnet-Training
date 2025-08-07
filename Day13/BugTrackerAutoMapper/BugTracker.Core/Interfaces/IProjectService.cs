using BugTracker.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BugTracker.Core.Entities;

namespace BugTracker.Core.Interfaces
{
    public interface IProjectService
    {
        public void DeleteProject(int id);
        public void UpdateProject(ProjectRequestDTO dto);
        public ProjectRequestDTO? GetProjectById(int id);
        public void AddProject(ProjectRequestDTO dto);
        public void GetAllProjects();
    }
}
