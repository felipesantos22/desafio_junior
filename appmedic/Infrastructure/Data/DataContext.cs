using appmedic.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace appmedic.Infrastructure.Data;

public class DataContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public DataContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Consultation> Consultations { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<User> Logins { get; set; }
    public DbSet<Address> ViaCep { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        var connectionString = Configuration.GetConnectionString("WebApiDatabase");
        options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new DoctorMap());

        modelBuilder.Entity<Doctor>()
            .HasIndex(d => d.CRM)
            .IsUnique();

        modelBuilder.Entity<Patient>()
            .HasIndex(d => d.Cpf)
            .IsUnique();

        modelBuilder.Entity<Doctor>()
            .HasMany(e => e.Consultations)
            .WithOne(e => e.Doctor)
            .HasForeignKey(e => e.DoctorId)
            .IsRequired();

        modelBuilder.Entity<Patient>()
            .HasMany(e => e.Consultations)
            .WithOne(e => e.Patient)
            .HasForeignKey(e => e.PatienteId)
            .IsRequired();

        modelBuilder.Entity<Address>()
            .HasOne(a => a.Patient)
            .WithOne(a => a.Address)
            .HasForeignKey<Address>(a => a.PatientId)
            .IsRequired();
    }
}