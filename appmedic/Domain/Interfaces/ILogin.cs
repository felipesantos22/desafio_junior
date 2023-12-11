using appmedic.Domain.Entities;

namespace appmedic.Domain.Interfaces;

public interface ILogin
{
    public Task<Login> Create(Login login);
    public Task<List<Login>> Index();
    public Task<Login?> Show(int id);
    public Task<Login> Update(int id, Login login);
    public Task<Login?> Destroy(int id);
}