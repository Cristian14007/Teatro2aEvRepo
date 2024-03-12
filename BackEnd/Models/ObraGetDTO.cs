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
    public string Duracion {get; set;}
    public int Sala {get;set;}
    public string Imagen {get;set;}


    public List<AsientoGetDTO> Asientos{get;set;}

    public ObraGetDTO()
    {
        
    }

    public Obra ToObra()
{
    return new Obra
    {
        ObraId = this.ObraId,
        Titulo = this.Titulo,
        Descripcion = this.Descripcion,
        Genero = this.Genero,
        Duracion = this.Duracion,
        Director = this.Director,
        Interpretes = this.Interpretes,
        Sala = this.Sala,
        Valoracion = this.Valoracion,
        Precio = this.Precio,
        Imagen =this.Imagen,
        Asientos = this.Asientos != null ? this.Asientos.Select(a => new Asiento
        {
            AsientoId = a.AsientoId,
            Reservado = a.Reservado,
            Num_Asiento = a.Num_Asiento
        }).ToList() : null
    };
}
}