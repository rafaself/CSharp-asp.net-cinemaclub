using AutoMapper;
using FirstAPI.Data;
using FirstAPI.Data.Dtos;
using FirstAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace FirstAPI.Controllers;

public class AddressController : ControllerBase
{

    MovieAppContext _context;
    IMapper _mapper;

    public AddressController(MovieAppContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult CreateAddress([FromBody] CreateAddressDto addressDto)
    {
        Address addressMapped = _mapper.Map<Address>(addressDto);
        _context.Addresses.Add(addressMapped);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpGet]
    public IEnumerable<ReadAddressDto> ListAddresses(int skip = 0, int take = 100)
    {
        var addressesFromDb = _context.Addresses.Skip(skip).Take(take);
        var addressesMapped = _mapper.Map<List<ReadAddressDto>>(addressesFromDb);
        return addressesMapped;
    }

    [HttpGet("{id}")]
    public ReadAddressDto RetrieveAddress(int id)
    {
        var addressFromDb = _context.Addresses.FirstOrDefault(address => address.ID == id);
        var addressMapped = _mapper.Map<ReadAddressDto>(addressFromDb);
        return addressMapped;
    }

    [HttpPut("{id}")]
    public IActionResult UpdateAddress(int id, [FromBody] UpdateCinemaDto cinemaDto)
    {
        var addressesFromDb = _context.Addresses.FirstOrDefault(address => address.ID == id);
        if (addressesFromDb == null) return NotFound();

        var addressMapped = _mapper.Map<UpdateAddressDto>(addressesFromDb);
        _mapper.Map(cinemaDto, addressesFromDb);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult UpdateAddressPartially(int id, [FromBody] JsonPatchDocument<UpdateAddressDto> patch)
    {
        var addressFromDb = _context.Addresses.FirstOrDefault(address => address.ID == id);
        if (addressFromDb == null) return NotFound();

        var addressMapped = _mapper.Map<UpdateAddressDto>(addressFromDb);
        patch.ApplyTo(addressMapped, ModelState);

        if (!TryValidateModel(addressMapped))
        {
            return ValidationProblem(ModelState);
        }

        _mapper.Map(addressMapped, addressFromDb);
        _context.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteAddress(int id)
    {
        var addressFromDb = _context.Addresses.FirstOrDefault(address => address.ID == id);
        if (addressFromDb == null) return NoContent();

        _context.Remove(addressFromDb);
        _context.SaveChanges();

        return NoContent();
    }

}