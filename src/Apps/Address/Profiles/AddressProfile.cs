using AutoMapper;
using FirstAPI.Data.Dtos;
using FirstAPI.Models;

namespace FirstAPI.Profiles;

public class AddressProfile : Profile
{
    public AddressProfile() {
        CreateMap<CreateAddressDto, Address>();
        CreateMap<UpdateAddressDto, Address>();
        CreateMap<Address, UpdateAddressDto>();
        CreateMap<Address, ReadAddressDto>();
    }
}