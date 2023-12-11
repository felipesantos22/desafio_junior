using appmedic.Domain.Entities;

namespace appmedic.Domain.Interfaces;

public interface IPatient
{
    public Task<Patient> Create(Patient patient);
    public Task<List<Patient>> Index();
    public Task<Patient> Show(int id);
    public Task<Patient> Update(int id, Patient patient);
    public Task<Patient> Destroy(int id);
}