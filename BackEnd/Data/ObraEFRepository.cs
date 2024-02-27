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
            /* var pizzas = _context.Pizzas
        .Include(p => p.PizzaIngredientes)
            .ThenInclude(pi => pi.Ingrediente)
        .ToList();

    var pizzasDTO = pizzas.Select(p => new PizzaDTO
    {
        PizzaId = p.PizzaId,
        Nombre = p.Nombre,
        Ingredientes = p.PizzaIngredientes.Select(pi => new IngredienteDTO
        {
            IngredienteId = pi.Ingrediente.IngredienteId,
            Nombre = pi.Ingrediente.Nombre
        }).ToList()
    }).ToList();

    return pizzasDTO; */
        }

        public void Update(Obra obra)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }

}
