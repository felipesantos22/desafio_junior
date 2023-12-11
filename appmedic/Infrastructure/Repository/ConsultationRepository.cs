using appmedic.Domain.Entities;
using appmedic.Domain.Interfaces;
using appmedic.Error;
using appmedic.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace appmedic.Infrastructure.Repository;

public class ConsultationRepository : IConsultation
{
    private readonly DataContext _dataContext;

    public ConsultationRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    /*public async Task<Consultation> Create(Consultation consultation)
    {
        await _dataContext.Consultations.AddAsync(consultation);
        await _dataContext.SaveChangesAsync();
        return consultation;
    }*/


    public async Task<Consultation> Create(Consultation consultation)
    {
        var existingDoctor = await _dataContext.Doctors.FindAsync(consultation.DoctorId);
        if (existingDoctor == null) throw new ValidationExceptionConsultation("Doctor not found");
        var existingPatient = await _dataContext.Patients.FindAsync(consultation.PatienteId);
        if (existingPatient == null) throw new ValidationExceptionConsultation("Patient not found");
        await _dataContext.Consultations.AddAsync(consultation);
        await _dataContext.SaveChangesAsync();
        return consultation;
    }

    public async Task<List<Consultation>> Index()
    {
        var consultation = await _dataContext.Consultations.Include(c => c.Doctor)
            .Include(c => c.Patiente).ToListAsync();
        return consultation;
    }

    public async Task<Consultation> Show(int id)
    {
        var consultation = await _dataContext.Consultations.FirstOrDefaultAsync(p => p.Id == id);
        return consultation;
    }

    public async Task<Consultation> Update(int id, Consultation consultation)
    {
        var consultationUpdate = await _dataContext.Consultations.FirstOrDefaultAsync(c => c.Id == id);
        consultationUpdate!.DateTime = consultation.DateTime;
        consultationUpdate.DoctorId = consultation.DoctorId;
        consultationUpdate.PatienteId = consultation.PatienteId;
        await _dataContext.SaveChangesAsync();
        return consultationUpdate;
    }

    public async Task<Consultation> Destroy(int id)
    {
        var deleteConsultation = await _dataContext.Consultations.FirstOrDefaultAsync(c => c.Id == id);
        _dataContext.Consultations.Remove(deleteConsultation);
        await _dataContext.SaveChangesAsync();
        return deleteConsultation;
    }
}