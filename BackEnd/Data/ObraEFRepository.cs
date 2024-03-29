﻿using BackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Data
{

    public class ObraEFRepository : IObraRepository{

        private readonly ObraContext _context;

        private readonly IAsientoRepository _asientosRepository;

        public ObraEFRepository(ObraContext context, IAsientoRepository asientoRepository){
            _context = context;
            _asientosRepository = asientoRepository;
        }

        public void Add(Obra obra)
        {
            _context.Obras.Add(obra); 
            SaveChanges();

            for (int i = 1; i <= 20; i++)
            {
                var asiento = new Asiento
                {
                    ObraId = obra.ObraId,
                    Num_Asiento = i,
                    Reservado = false
                };

                    _asientosRepository.Add(asiento);
                
            }
        }

        public void Delete(int id)
        {
            
            var obraDto = Get(id);
            if (obraDto == null)
            {
                throw new KeyNotFoundException("Obra not found.");
            }

            var obra = _context.Obras.FirstOrDefault(o => o.ObraId == id);
            if (obra != null)
            {
                _context.Obras.Remove(obra);
                SaveChanges();
            }

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
                Duracion = o.Duracion,
                Imagen = o.Imagen,
                Sala = o.Sala,
                Fecha = o.Fecha,
                Fecha_Estreno_1 = o.Fecha_Estreno_1,
                Fecha_Estreno_2 = o.Fecha_Estreno_2,
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
                Duracion = o.Duracion,
                Sala = o.Sala,
                Imagen= o.Imagen,
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

        public void Update(Obra obra)
        {
            // Verificar si ya hay una instancia de Obra con el mismo ObraId en el contexto
            var existingObra = _context.Obras.Find(obra.ObraId);

            if (existingObra != null)
            {
                // Si existe una instancia previa, desvincularla del contexto
                _context.Entry(existingObra).State = EntityState.Detached;
            }

            // Adjuntar la nueva instancia de Obra al contexto
            _context.Attach(obra);

            // Marcar la entidad como modificada para que Entity Framework la actualice en la base de datos
            _context.Entry(obra).State = EntityState.Modified;

            // Guardar los cambios en la base de datos
            _context.SaveChanges();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        

        
    }

}
