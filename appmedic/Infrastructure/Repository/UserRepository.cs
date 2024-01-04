using appmedic.Domain.Dtos;
using appmedic.Domain.Entities;
using appmedic.Domain.Interfaces;
using appmedic.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace appmedic.Infrastructure.Repository;

public class UserRepository:IUser
{
    private readonly DataContext _dataContext;

    public UserRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    public async Task<User> Create(User user)
    {
        await _dataContext.Users.AddAsync(user);
        await _dataContext.SaveChangesAsync();
        return user;
    }

    public async Task<List<LoginDto>> Index()
    {
        var logins = await _dataContext.Users.Select(l => new LoginDto()
        {
            Id = l.Id,
            UserName = l.UserName,
        }).ToListAsync();
        return logins;
    }

    public async Task<User?> Show(int id)
    {
        var login = await _dataContext.Users.FirstOrDefaultAsync(c => c.Id == id);
        return login;
    }

    public async Task<User> Update(int id, User user)
    {
        var loginUpdate = await _dataContext.Users.FirstOrDefaultAsync(c => c.Id == id);
        loginUpdate!.UserName = user.UserName;
        loginUpdate!.Password = user.Password;
        await _dataContext.SaveChangesAsync();
        return loginUpdate;
    }

    public async Task<User?> Destroy(int id)
    {
        var deleteLogin = await _dataContext.Users.FirstOrDefaultAsync(c => c.Id == id);
        _dataContext.Users.Remove(deleteLogin!);
        await _dataContext.SaveChangesAsync();
        return deleteLogin;
    }

    // Function verify user in database
    public async Task<User?> ShowLogin(string name, string password)
    {
        var existingLogin = await _dataContext.Users
            .FirstOrDefaultAsync(e => e.UserName == name && e.Password == password);
        return existingLogin;
    }
}