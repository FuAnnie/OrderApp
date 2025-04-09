using API.ViewModels;
using ApplicationCore.Entities;
using AutoMapper;

namespace API.Mappings;

public class OrderMapping: Profile
{
    public OrderMapping()
    {
        CreateMap<Order, OrderRequestModel>().ReverseMap();
        CreateMap<Order, OrderResponseModel>().ReverseMap();
    }
}