using AutoMapper;
using FirstAPI.Data.Dtos;
using FirstAPI.Models;

namespace FirstAPI.Profiles;

public class FilmeProfile : Profile
{
    public FilmeProfile()
    {
        CreateMap<CreateFilmeDto, Filme>();
        CreateMap<UpdateFilmeDto, Filme>();
        CreateMap<Filme, UpdateFilmeDto>();
        CreateMap<Filme, LerFilmeDto>();
    }
}

