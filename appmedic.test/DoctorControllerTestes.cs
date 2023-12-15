using appmedic.Controllers;
using appmedic.Domain.Entities;
using appmedic.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace appmedic.test;

public class DoctorControllerTestes
{
    [Fact]
    public async Task Index_ReturnsOkObjectResult_WithListOfDoctors()
    {
        // Arrange
        var doctorRepositoryMock = new Mock<IDoctor>();
        var doctorsList = new List<Doctor>
        {
            new Doctor { Id = 1, Name = "Doctor 1", CRM = "123456"},
            new Doctor { Id = 2, Name = "Doctor 2", CRM = "123456"}
        };

        doctorRepositoryMock.Setup(repo => repo.Index()).ReturnsAsync(doctorsList);

        var controller = new DoctorController(doctorRepositoryMock.Object);

        // Act
        var result = await controller.Index();

        // Assert
        var okObjectResult = Assert.IsType<OkObjectResult>(result);
        var model = Assert.IsAssignableFrom<List<Doctor>>(okObjectResult.Value);

        Assert.Equal(doctorsList.Count, model.Count);
    }
}