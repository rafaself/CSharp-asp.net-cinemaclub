using FirstAPI.Data;
using FirstAPI.Models;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using FirstAPI.Data.Dtos;
using Microsoft.AspNetCore.JsonPatch;
namespace FirstAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{

    private FilmeContext _context;
    private IMapper _mapper;

    public FilmeController(FilmeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// Adiciona um filme ao banco de dados
    /// </summary>
    /// <param name="filmeDto">Objeto com os campos necessários para criação de um filme</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult AdicionaFilme([FromBody] CreateFilmeDto filmeDto)
    {
        Filme filme = _mapper.Map<Filme>(filmeDto);
        _context.Filmes.Add(filme);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperaFilmePorID), new { id = filme.ID }, filme);
    }

    [HttpPut("{id}")]
    public IActionResult AtualizaFilme(int id, [FromBody] UpdateFilmeDto filmeDto)
    {
        Filme? filme = _context.Filmes.FirstOrDefault(filme => filme.ID == id);
        if (filme == null) NotFound();
        _mapper.Map(filmeDto, filme);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult AtualizaFilmeParcial(int id,
        JsonPatchDocument<UpdateFilmeDto> patch)
    {
        var filme = _context.Filmes.FirstOrDefault(
            filme => filme.ID == id);
        if (filme == null) return NotFound();

        var filmeParaAtualizar = _mapper.Map<UpdateFilmeDto>(filme);

        patch.ApplyTo(filmeParaAtualizar, ModelState);

        if (!TryValidateModel(filmeParaAtualizar))
        {
            return ValidationProblem(ModelState);
        }
        _mapper.Map(filmeParaAtualizar, filme);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpGet]
    public IEnumerable<LerFilmeDto> RecuperaFilme([FromQuery] int skip = 0, [FromQuery] int limit = 50)
    {
        return _mapper.Map<List<LerFilmeDto>>(_context.Filmes.Skip(skip).Take(limit));
    }

    [HttpGet("{id}")]
    public IActionResult RecuperaFilmePorID(int id)
    {
        Filme? filme = _context.Filmes.FirstOrDefault(filme => filme.ID == id);
        if (filme == null) return NotFound();
        var filmeDto = _mapper.Map<LerFilmeDto>(filme);
        return Ok(filmeDto);
    }

    [HttpDelete("{id}")]
    public IActionResult DeletarFilme(int id)
    {
        Filme? filme = _context.Filmes.FirstOrDefault(filme => filme.ID == id);
        if (filme == null) return NotFound();
        _context.Remove(filme);
        _context.SaveChanges();
        return NoContent();
    }

}