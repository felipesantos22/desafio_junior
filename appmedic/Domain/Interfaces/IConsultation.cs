using appmedic.Domain.Entities;

namespace appmedic.Domain.Interfaces;

public interface IConsultation
{
    public Task<Consultation> Create(Consultation consultation);
    public Task<List<Consultation>> Index();
    public Task<Consultation> Show(int id);
    public Task<Consultation> Update(int id, Consultation consultation);
    public Task<Consultation> Destroy(int id);
}