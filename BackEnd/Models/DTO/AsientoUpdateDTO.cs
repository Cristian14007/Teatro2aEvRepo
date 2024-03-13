using System.ComponentModel.DataAnnotations;

namespace BackEnd.Models;
using System.Text;
public class AsientoUpdateDTO
{
    [Required]
    public bool Reservado { get; set; }

}