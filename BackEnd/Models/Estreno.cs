using System.ComponentModel.DataAnnotations;

namespace BackEnd.Models;
public class Estreno
{

    [Key]
        public int EstrenoId { get; set; }
        [Required]
        public string Titulo { get; set; }
        
        public string Imagen { get; set; }
        
       

    

    public Estreno (){

    }
     public Estreno(string titulo, string imagen)
    {
        Titulo = titulo;
        Imagen = imagen;
        
       
    }

    public Estreno modifyEstrenoToDTO(EstrenoCreateDTO EstrenoCreateDTO)
    {
        if (EstrenoCreateDTO == null)
        {
            
            throw new ArgumentNullException(nameof(EstrenoCreateDTO));
        }

        var Estreno = new Estreno
        {
            Titulo = EstrenoCreateDTO.Titulo,
            Imagen = EstrenoCreateDTO.Imagen  
        };

        return Estreno;
    }

    

}