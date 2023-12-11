using appmedic.Domain.Entities;
using appmedic.Domain.Interfaces;
using appmedic.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace appmedic.Infrastructure.Repository;

public class PatientRepository : IPatient
{
    private readonly DataContext _dataContext;

    public PatientRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<Patient> Create(Patient patient)
    {
        await _dataContext.Patients.AddAsync(patient);
        await _dataContext.SaveChangesAsync();
        return patient;
    }

    public async Task<List<Patient>> Index()
    {
        var patient = await _dataContext.Patients.Include(e => e.Consultations).ToListAsync();
        return patient;
    }

    public async Task<Patient> Show(int id)
    {
        var patient = await _dataContext.Patients.FirstOrDefaultAsync(p => p.Id == id);
        return patient;
    }

    public async Task<Patient> Update(int id, Patient patiente)
    {
        var patienteUpdate = await _dataContext.Patients.FirstOrDefaultAsync(c => c.Id == id);
        patienteUpdate!.Name = patiente.Name;
        patienteUpdate.Age = patiente.Age;
        patienteUpdate.Cpf = patiente.Cpf;
        await _dataContext.SaveChangesAsync();
        return patienteUpdate;
    }

    public async Task<Patient> Destroy(int id)
    {
        var deletePatiente = await _dataContext.Patients.FirstOrDefaultAsync(c => c.Id == id);
        _dataContext.Patients.Remove(deletePatiente);
        await _dataContext.SaveChangesAsync();
        return deletePatiente;
    }
}