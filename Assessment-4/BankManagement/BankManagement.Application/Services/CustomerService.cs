using AutoMapper;
using BankManagement.Core.DTOs;
using BankManagement.Core.Entities;
using BankManagement.Core.Interfaces;

namespace BankManagement.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<CustomerResponseDTO> CreateCustomerAsync(CustomerRequestDTO request)
        {
            var existingCustomer = await _customerRepository.GetByEmailAsync(request.Email);
            if (existingCustomer != null)
                throw new InvalidOperationException("Customer with this email already exists");

            var customer = _mapper.Map<Customer>(request);
            var createdCustomer = await _customerRepository.AddAsync(customer);
            return _mapper.Map<CustomerResponseDTO>(createdCustomer);
        }

        public async Task<CustomerResponseDTO?> GetCustomerByIdAsync(string id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);
            return customer != null ? _mapper.Map<CustomerResponseDTO>(customer) : null;
        }

        public async Task<IEnumerable<CustomerResponseDTO>> GetAllCustomersAsync()
        {
            var customers = await _customerRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CustomerResponseDTO>>(customers);
        }

        public async Task<CustomerResponseDTO> UpdateCustomerAsync(string id, CustomerRequestDTO request)
        {
            var existingCustomer = await _customerRepository.GetByIdAsync(id);
            if (existingCustomer == null)
                throw new ArgumentException("Customer not found");

            _mapper.Map(request, existingCustomer);
            var updatedCustomer = await _customerRepository.UpdateAsync(existingCustomer);
            return _mapper.Map<CustomerResponseDTO>(updatedCustomer);
        }

        public async Task<bool> DeleteCustomerAsync(string id)
        {
            return await _customerRepository.DeleteAsync(id);
        }
    }
}
