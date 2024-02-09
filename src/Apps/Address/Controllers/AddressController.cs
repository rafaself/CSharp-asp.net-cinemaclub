using AutoMapper;
using FirstAPI.Data;
using FirstAPI.Data.Dtos;
using FirstAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Pomelo.EntityFrameworkCore.MySql.Query.Internal;

namespace FirstAPI.Controllers;

public class AddressController : ControllerBase {

    MovieAppContext _context ;
    IMapper _mapper;

    public AddressController(MovieAppContext context, IMapper mapper) {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult CreateAddress([FromBody] CreateAddressDto addressDto) {
        Address addressMapped = _mapper.Map<Address>(addressDto);
        _context.Addresses.Add(addressMapped);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpGet]
    public IEnumerable<ReadAddressDto> ListAddresses(int skip = 0, int take = 100) {
        var addressesFromDb = _context.Addresses.Skip(skip).Take(take);
        var addressesMapped = _mapper.Map<List<ReadAddressDto>>(addressesFromDb);
        return addressesMapped;
    }





}