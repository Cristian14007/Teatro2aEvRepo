using System.ComponentModel.DataAnnotations;

namespace BackEnd.Models;
using System.Text;
public class UserGetDTO
{
    [Required]
    public int UserId { get; set; }
    public string Name { get; set; }
    public string Password {get; set;}

        public User ToUser()
    {
        return new User
        {
            UserId = this.UserId,
            Name = this.Name,
            Password = this.Password
        };
    }
}