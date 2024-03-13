namespace BackEnd.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
public class AsientoGetDTO
{
    [Key]
    public int AsientoId { get; set; }
    [Required]
    public bool Reservado { get; set; }

    [Required]
    public int Num_Asiento { get; set; }

    
    public int ObraId { get; set; }
    
    public AsientoGetDTO() { }
    
    public Asiento ToAsiento()
{
    return new Asiento
    {
        AsientoId = this.AsientoId,
        Reservado = this.Reservado,
        Num_Asiento = this.Num_Asiento,
        ObraId = this.ObraId
    };
}
    
}