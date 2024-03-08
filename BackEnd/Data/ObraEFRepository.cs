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

        public ObraGetDTO Get(int id)
        {
            
            var obras = _context.Obras
                .Include(o => o.Asientos)
                .ToList();

            var obrasDTO = obras.Select(o => new ObraGetDTO
            {
                ObraId = o.ObraId,
                Titulo = o.Titulo,
                Descripcion = o.Descripcion,
                Genero = o.Genero,
                Interpretes = o.Interpretes,
                Director = o.Director,
                Valoracion = o.Valoracion,
                Precio = o.Precio,
                Asientos = o.Asientos.Select(a => new AsientoGetDTO
                {
                    AsientoId = a.AsientoId,
                    Reservado = a.Reservado,
                    Num_Asiento = a.Num_Asiento,
                    ObraId = a.ObraId

                }).ToList()
            }).FirstOrDefault(o => o.ObraId == id);

            return obrasDTO;
        }

        /* public ObraGetDTO GetDTO(int id){

            var obras = _context.Obras
                .Include(o => o.Asientos)
                .ToList();

            var obrasDTO = obras.Select(o => new ObraGetDTO
            {
                ObraId = o.ObraId,
                Titulo = o.Titulo,
                Asientos = o.Asientos.Select(a => new AsientoGetDTO
                {
                    AsientoId = a.AsientoId,
                    Reservado = a.Reservado

                }).ToList()
            }).FirstOrDefault(o => o.ObraId == id);

            return obrasDTO;
        } */

        public List<ObraGetDTO> GetAll()
        {

            //return _context.Obras.ToList();
            var obras = _context.Obras
                .Include(o => o.Asientos)
                .ToList();

            var obrasDTO = obras.Select(o => new ObraGetDTO
            {
                ObraId = o.ObraId,
                Titulo = o.Titulo,
                Descripcion = o.Descripcion,
                Genero = o.Genero,
                Interpretes = o.Interpretes,
                Director = o.Director,
                Valoracion = o.Valoracion,
                Precio = o.Precio,
                Asientos = o.Asientos.Select(a => new AsientoGetDTO
                {
                    AsientoId = a.AsientoId,
                    Reservado = a.Reservado,
                    Num_Asiento = a.Num_Asiento,
                    ObraId = a.ObraId

                }).ToList()
            }).ToList();

            return obrasDTO;
        }

        public void Update(ObraGetDTO obra)
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
