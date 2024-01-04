using appmedic.Domain.Dtos;
using appmedic.Domain.Entities;
using appmedic.Infrastructure.Repository;
using appmedic.Services.Validations;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace appmedic.Controllers;

[ApiController]
[Route("api/login")]
public class UserController : ControllerBase
{
    private readonly UserRepository _userRepository;
    private readonly ValidateUserName _validateUserName;
    private readonly IMapper _mapper;

    public UserController(UserRepository userRepository, ValidateUserName validateUserName, IMapper mapper)
    {
        _userRepository = userRepository;
        _validateUserName = validateUserName;
        _mapper = mapper;
    }


    [HttpPost]
    public async Task<ActionResult<User>> Create([FromBody] User user)
    {
        var userName = _validateUserName.UserNameExists(user.UserName);
        if (userName)
        {
            return BadRequest(new {message = "UserName already registered." });
        }
        var newLogin = await _userRepository.Create(user);
        return Ok(newLogin);
    }


    [HttpGet]
    public async Task<ActionResult<List<User>>> Index()
    {
        var logins = await _userRepository.Index();
        return Ok(logins);
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<User>> Show(int id)
    {
        var login = await _userRepository.Show(id);
        var loginDto = _mapper.Map<LoginDto>(login);
        if (login == null) return NotFound(new { message = "User not found" });
        return Ok(loginDto);
    }


    [HttpPut("{id}")]
    public async Task<ActionResult<User>> Update(int id, [FromBody] User user)
    {
        var updateLogin = await _userRepository.Show(id);
        if (updateLogin == null) return NotFound(new { message = "User not found" });
        await _userRepository.Update(id, user);
        return Ok(new { message = "User updated" });
    }


    [HttpDelete("{id:int}")]
    public async Task<ActionResult<User>> Destroy(int id)
    {
        var login = await _userRepository.Show(id);
        if (login == null) return NotFound(new { message = "User not found" });
        var deleteEmployee = await _userRepository.Destroy(id);
        return Ok(new { message = "User deleted" });
    }
}