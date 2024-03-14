using BackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Data
{

    public class EstrenoEFRepository : IEstrenoRepository{

         private readonly ObraContext _context;

       

        public EstrenoEFRepository(ObraContext context){
            _context = context;
           
        }

        public void Add(Estreno Estreno)
        {
            _context.Estrenos.Add(Estreno); 
            SaveChanges();

          
        }

        public void Delete(int id)
        {
            
            var EstrenoDto = Get(id);
            if (EstrenoDto == null)
            {
                throw new KeyNotFoundException("Estreno not found.");
            }

            var Estreno = _context.Estrenos.FirstOrDefault(o => o.EstrenoId == id);
            if (Estreno != null)
            {
                _context.Estrenos.Remove(Estreno);
                SaveChanges();
            }

        }

       public EstrenoGetDTO Get(int id)
        {
            var Estreno = _context.Estrenos
                .Where(Estreno => Estreno.EstrenoId == id)
                .FirstOrDefault();

            if (Estreno != null)
            {
                var EstrenoGetDTO = new EstrenoGetDTO
                {
                    EstrenoId = Estreno.EstrenoId,
                    Titulo = Estreno.Titulo,
                    Imagen = Estreno.Imagen
                    
                };

                return EstrenoGetDTO;
            }
            else
            {
                return null; // Devuelve null si no se encuentra la obra
            }

        }

        

        public List<EstrenoGetDTO> GetAll()
        {
            var Estrenos = _context.Estrenos
                .ToList();

            if (Estrenos != null)
            {
                var EstrenoGetDTO = Estrenos.Select(e => new EstrenoGetDTO
                {
                    EstrenoId = e.EstrenoId,
                    Titulo = e.Titulo,
                    Imagen = e.Imagen,
                }).ToList();
                return EstrenoGetDTO;
            }
            else
            {
                return null; // Devuelve null si no se encuentra la obra
            }
        }

        public void Update(Estreno Estreno)
        {
            // Verificar si ya hay una instancia de Estreno con el mismo EstrenoId en el contexto
            var existingEstreno = _context.Estrenos.Find(Estreno.EstrenoId);

            if (existingEstreno != null)
            {
                // Si existe una instancia previa, desvincularla del contexto
                _context.Entry(existingEstreno).State = EntityState.Detached;
            }

            // Adjuntar la nueva instancia de Estreno al contexto
            _context.Attach(Estreno);

            // Marcar la entidad como modificada para que Entity Framework la actualice en la base de datos
            _context.Entry(Estreno).State = EntityState.Modified;

            // Guardar los cambios en la base de datos
            _context.SaveChanges();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        

        
    }

}