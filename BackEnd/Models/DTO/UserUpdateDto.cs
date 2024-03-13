using System.ComponentModel.DataAnnotations;
namespace BackEnd.Models;
public class UserUpdateDTO
{
    [Required]
    public string Name { get; set; }
    public string Password {get; set;}
    public string Email {get; set;}

    }
