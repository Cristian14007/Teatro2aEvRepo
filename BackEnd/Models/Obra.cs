using System.ComponentModel.DataAnnotations;

namespace BackEnd.Models;
public class Obra
{

    [Key]
        public int ObraId { get; set; }
        [Required]
        public string Titulo { get; set; }
        
        public string Imagen { get; set; }
        
        public string Descripcion { get; set; }
        
        public string Genero { get; set; }
        
        public string Duracion {get; set;}
        
        public string Director {get; set;}
        
        public string Interpretes {get; set;}
        
        public DateTime Fecha {get;set;}
        
        public DateTime Fecha_Estreno_1 {get;set;}
        
        public DateTime Fecha_Estreno_2 {get;set;}

        
        public int Sala {get;set;}
        
        public int Valoracion {get;set;}
        
        public int Precio {get;set;}
        //public List<Sesion> Sesiones { get; set; }

        public List<Asiento> Asientos { get; set; }

    

    public Obra (){

    }
     public Obra(string titulo, string descripcion,string director,string interpretes, DateTime fecha,DateTime fecha_Estreno_1,DateTime fecha_Estreno_2, string imagen, string genero, string duracion, int precio)
    {
        Titulo = titulo;
        Imagen = imagen;
        Descripcion = descripcion;
        Genero = genero;
        Duracion = duracion;
        Director = director;
        Interpretes = interpretes;
        Fecha = fecha;
        Fecha_Estreno_1 = fecha_Estreno_1;
        Fecha_Estreno_2 = fecha_Estreno_2;     
        Precio = precio;
       


    }

    

}
