using System.ComponentModel.DataAnnotations;

namespace BackEnd.Models;
public class Asiento
{

    [Key]
    public int AsientoId { get; set; }
    [Required]
    public int NumAsiento { get; set; }
    [Required]
    public bool Reservado {get; set;}
    public int UserId { get; set; }
    public User User { get; set; }
    public int SesionId { get; set; }
    public Sesion Sesion { get; set; }

    
    public Asiento (){

    }

    

}
