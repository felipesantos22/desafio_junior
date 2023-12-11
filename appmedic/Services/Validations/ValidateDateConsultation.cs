using appmedic.Infrastructure.Data;

namespace appmedic.Services.Validations;

public class ValidateDateConsultation
{
    private readonly DataContext _dataContext;

    public ValidateDateConsultation(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    public bool ConsultationHourExists(DateTime date)
    {
        DateTime startDate = date.AddMinutes(-30);
        DateTime endDate = date.AddMinutes(30);
        return _dataContext.Consultations.Any(p => p.DateTime >= startDate && p.DateTime <= endDate);
    }
}