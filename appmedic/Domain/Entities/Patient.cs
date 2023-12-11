using System.ComponentModel.DataAnnotations;

namespace appmedic.Domain.Entities;

public class Patient
{
    public List<Consultation> Consultations = new();

    [Key] public int Id { get; set; }

    public string Name { get; set; }
    public string Age { get; set; }

    // https://learn.microsoft.com/pt-br/aspnet/mvc/overview/getting-started/introduction/adding-validation
    [Required]
    [StringLength(11, MinimumLength = 11, ErrorMessage = "The CPF must have 11 digits.")]
    [RegularExpression("^[0-9]*$", ErrorMessage = "The CPF must only contain numbers.")]
    public string Cpf { get; set; }
}