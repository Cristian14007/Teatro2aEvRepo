using BackEnd.Models;
using System.Text.Json;
using System.Data.SqlClient;
using System.Data;
using Microsoft.EntityFrameworkCore;
using BackEnd.Data;
using System.Text;

namespace BackEnd.Data
{

    public class AsientoEFRepository : IAsientoRepository
    {


        private readonly ObraContext _context;

        public AsientoEFRepository(ObraContext context)
        {

            _context = context;
        }

        /* public List<Asiento> GetAll()
        {
            return _context.Asientos.ToList();
            
        } */

        public List<AsientoGetDTO> GetAll()
{
    var asientos = _context.Asientos.ToList();

    var asientosDTO = asientos.Select(a => new AsientoGetDTO
    {
        AsientoId = a.AsientoId,
        Reservado = a.Reservado,
        Num_Asiento = a.Num_Asiento,
        ObraId = a.ObraId
    }).ToList();

    return asientosDTO;
}

        public void Add(Asiento asiento)
        {
            _context.Asientos.Add(asiento);
            SaveChanges();
        }

        public AsientoGetDTO Get(int id)
        {
            //return _context.Asientos.FirstOrDefault(asiento => asiento.AsientoId == id);
        
            var asientos = _context.Asientos.ToList();

            var asientosDTO = asientos.Select(a => new AsientoGetDTO
            {
                 AsientoId = a.AsientoId,
                Reservado = a.Reservado,
                Num_Asiento = a.Num_Asiento,
                ObraId = a.ObraId
            }).ToList().FirstOrDefault(a => a.AsientoId == id);

            return asientosDTO;
    
        }

        /* public List<Asiento> GetFromFunction(int idFunction)
        {
            return _context.AsientosObras.Where(obra => obra.ObraId == idFunction).ToList();

        } */


        public void Update(Asiento asiento)
        {

            // Verificar si ya hay una instancia de Obra con el mismo ObraId en el contexto
            var existingAsiento = _context.Asientos.Find(asiento.AsientoId);

            if (existingAsiento != null)
            {
                // Si existe una instancia previa, desvincularla del contexto
                _context.Entry(existingAsiento).State = EntityState.Detached;
            }

            // Adjuntar la nueva instancia de Obra al contexto
            _context.Attach(asiento);

            // Marcar la entidad como modificada para que Entity Framework la actualice en la base de datos
            _context.Entry(asiento).State = EntityState.Modified;

            // Guardar los cambios en la base de datos
            _context.SaveChanges();
            /* _context.Entry(asiento).State = EntityState.Modified;
            SaveChanges(); */
        }

        public void Delete(int id)
        {
            var asientoDto = Get(id);
            if (asientoDto == null)
            {
                throw new KeyNotFoundException("Asiento not found.");
            }

            var asiento = _context.Asientos.FirstOrDefault(a => a.AsientoId == id);
            if (asiento != null)
            {
                _context.Asientos.Remove(asiento);
                SaveChanges();
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

    }

}