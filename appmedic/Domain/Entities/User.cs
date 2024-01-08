using System.ComponentModel.DataAnnotations;

namespace appmedic.Domain.Entities;

public class User
{
    [Key]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Username is required.")]
    public string UserName { get; set; }

   
    [Required(ErrorMessage = "Password is required.")]
    [StringLength(10, MinimumLength = 6, ErrorMessage = "Password must be between 6 and 10 characters.")]
    
    [MaxLength(300)]
    public string Password { get; set; }
    public string Role { get; set; }
    public User()
    {
    }

    public User(int id, string userName, string password)
    {
        Id = id;
        UserName = userName;
        Password = password;
    }
}