using System.ComponentModel.DataAnnotations;

namespace BackEnd.Models;

public class ObraGetDTO
{
    [Required]
    public int ObraId {get;set;}
    
    public string Titulo { get; set; }
    public string Descripcion { get; set; }
    public string Genero { get; set; }
    public string Interpretes { get; set; }
    public string Director { get; set; }
    public int Valoracion { get; set; }
    public int Precio { get; set; }


    public List<AsientoGetDTO> Asientos{get;set;}

    public ObraGetDTO()
    {
        
    }
}