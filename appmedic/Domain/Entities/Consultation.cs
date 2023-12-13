using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace appmedic.Domain.Entities;

public class Consultation
{
    [Key] public int Id { get; set; }

    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}", ApplyFormatInEditMode = true)]
    public DateTime DateTime { get; set; }
    public int DoctorId { get; set; }

    [JsonIgnore] 
    public Doctor Doctor { get; set; }

    public int PatienteId { get; set; }

    [JsonIgnore] 
    public Patient Patient { get; set; }

    public Consultation()
    {
    }

    public Consultation(int id, DateTime dateTime, int doctorId, int patienteId)
    {
        Id = id;
        DateTime = dateTime;
        DoctorId = doctorId;
        PatienteId = patienteId;
    }
}