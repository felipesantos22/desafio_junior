using appmedic.Domain.Entities;
using appmedic.Domain.Interfaces;
using appmedic.Infrastructure.Data;
using Dapper;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;

namespace appmedic.Infrastructure.Repository;

public class DoctorRepository : IDoctor
{
    private readonly DataContext _dataContext;

    public DoctorRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<Doctor> Create(Doctor doctor)
    {
        await _dataContext.Doctors.AddAsync(doctor);
        await _dataContext.SaveChangesAsync();
        return doctor;
    }

    public async Task<List<Doctor>> Index()
    {
        var doctor = await _dataContext.Doctors.Include(e => e.Consultations).ToListAsync();
        return doctor;
    }

    public async Task<Doctor?> Show(int id)
    {
        var doctor = await _dataContext.Doctors.FirstOrDefaultAsync(c => c.Id == id);
        return doctor;
    }

    public async Task<Doctor> Update(int id, Doctor doctor)
    {
        var doctorUpdate = await _dataContext.Doctors.FirstOrDefaultAsync(c => c.Id == id);
        doctorUpdate!.Name = doctor.Name;
        doctorUpdate.CRM = doctor.CRM;
        doctorUpdate.Consultations = doctor.Consultations;
        await _dataContext.SaveChangesAsync();
        return doctorUpdate;
    }

    public async Task<Doctor> Destroy(int id)
    {
        var deleteDoctor = await _dataContext.Doctors.FirstOrDefaultAsync(c => c.Id == id);
        _dataContext.Doctors.Remove(deleteDoctor);
        await _dataContext.SaveChangesAsync();
        return deleteDoctor;
    }

    // Dapper
    public async Task<List<Doctor>> ShowName(string name)
    {
        using (var connection = new MySqlConnection(_dataContext.Database.GetConnectionString()))
        {
            connection.Open();
            var query = "SELECT * FROM Doctors WHERE Name LIKE @Name";
            var search = new { Name = $"%{name}%" };
            var doctors = await connection.QueryAsync<Doctor>(query, search);
            connection.Close();
            return doctors.ToList();
        }
    }
    
    public async Task<Doctor?> ShowDoctor(string name, string crm)
    {
        var existingEmployee = await _dataContext.Doctors
            .FirstOrDefaultAsync(e => e.Name == name && e.CRM == crm);
        return existingEmployee;
    }
}