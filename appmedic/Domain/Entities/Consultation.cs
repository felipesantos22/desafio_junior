using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace appmedic.Domain.Entities;

public class Consultation
{
    [Key] public int Id { get; set; }

    public DateTime DateTime { get; set; }
    public int DoctorId { get; set; }

    [JsonIgnore] 
    public Doctor Doctor { get; set; }

    public int PatienteId { get; set; }

    [JsonIgnore] 
    public Patient Patiente { get; set; }
}