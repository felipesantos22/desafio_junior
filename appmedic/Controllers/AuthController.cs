using appmedic.Domain.Entities;
using appmedic.Infrastructure.Repository;
using appmedic.Services.Token;
using Microsoft.AspNetCore.Mvc;

namespace appmedic.Controllers;


[ApiController]
[Route("api/v1/auth")]
public class AuthController : ControllerBase
{
    private readonly LoginRepository _loginRepository;

    public AuthController(LoginRepository loginRepository)
    {
        _loginRepository = loginRepository;
    }

    [HttpPost]
    public async Task<ActionResult<object>> CreateToken([FromBody] Login login)
    {
        var authEmployee = await _loginRepository.ShowLogin(login.UserName, login.Password);
        if (authEmployee != null)
        {
            var tokenResult = TokenService.GenerateToken(authEmployee);
            return Ok(tokenResult);
        }

        return BadRequest("Employee not found in the database");
    }
}