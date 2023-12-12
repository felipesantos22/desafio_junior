using System.ComponentModel.DataAnnotations;
using appmedic.Domain.Entities;

namespace appmedic.test;

public class LoginTests
{
    [Fact]
    public void UserName_Validation_Success()
    {
        // Arrange
        var login = new Login()
        {
            Id = 1,
            UserName = "felipevs",
            Password = "123456"
        };

        // Act
        var validationContext = new ValidationContext(login, null, null);
        var validationResults = new List<ValidationResult>();
        var isValid = Validator.TryValidateObject(login, validationContext, validationResults, true);

        // Assert
        Assert.True(isValid);
        Assert.Empty(validationResults);
    }

}