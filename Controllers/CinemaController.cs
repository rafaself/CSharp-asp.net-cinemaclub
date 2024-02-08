using FirstAPI.Models;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using FirstAPI.Data.Dtos;
using Microsoft.AspNetCore.JsonPatch;
namespace FirstAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class CinemaController : ControllerBase
{

    private CinemaContext _context;
    private IMapper _mapper;


    public CinemaController(CinemaContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// Adiciona um cinema ao banco de dados
    /// </summary>
    /// <param name="cinemaDto">Objeto com os campos necessários para criação de um cinema</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult AdicionaCinema([FromBody] CreateCinemaDto cinemaDto)
    {
        Cinema cinema = _mapper.Map<Cinema>(cinemaDto);
        _context.Cinemas.Add(cinema);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperaCinemaPorID), new { id = cinema.ID }, cinema);
    }

    [HttpPut("{id}")]
    public IActionResult AtualizaCinema(int id, [FromBody] UpdateCinemaDto cinemaDto)
    {
        Cinema? cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.ID == id);
        if (cinema == null) NotFound();
        _mapper.Map(cinemaDto, cinema);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult AtualizaCinemaParcial(int id,
        JsonPatchDocument<UpdateCinemaDto> patch)
    {
        var cinema = _context.Cinemas.FirstOrDefault(
            cinema => cinema.ID == id);
        if (cinema == null) return NotFound();

        var cinemaParaAtualizar = _mapper.Map<UpdateCinemaDto>(cinema);

        patch.ApplyTo(cinemaParaAtualizar, ModelState);

        if (!TryValidateModel(cinemaParaAtualizar))
        {
            return ValidationProblem(ModelState);
        }
        _mapper.Map(cinemaParaAtualizar, cinema);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpGet]
    public IEnumerable<LerCinemaDto> RecuperaCinema([FromQuery] int skip = 0, [FromQuery] int limit = 50)
    {
        return _mapper.Map<List<LerCinemaDto>>(_context.Cinemas.Skip(skip).Take(limit));
    }

    [HttpGet("{id}")]
    public IActionResult RecuperaCinemaPorID(int id)
    {
        Cinema? cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.ID == id);
        if (cinema == null) return NotFound();
        var cinemaDto = _mapper.Map<LerCinemaDto>(cinema);
        return Ok(cinemaDto);
    }

    [HttpDelete("{id}")]
    public IActionResult DeletarCinema(int id)
    {
        Cinema? cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.ID == id);
        if (cinema == null) return NotFound();
        _context.Remove(cinema);
        _context.SaveChanges();
        return NoContent();
    }

}