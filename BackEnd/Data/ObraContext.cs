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

        
        public List<AsientosObra> CreateAsientosObra(int obraId)
        {
            List<AsientosObra> asientos = new List<AsientosObra>();

            for (int i = 1; i <= 25; i++)
            {
                asientos.Add(new AsientosObra
                {
                    AsientoId = i,
                    ObraId = obraId,
                    Reservado = false
                });
            }

            return asientos;
        }

        public List<Asiento> CrearAsientos()
        {
            List<Asiento> Asientos = new List<Asiento>();

            for (int i = 1; i <= 100; i++)
            {
                Asientos.Add(new Asiento
                {
                    AsientoId = i,
                });
            }

            return Asientos;

        }

            
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<AsientosObra>()
                .HasKey(o => new { o.ObraId, o.AsientoId });

            modelBuilder.Entity<AsientosObra>()
                .HasOne(o => o.Obra)
                .WithMany(p => p.ListAsientosObra)
                .HasForeignKey(pi => pi.ObraId);

            modelBuilder.Entity<AsientosObra>()
                .HasOne(a => a.Asiento)
                .WithMany(i => i.ListAsientosObra)
                .HasForeignKey(pi => pi.AsientoId);
            
modelBuilder.Entity<Obra>().HasData(
new Obra { ObraId = 1, Titulo = "Hamlet", Descripcion = "Una obra de Shakespeare.", Genero = "Drama", Imagen = "ruta imagen 1", Duracion = "120 mins", Director = "Andres Torres", Interpretes = "A.Torres, Cristian, Pablo.Pe, Ricardon, Albertos & Sofía", Fecha = new DateTime(2024, 03, 20, 20, 0, 0), Fecha_Estreno_1 = new DateTime(2024, 04, 08, 21, 0, 0), Fecha_Estreno_2 = new DateTime(2024, 05, 05, 22, 30, 0), Sala = 1, Valoracion = 4, Precio = 30},
new Obra { ObraId = 2, Titulo = "El Rey León", Descripcion = "Un musical épico.", Genero = "Musical", Imagen = "ruta imagen 2", Duracion = "150 mins", Director = "Mutombo Martinez", Interpretes = "Marta Soler, Luis Gomez, Ana Páez, Mario Ruiz", Fecha = new DateTime(2024, 03, 22, 21, 0, 0), Fecha_Estreno_1 = new DateTime(2024, 04, 15, 22, 30, 0), Fecha_Estreno_2 = new DateTime(2024, 05, 07, 21, 30, 0), Sala = 2, Valoracion = 5, Precio = 25},
new Obra { ObraId = 3, Titulo = "Romeo y Julieta", Descripcion = "El clásico de Shakespeare sobre dos amantes desafortunados.", Genero = "Tragedia", Imagen = "ruta imagen 3", Duracion = "130 mins", Director = "Carlos Vidal", Interpretes = "Elena Nuñez, Jorge Sanz", Fecha = new DateTime(2024, 03, 19, 22, 15, 0), Fecha_Estreno_1 = new DateTime(2024, 04, 09, 21, 30, 0), Fecha_Estreno_2 = new DateTime(2024, 05, 05, 22, 30, 0), Sala = 3, Valoracion = 4, Precio = 20},
new Obra { ObraId = 4, Titulo = "La Casa de Bernarda Alba", Descripcion = "Una representación intensa de la obra maestra de Federico García Lorca.", Genero = "Drama", Imagen = "ruta imagen 4", Duracion = "90 mins", Director = "Irene Moya", Interpretes = "Carmen Linares, Pilar Tena, Laura Ortega", Fecha = new DateTime(2024, 03, 20, 21, 0, 0), Fecha_Estreno_1 = new DateTime(2024, 04, 12, 21, 30, 0), Fecha_Estreno_2 = new DateTime(2024, 05, 08, 19, 30, 0), Sala = 4, Valoracion = 5, Precio = 30},
new Obra { ObraId = 5, Titulo = "Don Juan Tenorio", Descripcion = "Una obra clásica española, llena de romance y aventura.", Genero = "Drama", Imagen = "ruta imagen 5", Duracion = "110 mins", Director = "Roberto Gómez", Interpretes = "Juan Martínez, Clara Ros, Miguel Ángel Jiménez", Fecha = new DateTime(2024, 03, 22, 21, 0, 0), Fecha_Estreno_1 = new DateTime(2024, 04, 16, 22, 45, 0), Fecha_Estreno_2 = new DateTime(2024, 05, 17, 20, 30, 0), Sala = 3, Valoracion = 2, Precio = 20},
new Obra { ObraId = 6, Titulo = "Cats", Descripcion = "El famoso musical de Andrew Lloyd Webber que ha encantado a audiencias de todo el mundo.", Genero = "Musical", Imagen = "ruta imagen 6", Duracion = "140 mins", Director = "Mónica García", Interpretes = "Ana Belén, Luis Fonsi, Rosalía Vila", Fecha = new DateTime(2024, 03, 22, 21, 0, 0), Fecha_Estreno_1 = new DateTime(2024, 04, 18, 20, 0, 0), Fecha_Estreno_2 = new DateTime(2024, 05, 08, 22, 30, 0), Sala = 1, Valoracion = 5, Precio = 25},
new Obra { ObraId = 7, Titulo = "Les Misérables", Descripcion = "Un épico musical basado en la novela de Victor Hugo.", Genero = "Musical", Imagen = "ruta imagen 7", Duracion = "165 mins", Director = "Jaime Costa", Interpretes = "Pedro Fernández, Diana Navarro, Sergio Dalma", Fecha = new DateTime(2024, 03, 22, 21, 0, 0), Fecha_Estreno_1 = new DateTime(2024, 04, 15, 22, 30, 0), Fecha_Estreno_2 = new DateTime(2024, 05, 07, 21, 30, 0), Sala = 3, Valoracion = 3, Precio = 25},
new Obra { ObraId = 8, Titulo = "La Tempestad", Descripcion = "Una de las últimas obras maestras de Shakespeare, llena de magia y misterio.", Genero = "Comedia", Imagen = "ruta imagen 7", Duracion = "135 mins", Director = "Lucía Hernández", Interpretes = "Carlos Sánchez, Marta Rivera, Daniel López", Fecha = new DateTime(2024, 03, 23, 22, 0, 0), Fecha_Estreno_1 = new DateTime(2024, 04, 20, 21, 15, 0), Fecha_Estreno_2 = new DateTime(2024, 05, 14, 20, 30, 0), Sala = 3, Valoracion = 4, Precio = 20},
new Obra { ObraId = 9, Titulo = "West Side Story", Descripcion = "El clásico musical inspirado en Romeo y Julieta, ambientado en Nueva York de los años 50.", Genero = "Musical", Imagen = "ruta imagen 7", Duracion = "160 mins", Director = "Roberto Álvarez", Interpretes = "Ángela Ponce, Miguel Torres, Laura Jiménez", Fecha = new DateTime(2024, 03, 19, 20, 0, 0), Fecha_Estreno_1 = new DateTime(2024, 04, 16, 21, 30, 0), Fecha_Estreno_2 = new DateTime(2024, 05, 17, 20, 30, 0), Sala = 3, Valoracion = 3, Precio = 25},
new Obra { ObraId = 10, Titulo = "Phantom of the Opera", Descripcion = "Un espectacular musical basado en la novela de Gaston Leroux.", Genero = "Drama", Imagen = "ruta imagen 7", Duracion = "150 mins", Director = "Sofía Martín", Interpretes = "Javier Gómez, Raquel del Pozo, Mario Casas", Fecha = new DateTime(2024, 03, 21, 22, 45, 0), Fecha_Estreno_1 = new DateTime(2024, 04, 16, 22, 0, 0), Fecha_Estreno_2 = new DateTime(2024, 05, 28, 20, 30, 0), Sala = 4, Valoracion = 5, Precio = 30}

    
);

