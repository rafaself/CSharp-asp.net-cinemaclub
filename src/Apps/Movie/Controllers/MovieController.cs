using FirstAPI.Data;
using FirstAPI.Models;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using FirstAPI.Data.Dtos;
using Microsoft.AspNetCore.JsonPatch;
namespace FirstAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class MovieController : ControllerBase
{

    private MovieAppContext _context;
    private IMapper _mapper;


    public MovieController(MovieAppContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// Create um movie ao banco de dados
    /// </summary>
    /// <param name="movieDto">Objeto com os campos necessários para criação de um movie</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult CreateMovie([FromBody] CreateMovieDto movieDto)
    {
        try
        {

            Movie movie = _mapper.Map<Movie>(movieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RetrieveMovieByID), new { id = movie.ID }, movie);
        }
        catch (Exception exc)
        {
            Console.WriteLine(exc);
            return NoContent();
        }
    }

    [HttpPut("{id}")]
    public IActionResult UpdateMovie(int id, [FromBody] UpdateMovieDto movieDto)
    {
        Movie? movie = _context.Movies.FirstOrDefault(movie => movie.ID == id);
        if (movie == null) NotFound();
        _mapper.Map(movieDto, movie);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult UpdateMoviePartially(int id,
        JsonPatchDocument<UpdateMovieDto> patch)
    {
        var movie = _context.Movies.FirstOrDefault(
            movie => movie.ID == id);
        if (movie == null) return NotFound();

        var movieToUpdate = _mapper.Map<UpdateMovieDto>(movie);

        patch.ApplyTo(movieToUpdate, ModelState);

        if (!TryValidateModel(movieToUpdate))
        {
            return ValidationProblem(ModelState);
        }
        _mapper.Map(movieToUpdate, movie);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpGet]
    public IEnumerable<ReadMovieDto> ListMovie([FromQuery] int skip = 0, [FromQuery] int limit = 50)
    {
        return _mapper.Map<List<ReadMovieDto>>(_context.Movies.Skip(skip).Take(limit));
    }

    [HttpGet("{id}")]
    public IActionResult RetrieveMovieByID(int id)
    {
        Movie? movie = _context.Movies.FirstOrDefault(movie => movie.ID == id);
        if (movie == null) return NotFound();
        var movieDto = _mapper.Map<ReadMovieDto>(movie);
        return Ok(movieDto);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteMovie(int id)
    {
        Movie? movie = _context.Movies.FirstOrDefault(movie => movie.ID == id);
        if (movie == null) return NotFound();
        _context.Remove(movie);
        _context.SaveChanges();
        return NoContent();
    }

}