using System.ComponentModel.DataAnnotations;

namespace BackEnd.Models;

public class User
{
    [Key]
    // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int UserId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public User() { }
    public User(int userId, string name, string email, string password)
    {
        UserId = userId;
        Name = name;
        Email = email;
        Password = password;
        
    }
    public User mapFromCreateDto(UserCreateDTO userCreateDTO)
    {
        if (userCreateDTO == null)
        {
            throw new ArgumentNullException(nameof(userCreateDTO));
        }

        var user = new User
        {
            Name = userCreateDTO.Name,
            Password = userCreateDTO.Password,
            Email = userCreateDTO.Email,
            
        };

        return user;
    }
}