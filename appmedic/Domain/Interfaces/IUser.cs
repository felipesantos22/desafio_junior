using appmedic.Domain.Dtos;
using appmedic.Domain.Entities;

namespace appmedic.Domain.Interfaces;

public interface IUser
{
    public Task<User> Create(User user);
    public Task<List<LoginDto>> Index();
    public Task<User?> Show(int id);
    public Task<User> Update(int id, User user);
    public Task<User?> Destroy(int id);
}