using AutoMapper;
using FirstApi.Models;
using FirstAPI.Data.Dtos;

namespace FirstAPI.Profiles;

public class CinemaProfile : Profile
{
    public CinemaProfile()
    {
        CreateMap<CreateCinemaDto, Cinema>();
        CreateMap<UpdateCinemaDto, Cinema>();
        CreateMap<Cinema, UpdateCinemaDto>();
        CreateMap<Cinema, ReadCinemaDto>()
            .ForMember(
                cinemaDto => cinemaDto.Address, 
                opt => opt.MapFrom(cinema => cinema.Address)
            );
    }
}