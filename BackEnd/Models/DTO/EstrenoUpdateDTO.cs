using System.ComponentModel.DataAnnotations;

namespace BackEnd.Models;

public class EstrenoUpdateDTO
{
    [Required]
    //[StringLength(30, ErrorMessage = "El titulo de la Estreno debe tener menos de 30 caracteres")]
    public string Titulo { get; set; }

 

}

