using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace appmedic.Domain.Entities;

public class Patient
{
    [Key] public int Id { get; set; }

    public string Name { get; set; }
    public string Age { get; set; }

    [Required]
    [StringLength(11, MinimumLength = 11, ErrorMessage = "The CPF must have 11 digits.")]
    [RegularExpression("^[0-9]*$", ErrorMessage = "The CPF must only contain numbers.")]
    public string Cpf { get; set; }
    
    public List<Consultation> Consultations { get; set; } = new();

    
    
    
    
    
    // Using tests
    public Patient()
    {
    }

    public Patient(int id, string name, string age, string cpf)
    {
        Id = id;
        Name = name;
        Age = age;
        Cpf = cpf;
    }
}