using BackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Data
{

    public class ObraEFRepository : IObraRepository{

        private readonly ObraContext _context;

        public ObraEFRepository(ObraContext context){
            _context = context;
        }

        public void Add(Obra obra)
        {
            _context.Obras.Add(obra);
            SaveChanges();
        }

        public void Delete(int id)
        {
            var obra = Get(id);
            if (obra != null)
            {
                _context.Remove(obra);
            }

            SaveChanges();

        }

        public Obra Get(int id)
        {
            return _context.Obras.FirstOrDefault(o => o.ObraId == id);
        }

        public List<Obra> GetAll()
        {

            return _context.Obras.ToList();
            
        }

        public void Update(Obra obra)
        {
            _context.Entry(obra).State = EntityState.Modified;
            SaveChanges();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }

}
