using appmedic.Infrastructure.Data;

namespace appmedic.Services.Validations;

public class ValidateUserName
{
    private readonly DataContext _dataContext;

    public ValidateUserName(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    
    public bool UserNameExists(string userName)
    {
        return _dataContext.Users.Any(p => p.UserName == userName);
    } 
}