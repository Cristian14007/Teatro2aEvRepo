using BackEnd.Models;
using System.Text.Json;
using System.Data.SqlClient;
using System.Data;
using Microsoft.EntityFrameworkCore;
using BackEnd.Data;

namespace BackEnd.Data
{

    public class AsientoEFRepository : IAsientoRepository
    {


        private readonly ObraContext _context;

        public AsientoEFRepository(ObraContext context)
        {

            _context = context;
        }

        public List<Asiento> GetAll()
        {
            return _context.Asientos.ToList();
            
        }

        public void Add(Asiento asiento)
        {
            _context.Asientos.Add(asiento);
            SaveChanges();
        }

        public Asiento Get(int id)
        {
            return _context.Asientos.FirstOrDefault(asiento => asiento.AsientoId == id);
        }

        /* public List<Asiento> GetFromFunction(int idFunction)
        {
            return _context.AsientosObras.Where(obra => obra.ObraId == idFunction).ToList();

        } */


        public void Update(Asiento asiento)
        {
            _context.Entry(asiento).State = EntityState.Modified;
            SaveChanges();
        }

        public void Delete(int id)
        {
            var asiento = Get(id);
            if (asiento != null)
            {
                _context.Remove(asiento);
            }

            SaveChanges();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

    }

}