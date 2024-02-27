using System.ComponentModel.DataAnnotations;

namespace BackEnd.Models;

public class ObraCreateDTO
{
    [Required]
    [StringLength(30, ErrorMessage = "La descripcion de la obra debe tener menos de 30 caracteres")]
    public string Titulo { get; set; }

    [Required]
    [StringLength(100, ErrorMessage = "La descripcion de la obra debe tener menos de 100 caracteres")]
    public decimal Descripcion { get; set; }

    [Required]
    public decimal Genero { get; set; }
}

