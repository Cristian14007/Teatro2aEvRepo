using System.ComponentModel.DataAnnotations;

namespace BackEnd.Models;

public class EstrenoGetDTO
{
    [Required]
    public int EstrenoId {get;set;}
    
    public string Titulo { get; set; }
    
    public string Imagen {get;set;}

   

    public EstrenoGetDTO()
    {
        
    }

    public Estreno ToEstreno()
{
    return new Estreno
    {
        EstrenoId = this.EstrenoId,
        Titulo = this.Titulo,
        Imagen =this.Imagen

    };
}
}