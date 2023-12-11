using appmedic.Infrastructure.Data;

namespace appmedic.Services.Validations;

public class ValidatePatientFk
{
    private readonly DataContext _dataContext;
    public ValidatePatientFk(DataContext dataContext)
    {
        this._dataContext = dataContext;
    }

    public bool ExistsPatientFk(int patientId)
    {
        return _dataContext.Patients.Any(d => d.Id == patientId);
    }
}