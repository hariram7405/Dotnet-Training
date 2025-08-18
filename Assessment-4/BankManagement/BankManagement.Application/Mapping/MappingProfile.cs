using AutoMapper;
using BankManagement.Core.DTOs;
using BankManagement.Core.Entities;

namespace BankManagement.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerResponseDTO>();
            CreateMap<CustomerRequestDTO, Customer>();

            CreateMap<Account, AccountResponseDTO>();
            CreateMap<AccountRequestDTO, Account>()
                .ForMember(dest => dest.Balance, opt => opt.MapFrom(src => src.InitialBalance));

            CreateMap<Transaction, TransactionResponseDTO>();
            CreateMap<TransactionRequestDTO, Transaction>();
        }
    }
}