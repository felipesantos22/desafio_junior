using appmedic.Domain.Entities;

namespace appmedic.test;

public class CreateConsultationTests
{
    [Fact]
    public void Create_Consultation()
    {
        const int id = 2;
        const string dateTimeString = "2023-12-09T03:37:28.414Z";
        const int doctorId = 1;
        const int patientId = 1;
        
        DateTime dateTime = DateTime.Parse(dateTimeString);

        var consultation = new Consultation(id, dateTime, doctorId, patientId);

        Assert.Equal(id, consultation.Id);
        Assert.Equal(dateTime, consultation.DateTime);
        Assert.Equal(doctorId, consultation.DoctorId);
        Assert.Equal(patientId, consultation.PatienteId);
    }
}
