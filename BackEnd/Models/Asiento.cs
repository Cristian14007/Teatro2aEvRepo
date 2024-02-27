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

        public List<AsientosObra> ListAsientosObra { get; set; }



    
    public Asiento() { }
    public Asiento(int asientoId, bool reservado)
    {
        Reservado = reservado;
        AsientoId = asientoId;
        
    }

    
}