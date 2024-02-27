using System.ComponentModel.DataAnnotations;

namespace BackEnd.Models;
public class Obra
{

    [Key]
        public int ObraId { get; set; }
        [Required]
        public string Titulo { get; set; }
        [Required]
        public string Imagen { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public string Genero { get; set; }
        [Required]
        public string Duracion {get; set;}
        [Required]
        public string Director {get; set;}
        [Required]
        public string Interpretes {get; set;}
        //public List<Sesion> Sesiones { get; set; }

        public List<AsientosObra> ListAsientosObra { get; set; }

    

    public Obra (){

    }

    

}
