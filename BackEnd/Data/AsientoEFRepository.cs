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

        public List<AsientosObra> GetAll()
        {
            return _context.AsientosObras.ToList();
            // var pizzas = _context.Pizzas
            //     .Include(p => p.PizzaIngredientes)
            //         .ThenInclude(pi => pi.Ingrediente)
            //     .ToList();

            // var pizzasDto = pizzas.Select(p => new PizzaDto
            // {
            //     Id = p.Id,
            //     Name = p.Name,
            //     PizzaIngredientes = p.PizzaIngredientes.Select(pi => new IngredienteDto
            //     {
            //         Id = pi.Ingrediente.Id,
            //         Name = pi.Ingrediente.Name
            //     }).ToList()
            // }).ToList();

            // return pizzasDto;
        }

        public void Add(AsientosObra Asiento)
        {
            _context.AsientosObras.Add(Asiento);
            SaveChanges();
        }

        public AsientosObra GetAsiento(int idFunction, int idAsiento)
        {
            return _context.AsientosObras.FirstOrDefault(obra => obra.ObraId == idFunction && obra.AsientoId == idAsiento);
        }

        public List<AsientosObra> GetFromFunction(int idFunction)
        {
            return _context.AsientosObras.Where(obra => obra.ObraId == idFunction).ToList();

        }


        public void Update(AsientosObra Asiento)
        {
            _context.Entry(Asiento).State = EntityState.Modified;
            SaveChanges();
        }

        public void Delete(int idFunction, int idAsiento)
        {
            var Asiento = GetAsiento(idFunction, idAsiento);
            if (Asiento is null)
            {
                throw new KeyNotFoundException("Pizza not found.");
            }
            _context.AsientosObras.Remove(Asiento);
            SaveChanges();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

    }

}