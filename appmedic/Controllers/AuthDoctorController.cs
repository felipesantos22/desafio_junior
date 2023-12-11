using appmedic.Domain.Entities;
using appmedic.Infrastructure.Repository;
using appmedic.Services.Token;
using Microsoft.AspNetCore.Mvc;

namespace appmedic.Controllers;


[ApiController]
[Route("api/v1/auth")]
public class AuthDoctorController : ControllerBase
{
    private readonly DoctorRepository _doctorRepository;

    public AuthDoctorController(DoctorRepository doctorRepository)
    {
        _doctorRepository = doctorRepository;
    }

    [HttpPost]
    public async Task<ActionResult<object>> CreateToken([FromBody] Doctor doctor)
    {
        var authEmployee = await _doctorRepository.ShowDoctor(doctor.Name, doctor.CRM);
        if (authEmployee != null)
        {
            var tokenResult = TokenService.GenerateToken(authEmployee);
            return Ok(tokenResult);
        }

        return BadRequest("Employee not found in the database");
    }
}