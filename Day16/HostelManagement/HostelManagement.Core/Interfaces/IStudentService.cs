using HostelManagement.Core.DTOs;

namespace HostelManagement.Core.Interfaces
{
    public interface IStudentService
    {
        StudentResponseDTO Create(StudentRequestDTO request);
        IEnumerable<StudentResponseDTO> GetAll();
        StudentResponseDTO? GetById(int id);
    }
}
