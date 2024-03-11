using System.ComponentModel.DataAnnotations;

namespace BackEnd.Models;

public class ObraUpdateDTO
{
    [Required]
    //[StringLength(30, ErrorMessage = "El titulo de la obra debe tener menos de 30 caracteres")]
    public string Titulo { get; set; }

    [Required]
    //[StringLength(100, ErrorMessage = "La descripcion de la obra debe tener menos de 100 caracteres")]
    public string Descripcion { get; set; }

}