modelBuilder.Entity<Asiento>().HasData(

    new Asiento { AsientoId = 1, Reservado = false },
    new Asiento { AsientoId = 2, Reservado = false },
    new Asiento { AsientoId = 3, Reservado = false },
    new Asiento { AsientoId = 4, Reservado = false },
    new Asiento { AsientoId = 5, Reservado = false },
    new Asiento { AsientoId = 6, Reservado = false },
    new Asiento { AsientoId = 7, Reservado = false },
    new Asiento { AsientoId = 8, Reservado = false },
    new Asiento { AsientoId = 9, Reservado = false },
    new Asiento { AsientoId = 10, Reservado = false },
    new Asiento { AsientoId = 11, Reservado = false },
    new Asiento { AsientoId = 12, Reservado = false },
    new Asiento { AsientoId = 13, Reservado = false },
    new Asiento { AsientoId = 14, Reservado = false },
    new Asiento { AsientoId = 15, Reservado = false },
    new Asiento { AsientoId = 16, Reservado = false },
    new Asiento { AsientoId = 17, Reservado = false },
    new Asiento { AsientoId = 18, Reservado = false },
    new Asiento { AsientoId = 19, Reservado = false },
    new Asiento { AsientoId = 20, Reservado = false },
    new Asiento { AsientoId = 21, Reservado = false },
    new Asiento { AsientoId = 22, Reservado = false },
    new Asiento { AsientoId = 23, Reservado = false },
    new Asiento { AsientoId = 24, Reservado = false },
    new Asiento { AsientoId = 25, Reservado = false }
);

modelBuilder.Entity<AsientosObra>().HasData(
                CreateAsientosObra(1).ToList() // Crea una nueva Asiento con AsientoId = 1 y Reservado = false
            );




        }

        public DbSet<Obra> Obras {get; set;}

        public DbSet<Asiento> Asientos {get; set;}

        public DbSet<AsientosObra> AsientosObras {get; set;}

        public DbSet<Sesion> Sesiones {get; set;}

        public DbSet<User> Usuarios {get; set;}
    }
}