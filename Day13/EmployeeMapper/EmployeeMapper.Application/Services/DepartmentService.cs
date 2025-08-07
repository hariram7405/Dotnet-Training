using AutoMapper;
using EmployeeMapper.Core.DTOs;
using EmployeeMapper.Core.Entities;
using EmployeeMapper.Core.Interfaces;

namespace EmployeeMapper.Application.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;

        public DepartmentService(IDepartmentRepository departmentRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }

        public void AddDepartment(DepartmentRequestDTO dto)
        {
            var department = _mapper.Map<Department>(dto);
            _departmentRepository.Add(department);
        }

        public void DeleteDepartment(int id) => _departmentRepository.Delete(id);

        public void UpdateDepartment(DepartmentRequestDTO dto)
        {
            var entity = _mapper.Map<Department>(dto);
            _departmentRepository.Update(entity);
        }

        public Department? GetDepartmentById(int id) => _departmentRepository.GetById(id);

        public int GetDepartmentCount() => _departmentRepository.Counts();

        public void DisplayDepartment() => _departmentRepository.Display();

        public bool Exists(int id) => GetDepartmentById(id) != null ? true : false;
    }
}
