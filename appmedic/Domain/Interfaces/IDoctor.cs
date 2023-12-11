using appmedic.Domain.Entities;

namespace appmedic.Domain.Interfaces;

public interface IDoctor
{
    public Task<Doctor> Create(Doctor doctor);
    public Task<List<Doctor>> Index();
    public Task<Doctor> Show(int id);
    public Task<Doctor> Update(int id, Doctor doctor);
    public Task<Doctor> Destroy(int id);
}