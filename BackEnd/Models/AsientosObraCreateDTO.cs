using System.ComponentModel.DataAnnotations;

namespace BackEnd.Models;

using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
public class AsientosObraCreateDTO
{
    [ForeignKey("Obra")]
    public int ObraId { get; set; }

}