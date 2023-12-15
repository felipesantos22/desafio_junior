using System.ComponentModel.DataAnnotations;

namespace appmedic.Domain.Dtos;

public class DoctorDto
{
    [Key] 
    public int Id { get; set; }

    public string Name { get; set; }
    
    public string CRM { get; set; }
}