using appmedic.Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;

namespace appmedic.Controllers;

[Route("api/cep")]
[ApiController]
public class ViaCepController : ControllerBase
{
    private readonly ViaCepRepository _viaCepRepository;

    public ViaCepController(ViaCepRepository viaCepRepository)
    {
        _viaCepRepository = viaCepRepository;
    }

    [HttpGet("{cep}")]
    public async Task<IActionResult> ShowAddress(string cep)
    {
        var address = await _viaCepRepository.ShowAddress(cep);

        if (address == null)
        {
            return BadRequest("Cep invalid");
        }

        return Ok(address);
    }
}