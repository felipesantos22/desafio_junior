using appmedic.Domain.Dtos;
using appmedic.Domain.Entities;
using appmedic.Domain.Interfaces;
using appmedic.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace appmedic.Infrastructure.Repository;

public class LoginRepository:ILogin
{
    private readonly DataContext _dataContext;

    public LoginRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    public async Task<Login> Create(Login login)
    {
        await _dataContext.Logins.AddAsync(login);
        await _dataContext.SaveChangesAsync();
        return login;
    }

    public async Task<List<LoginDto>> Index()
    {
        var logins = await _dataContext.Logins.Select(l => new LoginDto()
        {
            Id = l.Id,
            UserName = l.UserName,
        }).ToListAsync();
        return logins;
    }

    public async Task<Login?> Show(int id)
    {
        var login = await _dataContext.Logins.FirstOrDefaultAsync(c => c.Id == id);
        return login;
    }

    public async Task<Login> Update(int id, Login login)
    {
        var loginUpdate = await _dataContext.Logins.FirstOrDefaultAsync(c => c.Id == id);
        loginUpdate!.UserName = login.UserName;
        loginUpdate!.Password = login.Password;
        await _dataContext.SaveChangesAsync();
        return loginUpdate;
    }

    public async Task<Login?> Destroy(int id)
    {
        var deleteLogin = await _dataContext.Logins.FirstOrDefaultAsync(c => c.Id == id);
        _dataContext.Logins.Remove(deleteLogin!);
        await _dataContext.SaveChangesAsync();
        return deleteLogin;
    }

    // Function verify user in database
    public async Task<Login?> ShowLogin(string name, string password)
    {
        var existingLogin = await _dataContext.Logins
            .FirstOrDefaultAsync(e => e.UserName == name && e.Password == password);
        return existingLogin;
    }
}