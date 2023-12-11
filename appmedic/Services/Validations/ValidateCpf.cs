using appmedic.Infrastructure.Data;

namespace appmedic.Services.Validations;

public class ValidateCpf
{
    private readonly DataContext _dataContext;

    public ValidateCpf(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    
    public bool CpfExists(string cpf)
    {
        return _dataContext.Patients.Any(p => p.Cpf == cpf);
    } 
}