using appmedic.Domain.Entities;
using appmedic.Infrastructure.Repository;
using appmedic.Services.Token;
using Microsoft.AspNetCore.Mvc;

namespace appmedic.Controllers;


[ApiController]
[Route("api/v1/auth")]
public class AuthController : ControllerBase
{
    private readonly UserRepository _userRepository;

    public AuthController(UserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpPost]
    public async Task<ActionResult<object>> CreateToken([FromBody] User user)
    {
        var authEmployee = await _userRepository.ShowLogin(user.UserName, user.Password);
        if (authEmployee != null)
        {
            var tokenResult = TokenService.GenerateToken(authEmployee);
            return Ok(tokenResult);
        }

        return BadRequest("Employee not found in the database");
    }
}