using System.ComponentModel.DataAnnotations;
using appmedic.Domain.Entities;

namespace appmedic.test;

public class DoctorTests
{
    [Fact]
    public void CRM_Validation_Success()
    {
        
        // Arrange
        var doctor = new Doctor()
        {
            Id = 1,
            Name = "Felipe Santos",
            CRM = "123456" // Valid CRM with 6 digits
        };

        // Act
        var validationContext = new ValidationContext(doctor, null, null);
        var validationResults = new List<ValidationResult>();
        var isValid = Validator.TryValidateObject(doctor, validationContext, validationResults, true);

        // Assert
        Assert.True(isValid);
        Assert.Empty(validationResults);
    }
}