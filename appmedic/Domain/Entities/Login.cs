using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace appmedic.Domain.Entities;

public class Login
{
    [Key]
    public int Id { get; set; }

    //https://learn.microsoft.com/pt-br/aspnet/mvc/overview/getting-started/introduction/adding-validation
    [Required(ErrorMessage = "Username is required.")]
    public string UserName { get; set; }

    //https://learn.microsoft.com/pt-br/aspnet/mvc/overview/getting-started/introduction/adding-validation
    [Required(ErrorMessage = "Password is required.")]
    [StringLength(10, MinimumLength = 6, ErrorMessage = "Password must be between 6 and 10 characters.")]
    public string Password { get; set; }
    
    public Login()
    {
    }

    public Login(int id, string userName, string password)
    {
        Id = id;
        UserName = userName;
        Password = password;
    }
}