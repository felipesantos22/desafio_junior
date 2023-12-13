using appmedic.Domain.Entities;

namespace appmedic.test;

public class CreateDoctorTests
{
    [Fact]
    public void Create_Doctor()
    {
        const int id = 2;
        const string name = "José";
        const string crm = "123456";

        var doctor = new Doctor(id, name, crm);
        
        Assert.Equal(id, doctor.Id);
        Assert.Equal(name, doctor.Name);
        Assert.Equal(crm, doctor.CRM);
    }
}