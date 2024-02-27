using Microsoft.EntityFrameworkCore;
using BackEnd.Models;
using Microsoft.Extensions.Configuration;

namespace BackEnd.Data{

    public class ObraContext : DbContext
    {
        public ObraContext(DbContextOptions<ObraContext> options)
            : base(options)
            {

            }

            
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
modelBuilder.Entity<Obra>().HasData(
    new Obra { ObraId = 1, Titulo = "Obra 1", Descripcion = "Descripcion 1", Genero = "Drama", Imagen = "ruta imagen 1"},
    new Obra { ObraId = 2, Titulo = "Obra 2", Descripcion = "Descripcion 2", Genero = "Comedia", Imagen = "ruta imagen 2"},
    new Obra { ObraId = 3, Titulo = "Obra 3", Descripcion = "Descripcion 3", Genero = "Suspense", Imagen = "ruta imagen 3"},
    new Obra { ObraId = 4, Titulo = "Obra 4", Descripcion = "Descripcion 4", Genero = "Suspense", Imagen = "ruta imagen 4"},
    new Obra { ObraId = 5, Titulo = "Obra 5", Descripcion = "Descripcion 5", Genero = "Drama", Imagen = "ruta imagen 5"},
    new Obra { ObraId = 6, Titulo = "Obra 6", Descripcion = "Descripcion 6", Genero = "Comedia", Imagen = "ruta imagen 6"},
    new Obra { ObraId = 7, Titulo = "Obra 7", Descripcion = "Descripcion 7", Genero = "Comedia", Imagen = "ruta imagen 7"}
    
);

modelBuilder.Entity<Sesion>().HasData(
    new Sesion { SesionId = 1, DiaSesion = new DateTime(2024,03,24), HoraSesion = new TimeSpan (20,30,0), ObraId = 1}
    
    
);
          

            modelBuilder.Entity<Asiento>()
                .HasOne(a => a.User)
                .WithMany(u => u.Asientos)
                .HasForeignKey(a => a.UserId);

          
            modelBuilder.Entity<Sesion>()
                .HasOne(s => s.Obra)
                .WithMany(o => o.Sesiones)
                .HasForeignKey(s => s.ObraId);

          
            modelBuilder.Entity<Asiento>()
                .HasOne(a => a.Sesion)
                .WithMany(s => s.Asientos)
                .HasForeignKey(a => a.SesionId)
                 .OnDelete(DeleteBehavior.NoAction);
        }

        public DbSet<Obra> Obras {get; set;}

        public DbSet<Asiento> Asientos {get; set;}

        public DbSet<Sesion> Sesiones {get; set;}

        public DbSet<User> Usuarios {get; set;}
    }
}