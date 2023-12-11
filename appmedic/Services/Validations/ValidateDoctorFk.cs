using appmedic.Infrastructure.Data;

namespace appmedic.Services.Validations;

public class ValidateDoctorFk
{
    private readonly DataContext _dataContext;
    
    public ValidateDoctorFk(DataContext dataContext)
    {
        this._dataContext = dataContext;
    }

    public bool ExistsDoctorFk(int doctorId)
    {
        return _dataContext.Doctors.Any(d => d.Id == doctorId);
    }
}