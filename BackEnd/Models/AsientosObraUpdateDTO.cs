using System.ComponentModel.DataAnnotations;

namespace BackEnd.Models;
using System.Text;
public class AsientosObraUpdateDTO
{
    [Required]
    public bool Reservado { get; set; }

}