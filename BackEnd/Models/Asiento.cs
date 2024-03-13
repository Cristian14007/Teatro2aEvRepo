namespace BackEnd.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
public class Asiento
{
    [Key]
    public int AsientoId { get; set; }
    [Required]
    public bool Reservado { get; set; }

    [ForeignKey ("Obra")]
    public int ObraId {get; set;}

    public Obra Obra {get; set;}

    public int Num_Asiento {get; set;}



    
    public Asiento() { }
    public Asiento(int asientoId, bool reservado, int obraId, int num_Asiento)
    {
        Reservado = reservado;
        AsientoId = asientoId;
        ObraId = obraId;
        Num_Asiento = num_Asiento;
        
    }

public Asiento modifyAsientoToDTO(AsientoCreateDTO asientoCreateDTO){
        
        if (asientoCreateDTO == null)
        {
            
            throw new ArgumentNullException(nameof(asientoCreateDTO));
        }

        var asiento = new Asiento
        {
            ObraId = asientoCreateDTO.ObraId,
            Num_Asiento = asientoCreateDTO.Num_Asiento,
            Reservado = false
        };

        return asiento;    
    }
    
}