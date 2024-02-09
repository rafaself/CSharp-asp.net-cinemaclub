using AutoMapper;
using FirstApi.Models;
using FirstAPI.Data;
using FirstAPI.Data.Dtos;
using FirstAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MySqlConnector;

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

    [HttpPost]
    public IActionResult CreateCinema([FromBody] CreateCinemaDto cinemaDto)
    {
        try
        {

            Cinema cinema = _mapper.Map<Cinema>(cinemaDto);
            _context.Cinemas.Add(cinema);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RetrieveCinemaByID), new { id = cinema.ID }, cinema);
        }
        catch (Exception exc) {
            Console.WriteLine(exc.ToString());
            return BadRequest(new { message = "Ocorreu um erro ao criar o cinema." });
        }
    }

    [HttpGet]
    public IEnumerable<ReadCinemaDto> ListCinemas([FromQuery] int skip = 0, [FromQuery] int limit = 50)
    {
        var cinemasFromDb = _context.Cinemas.Skip(skip).Take(limit).ToList();
        var cinemasMapped = _mapper.Map<List<ReadCinemaDto>>(cinemasFromDb);
        return cinemasMapped;
    }

    [HttpGet("{id}")]
    public IActionResult RetrieveCinemaByID(int id)
    {
        var cinemaFromDb = _context.Cinemas.FirstOrDefault(cinema => cinema.ID == id);
        if (cinemaFromDb == null) return NotFound();
        var cinemasMapped = _mapper.Map<ReadCinemaDto>(cinemaFromDb);
        return Ok(cinemasMapped);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateCinema(int id, [FromBody] UpdateCinemaDto cinemaDto)
    {
        var cinemaFromDb = _context.Cinemas.FirstOrDefault(cinema => cinema.ID == id);
        if (cinemaFromDb == null) return NotFound();
        _mapper.Map(cinemaDto, cinemaFromDb);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult UpdateCinemaPartially(int id, JsonPatchDocument<UpdateCinemaDto> patch)
    {
        var cinemaFromDb = _context.Cinemas.FirstOrDefault(cinema => cinema.ID == id);
        if (cinemaFromDb == null) return NotFound();

        var cinemaMapped = _mapper.Map<UpdateCinemaDto>(cinemaFromDb);
        patch.ApplyTo(cinemaMapped, ModelState);

        if (!TryValidateModel(cinemaMapped))
        {
            return ValidationProblem(ModelState);
        }

        _mapper.Map(cinemaMapped, cinemaFromDb);
        _context.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteCinema(int id)
    {
        var cinemaFromDb = _context.Cinemas.FirstOrDefault(cinema => cinema.ID == id);
        if (cinemaFromDb == null) return NotFound();
        _context.Remove(cinemaFromDb);
        _context.SaveChanges();
        return NoContent();
    }

}