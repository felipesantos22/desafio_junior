using appmedic.Infrastructure.Data;

namespace appmedic.Services.Validations;

public class ValidateCrm
{
    private readonly DataContext _dataContext;

    public ValidateCrm(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    
    public bool CrmExists(string crm)
    {
        return _dataContext.Doctors.Any(p => p.CRM == crm);
    } 
}