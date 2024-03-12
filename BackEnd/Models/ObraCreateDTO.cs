using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BackEnd.Models
{
    public class ObraCreateDTO
    {
        
        public string Titulo { get; set; }
        
        public string Imagen { get; set; }
        
        public string Descripcion { get; set; }
        
        public string Genero { get; set; }
        
        public string Duracion { get; set; }
        
        public string Director { get; set; }
        
        public string Interpretes { get; set; }
        
        public DateTime Fecha { get; set; }
        
        public DateTime Fecha_Estreno_1 { get; set; }
        
        public DateTime Fecha_Estreno_2 { get; set; }
        
        public int Sala { get; set; }
        
        public int Valoracion { get; set; }
        
        public int Precio { get; set; }
    }
}
