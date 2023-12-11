using appmedic.Domain.Entities;
using appmedic.Infrastructure.Repository;
using appmedic.Services.Validations;
using Microsoft.AspNetCore.Mvc;

namespace appmedic.Controllers;

[ApiController]
[Route("api/login")]
public class LoginController : ControllerBase
{
    private readonly LoginRepository _loginRepository;
    private readonly ValidateUserName _validateUserName;

    public LoginController(LoginRepository loginRepository, ValidateUserName validateUserName)
    {
        _loginRepository = loginRepository;
        _validateUserName = validateUserName;
    }


    [HttpPost]
    public async Task<ActionResult<Login>> Create([FromBody] Login login)
    {
        var userName = _validateUserName.UserNameExists(login.UserName);
        if (userName)
        {
            return BadRequest(new {message = "UserName already registered." });
        }
        var newLogin = await _loginRepository.Create(login);
        return Ok(newLogin);
    }


    [HttpGet]
    public async Task<ActionResult<List<Login>>> Index()
    {
        var logins = await _loginRepository.Index();
        return Ok(logins);
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<Login>> Show(int id)
    {
        var login = await _loginRepository.Show(id);
        if (login == null) return NotFound(new { message = "Login not found" });
        return Ok(login);
    }


    [HttpPut("{id}")]
    public async Task<ActionResult<Login>> Update(int id, [FromBody] Login login)
    {
        var updateLogin = await _loginRepository.Show(id);
        if (updateLogin == null) return NotFound(new { message = "Login not found" });
        await _loginRepository.Update(id, login);
        return Ok(new { message = "Login updated" });
    }


    [HttpDelete("{id:int}")]
    public async Task<ActionResult<Login>> Destroy(int id)
    {
        var login = await _loginRepository.Show(id);
        if (login == null) return NotFound(new { message = "Login not found" });
        var deleteEmployee = await _loginRepository.Destroy(id);
        return Ok(new { message = "Login deleted" });
    }
}