using AutoMapper;
using Domain.Entity;
using Domain.Response;
using Services.Shared.Extensions;

namespace Services.AutoMapper
{
    public class MappingProfile :  Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerResponse>();
            CreateMap<PagedList<Customer>, PagedList<CustomerResponse>>();

            CreateMap<Product, ProductResponse>();
            CreateMap<Product, ProductResponse>();
            CreateMap<PagedList<Product>, PagedList<ProductResponse>>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));

            CreateMap<Order, OrderResponse>()
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer.Name))
                .ForMember(dest => dest.OrderDate, opt => opt.MapFrom(src => src.OrderDate.ToBrazilTime()));

            CreateMap<OrderResponse, DefaultApiResponse<OrderResponse>>()
                .ForMember(dest => dest.Success, opt => opt.MapFrom(src => true))
                .ForMember(dest => dest.Message, opt => opt.MapFrom(src => string.Empty)) 
                .ForMember(dest => dest.Errors, opt => opt.MapFrom(src => new List<string>()));
        }       
    }
}