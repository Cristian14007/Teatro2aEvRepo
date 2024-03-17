using System.ComponentModel.DataAnnotations;

namespace BackEnd.Models;
using System.Text;
public class UserCreateDTO
{
    [Required]
    public string Name { get; set; }
    public string Password {get; set;}
    public string Email {get; set;}

    }
