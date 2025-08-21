using HostelManagement.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostelManagement.Core.Interfaces
{
    public interface IStudentService
    {
        Task<StudentResponseDTO> AddStudent(StudentRequestDTO request);
        Task<StudentResponseDTO> GetStudentById(int id);
        Task<StudentResponseDTO> UpdateStudent(StudentRequestDTO request, int id);
        Task DeleteStudent(int id);
        Task<IEnumerable<StudentResponseDTO>> GetAllStudent();
    }
}
