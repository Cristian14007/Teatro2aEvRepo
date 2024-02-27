using System.ComponentModel.DataAnnotations;

namespace BackEnd.Models;
public class Sesion
{

    [Key]
    public int SesionId { get; set; }
    [Required]
    public int ObraId { get; set; }

    public DateTime DiaSesion{ get; set; }

    public TimeSpan HoraSesion {get; set;}
    public Obra Obra { get; set; }
    
    public List<Asiento> Asientos { get; set; }

    

    public Sesion (){

    }

    
}
