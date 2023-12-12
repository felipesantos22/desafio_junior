using System.ComponentModel.DataAnnotations;
using appmedic.Domain.Entities;

namespace appmedic.test;

public class PatientTests
{
    [Fact]
    public void Cpf_Validation_Success()
    {
        // Arrange
        var patient = new Patient()
        {
            Id = 1,
            Name = "Lucas Silva ",
            Cpf = "12345678901" // Valid CPF with 11 digits
        };

        // Act
        var validationContext = new ValidationContext(patient, null, null);
        var validationResults = new List<ValidationResult>();
        var isValid = Validator.TryValidateObject(patient, validationContext, validationResults, true);

        // Assert
        Assert.True(isValid);
        Assert.Empty(validationResults);
    }
}