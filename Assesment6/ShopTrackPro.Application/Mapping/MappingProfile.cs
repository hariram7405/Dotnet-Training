using AutoMapper;
using ShopTrackPro.Core.Entities;
using ShopTrackPro.Core.DTOs.Product;
using ShopTrackPro.Core.DTOs.User;
using ShopTrackPro.Core.DTOs.Order;
using ShopTrackPro.Core.DTOs.Dashboard;

namespace ShopTrackPro.Application.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Product mappings
        CreateMap<Product, ProductDto>();
        CreateMap<CreateProductDto, Product>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.OrderItems, opt => opt.Ignore());
        CreateMap<UpdateProductDto, Product>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.OrderItems, opt => opt.Ignore());

        // User mappings
        CreateMap<User, UserDto>();

        // Order mappings
        CreateMap<Order, OrderDto>()
            .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.OrderItems))
            .ForMember(dest => dest.TotalAmount, opt => opt.MapFrom(src => 
                src.OrderItems.Sum(oi => oi.Quantity * (oi.Product != null ? oi.Product.Price : 0))));
        
        CreateMap<OrderItem, OrderItemDto>()
            .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Product.Price));

        // Dashboard mappings
        CreateMap<Product, ProductSalesDto>()
            .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.TotalSold, opt => opt.Ignore())
            .ForMember(dest => dest.TotalRevenue, opt => opt.Ignore());
    }
}
