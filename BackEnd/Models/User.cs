using System.ComponentModel.DataAnnotations;

namespace BackEnd.Models;
public class User
{

    [Key]
    public int UserId { get; set; }
    [Required]
    public string Username { get; set; }
    [Required]
    public string Password { get; set; }
    
    public List<Asiento> Asientos { get; set; }

    public User (){

    }

    

}
