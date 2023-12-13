using appmedic.Domain.Entities;

namespace appmedic.test;

public class CreatePatientTests
{
    [Fact]
    public void Create_Patient()
    {
        const int id = 2;
        const string name = "José";
        const string age = "12345678000000";
        const string cpf = "000000000";

        var patient = new Patient(id, name, age, cpf);
        
        Assert.Equal(id, patient.Id);
        Assert.Equal(name, patient.Name);
        Assert.Equal(age, patient.Age);
        Assert.Equal(cpf, patient.Cpf);
    }
}