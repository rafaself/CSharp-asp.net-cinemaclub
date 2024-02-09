using AutoMapper;
using FirstAPI.Data;
using Microsoft.AspNetCore.Mvc;

namespace FirstAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class CinemaController : ControllerBase
{
    private MovieAppContext _context;
    private IMapper _mapper;

    public CinemaController(MovieAppContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public void ListCinemas([FromQuery] int skip, [FromQuery] int limit){
        var movies = _context.Movies.Skip(skip).Take(limit);
    }

}