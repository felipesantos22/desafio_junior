using appmedic.Domain.Entities;
using appmedic.Infrastructure.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace appmedic.Controllers;

[Route("api/cep")]
[ApiController]
public class AddressController : ControllerBase
{
    private readonly AddressRepository _addressRepository;

    public AddressController(AddressRepository addressRepository)
    {
        _addressRepository = addressRepository;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var address = await _addressRepository.Index();
        return Ok(address);
    }

    [HttpGet("{cep}")]
    public async Task<IActionResult> ShowAddress(string cep)
    {
        var address = await _addressRepository.ShowAddress(cep);

        if (address == null)
        {
            return BadRequest("Cep invalid");
        }

        return Ok(address);
    }
    
    
    [HttpPost]
    [Authorize(Roles = "manager")]
    public async Task<IActionResult> CreateCep([FromBody] string cep)
    {
        var address = await _addressRepository.ShowAddress(cep);
        if (address == null)
        {
            return BadRequest("Cep invalid");
        }
        var newAddress = await _addressRepository.CreateCep(cep);
        return Ok(newAddress);
    }
}