using AutoMapper;
using EmployeeMapper.Core.DTOs;
using EmployeeMapper.Core.Entities;
using EmployeeMapper.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeMapper.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public void AddEmployee(EmployeeRequestDTO dto)
        {
            var employee = _mapper.Map<Employee>(dto);
            _repository.Add(employee);
        }

     
        public void UpdateEmployee(EmployeeRequestDTO dto)
        {
            var employee = _mapper.Map<Employee>(dto);
            _repository.Update(employee);
        }

        public void DeleteEmployee(int id) => _repository.Delete(id);

        public IEnumerable<EmployeeResponseDTO> GetAllEmployees()
        {
            var employees = (_repository as EmployeeMapper.Infrastructure.Repositories.EmployeeRepository)?.GetAll() ?? new List<Employee>();
            return _mapper.Map<IEnumerable<EmployeeResponseDTO>>(employees);
        }

        public IEnumerable<EmployeeResponseDTO> GetEmployeesByDepartment(int departmentId)
        {
            var entities = _repository.GetEmployeesByDepartment(departmentId);
            return _mapper.Map<IEnumerable<EmployeeResponseDTO>>(entities);
        }

        public int GetEmployeeCount() => _repository.Counts();

        public void DisplayEmployee() => _repository.Display();

        public bool Exists(int id) => _repository.GetById(id) != null ? true : false;
    }
}
