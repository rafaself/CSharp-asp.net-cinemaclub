using AutoMapper;
using FirstApi.Models;
using FirstAPI.Data;
using FirstAPI.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class SessionController : ControllerBase
{

    IMapper _mapper;
    MovieAppContext _context;

    public SessionController(IMapper mapper, MovieAppContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    [HttpPost]
    public IActionResult CreateSession([FromBody] CreateSessionDto session)
    {
        Session sessionMapped = _mapper.Map<Session>(session);
        _context.Sessions.Add(sessionMapped);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpGet]
    public IActionResult ListSessions(
        [FromQuery] int movieID, 
        [FromQuery] int cinemaID,
        [FromQuery] int skip = 0, 
        [FromQuery] int limit = 50 
        )
    {
        if (movieID != 0 && cinemaID != 0) {
            var sessionDb = _context.Sessions.FirstOrDefault(session => session.MovieID == movieID && session.CinemaID == cinemaID);
            var sessionMapped = _mapper.Map<ReadSessionDto>(sessionDb);
            return Ok(sessionMapped);
        } else {
            var sessionsDb = _context.Sessions.Skip(skip).Take(limit);
            var sessionsMapped = _mapper.Map<List<ReadSessionDto>>(sessionsDb);
            return Ok(sessionsMapped);
        }
    }

    [HttpDelete]
    public IActionResult DeleteSession([FromQuery] int movieID, [FromQuery] int cinemaID)
    {
        var sessionDB = _context.Sessions.FirstOrDefault(session => session.MovieID == movieID && session.CinemaID == cinemaID);
        if (sessionDB == null) return NotFound();
        _context.Sessions.Remove(sessionDB);
        _context.SaveChanges();
        return Ok("sessão deletada com sucesso!");
    }
}