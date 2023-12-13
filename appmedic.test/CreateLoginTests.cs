using appmedic.Domain.Entities;

namespace appmedic.test;

public class CreateLoginTests
{
    [Fact]
    public void Create_Login()
    {
        const int id = 2;
        const string userName = "José";
        const string password = "12345678000000";

        var login = new Login(id, userName, password);
        
        Assert.Equal(id, login.Id);
        Assert.Equal(userName, login.UserName);
        Assert.Equal(password, login.Password);
    }
}