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

        
        /* public List<AsientosObra> CreateAsientosObra(int obraId)
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
        } */

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

            modelBuilder.Entity<Obra>()
            .HasMany(o => o.Asientos)
            .WithOne(a => a.Obra)
            .HasForeignKey(a => a.ObraId);

            modelBuilder.Entity<User>()
                .HasKey(u => new { u.UserId });

            modelBuilder.Entity<Estreno>()
             .HasKey(e => new { e.EstrenoId });

            
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

    new Asiento { AsientoId = 1, Reservado = false, ObraId = 1, Num_Asiento = 1},
    new Asiento { AsientoId = 2, Reservado = false, ObraId = 1, Num_Asiento = 2},
    new Asiento { AsientoId = 3, Reservado = false, ObraId = 1, Num_Asiento = 3},
    new Asiento { AsientoId = 4, Reservado = false, ObraId = 1, Num_Asiento = 4 },
    new Asiento { AsientoId = 5, Reservado = false, ObraId = 1, Num_Asiento = 5 },
    new Asiento { AsientoId = 6, Reservado = false, ObraId = 1, Num_Asiento = 6 },
    new Asiento { AsientoId = 7, Reservado = false, ObraId = 1, Num_Asiento = 7 },
    new Asiento { AsientoId = 8, Reservado = false, ObraId = 1, Num_Asiento = 8 },
    new Asiento { AsientoId = 9, Reservado = false, ObraId = 1, Num_Asiento = 9 },
    new Asiento { AsientoId = 10, Reservado = false, ObraId = 1, Num_Asiento = 10 },
    new Asiento { AsientoId = 11, Reservado = false, ObraId = 1, Num_Asiento = 11 },
    new Asiento { AsientoId = 12, Reservado = false, ObraId = 1, Num_Asiento = 12 },
    new Asiento { AsientoId = 13, Reservado = false, ObraId = 1, Num_Asiento = 13 },
    new Asiento { AsientoId = 14, Reservado = false, ObraId = 1, Num_Asiento = 14 },
    new Asiento { AsientoId = 15, Reservado = false, ObraId = 1, Num_Asiento = 15 },
    new Asiento { AsientoId = 16, Reservado = false, ObraId = 1, Num_Asiento = 16 },
    new Asiento { AsientoId = 17, Reservado = false, ObraId = 1, Num_Asiento = 17 },
    new Asiento { AsientoId = 18, Reservado = false, ObraId = 1, Num_Asiento = 18 },
    new Asiento { AsientoId = 19, Reservado = false, ObraId = 1, Num_Asiento = 19 },
    new Asiento { AsientoId = 20, Reservado = false, ObraId = 1, Num_Asiento = 20 },
    new Asiento { AsientoId = 21, Reservado = false, ObraId = 2, Num_Asiento = 1 },
    new Asiento { AsientoId = 22, Reservado = false, ObraId = 2, Num_Asiento = 2 },
    new Asiento { AsientoId = 23, Reservado = false, ObraId = 2, Num_Asiento = 3 },
    new Asiento { AsientoId = 24, Reservado = false, ObraId = 2, Num_Asiento = 4 },
    new Asiento { AsientoId = 25, Reservado = false, ObraId = 2, Num_Asiento = 5 },
    new Asiento { AsientoId = 26, Reservado = false, ObraId = 2, Num_Asiento = 6 },
    new Asiento { AsientoId = 27, Reservado = false, ObraId = 2, Num_Asiento = 7 },
    new Asiento { AsientoId = 28, Reservado = false, ObraId = 2, Num_Asiento = 8 },
    new Asiento { AsientoId = 29, Reservado = false, ObraId = 2, Num_Asiento = 9 },
    new Asiento { AsientoId = 30, Reservado = false, ObraId = 2, Num_Asiento = 10 },
    new Asiento { AsientoId = 31, Reservado = false, ObraId = 2, Num_Asiento = 11 },
    new Asiento { AsientoId = 32, Reservado = false, ObraId = 2, Num_Asiento = 12 },
    new Asiento { AsientoId = 33, Reservado = false, ObraId = 2, Num_Asiento = 13 },
    new Asiento { AsientoId = 34, Reservado = false, ObraId = 2, Num_Asiento = 14 },
    new Asiento { AsientoId = 35, Reservado = false, ObraId = 2, Num_Asiento = 15 },
    new Asiento { AsientoId = 36, Reservado = false, ObraId = 2, Num_Asiento = 16 },
    new Asiento { AsientoId = 37, Reservado = false, ObraId = 2, Num_Asiento = 17 },
    new Asiento { AsientoId = 38, Reservado = false, ObraId = 2, Num_Asiento = 18 },
    new Asiento { AsientoId = 39, Reservado = false, ObraId = 2, Num_Asiento = 19 },
    new Asiento { AsientoId = 40, Reservado = false, ObraId = 2, Num_Asiento = 20 },
    new Asiento { AsientoId = 41, Reservado = false, ObraId = 3, Num_Asiento = 1 },
    new Asiento { AsientoId = 42, Reservado = false, ObraId = 3, Num_Asiento = 2 },
    new Asiento { AsientoId = 43, Reservado = false, ObraId = 3, Num_Asiento = 3 },
    new Asiento { AsientoId = 44, Reservado = false, ObraId = 3, Num_Asiento = 4 },
    new Asiento { AsientoId = 45, Reservado = false, ObraId = 3, Num_Asiento = 5 },
    new Asiento { AsientoId = 46, Reservado = false, ObraId = 3, Num_Asiento = 6 },
    new Asiento { AsientoId = 47, Reservado = false, ObraId = 3, Num_Asiento = 7 },
    new Asiento { AsientoId = 48, Reservado = false, ObraId = 3, Num_Asiento = 8 },
    new Asiento { AsientoId = 49, Reservado = false, ObraId = 3, Num_Asiento = 9 },
    new Asiento { AsientoId = 50, Reservado = false, ObraId = 3, Num_Asiento = 10 },
    new Asiento { AsientoId = 51, Reservado = false, ObraId = 3, Num_Asiento = 11 },
    new Asiento { AsientoId = 52, Reservado = false, ObraId = 3, Num_Asiento = 12 },
    new Asiento { AsientoId = 53, Reservado = false, ObraId = 3, Num_Asiento = 13 },
    new Asiento { AsientoId = 54, Reservado = false, ObraId = 3, Num_Asiento = 14 },
    new Asiento { AsientoId = 55, Reservado = false, ObraId = 3, Num_Asiento = 15 },
    new Asiento { AsientoId = 56, Reservado = false, ObraId = 3, Num_Asiento = 16 },
    new Asiento { AsientoId = 57, Reservado = false, ObraId = 3, Num_Asiento = 17 },
    new Asiento { AsientoId = 58, Reservado = false, ObraId = 3, Num_Asiento = 18 },
    new Asiento { AsientoId = 59, Reservado = false, ObraId = 3, Num_Asiento = 19 },
    new Asiento { AsientoId = 60, Reservado = false, ObraId = 3, Num_Asiento = 20 },
    new Asiento { AsientoId = 61, Reservado = false, ObraId = 4, Num_Asiento = 1 },
    new Asiento { AsientoId = 62, Reservado = false, ObraId = 4, Num_Asiento = 2 },
    new Asiento { AsientoId = 63, Reservado = false, ObraId = 4, Num_Asiento = 3 },
    new Asiento { AsientoId = 64, Reservado = false, ObraId = 4, Num_Asiento = 4 },
    new Asiento { AsientoId = 65, Reservado = false, ObraId = 4, Num_Asiento = 5 },
    new Asiento { AsientoId = 66, Reservado = false, ObraId = 4, Num_Asiento = 6 },
    new Asiento { AsientoId = 67, Reservado = false, ObraId = 4, Num_Asiento = 7 },
    new Asiento { AsientoId = 68, Reservado = false, ObraId = 4, Num_Asiento = 8 },
    new Asiento { AsientoId = 69, Reservado = false, ObraId = 4, Num_Asiento = 9 },
    new Asiento { AsientoId = 70, Reservado = false, ObraId = 4, Num_Asiento = 10 },
    new Asiento { AsientoId = 71, Reservado = false, ObraId = 4, Num_Asiento = 11 },
    new Asiento { AsientoId = 72, Reservado = false, ObraId = 4, Num_Asiento = 12 },
    new Asiento { AsientoId = 73, Reservado = false, ObraId = 4, Num_Asiento = 13 },
    new Asiento { AsientoId = 74, Reservado = false, ObraId = 4, Num_Asiento = 14 },
    new Asiento { AsientoId = 75, Reservado = false, ObraId = 4, Num_Asiento = 15 },
    new Asiento { AsientoId = 76, Reservado = false, ObraId = 4, Num_Asiento = 16 },
    new Asiento { AsientoId = 77, Reservado = false, ObraId = 4, Num_Asiento = 17 },
    new Asiento { AsientoId = 78, Reservado = false, ObraId = 4, Num_Asiento = 18 },
    new Asiento { AsientoId = 79, Reservado = false, ObraId = 4, Num_Asiento = 19 },
    new Asiento { AsientoId = 80, Reservado = false, ObraId = 4, Num_Asiento = 20 },
    new Asiento { AsientoId = 81, Reservado = false, ObraId = 5, Num_Asiento = 1 },
    new Asiento { AsientoId = 82, Reservado = false, ObraId = 5, Num_Asiento = 2 },
    new Asiento { AsientoId = 83, Reservado = false, ObraId = 5, Num_Asiento = 3 },
    new Asiento { AsientoId = 84, Reservado = false, ObraId = 5, Num_Asiento = 4 },
    new Asiento { AsientoId = 85, Reservado = false, ObraId = 5, Num_Asiento = 5 },
    new Asiento { AsientoId = 86, Reservado = false, ObraId = 5, Num_Asiento = 6 },
    new Asiento { AsientoId = 87, Reservado = false, ObraId = 5, Num_Asiento = 7 },
    new Asiento { AsientoId = 88, Reservado = false, ObraId = 5, Num_Asiento = 8 },
    new Asiento { AsientoId = 89, Reservado = false, ObraId = 5, Num_Asiento = 9 },
    new Asiento { AsientoId = 90, Reservado = false, ObraId = 5, Num_Asiento = 10 },
    new Asiento { AsientoId = 91, Reservado = false, ObraId = 5, Num_Asiento = 11 },
    new Asiento { AsientoId = 92, Reservado = false, ObraId = 5, Num_Asiento = 12 },
    new Asiento { AsientoId = 93, Reservado = false, ObraId = 5, Num_Asiento = 13 },
    new Asiento { AsientoId = 94, Reservado = false, ObraId = 5, Num_Asiento = 14 },
    new Asiento { AsientoId = 95, Reservado = false, ObraId = 5, Num_Asiento = 15 },
    new Asiento { AsientoId = 96, Reservado = false, ObraId = 5, Num_Asiento = 16 },
    new Asiento { AsientoId = 97, Reservado = false, ObraId = 5, Num_Asiento = 17 },
    new Asiento { AsientoId = 98, Reservado = false, ObraId = 5, Num_Asiento = 18 },
    new Asiento { AsientoId = 99, Reservado = false, ObraId = 5, Num_Asiento = 19 },
    new Asiento { AsientoId = 100, Reservado = false, ObraId = 5, Num_Asiento = 20 },
    new Asiento { AsientoId = 101, Reservado = false, ObraId = 6, Num_Asiento = 1 },
    new Asiento { AsientoId = 102, Reservado = false, ObraId = 6, Num_Asiento = 2 },
    new Asiento { AsientoId = 103, Reservado = false, ObraId = 6, Num_Asiento = 3 },
    new Asiento { AsientoId = 104, Reservado = false, ObraId = 6, Num_Asiento = 4 },
    new Asiento { AsientoId = 105, Reservado = false, ObraId = 6, Num_Asiento = 5 },
    new Asiento { AsientoId = 106, Reservado = false, ObraId = 6, Num_Asiento = 6 },
    new Asiento { AsientoId = 107, Reservado = false, ObraId = 6, Num_Asiento = 7 },
    new Asiento { AsientoId = 108, Reservado = false, ObraId = 6, Num_Asiento = 8 },
    new Asiento { AsientoId = 109, Reservado = false, ObraId = 6, Num_Asiento = 9 },
    new Asiento { AsientoId = 110, Reservado = false, ObraId = 6, Num_Asiento = 10 },
    new Asiento { AsientoId = 111, Reservado = false, ObraId = 6, Num_Asiento = 11 },
    new Asiento { AsientoId = 112, Reservado = false, ObraId = 6, Num_Asiento = 12 },
    new Asiento { AsientoId = 113, Reservado = false, ObraId = 6, Num_Asiento = 13 },
    new Asiento { AsientoId = 114, Reservado = false, ObraId = 6, Num_Asiento = 14 },
    new Asiento { AsientoId = 115, Reservado = false, ObraId = 6, Num_Asiento = 15 },
    new Asiento { AsientoId = 116, Reservado = false, ObraId = 6, Num_Asiento = 16 },
    new Asiento { AsientoId = 117, Reservado = false, ObraId = 6, Num_Asiento = 17 },
    new Asiento { AsientoId = 118, Reservado = false, ObraId = 6, Num_Asiento = 18 },
    new Asiento { AsientoId = 119, Reservado = false, ObraId = 6, Num_Asiento = 19 },
    new Asiento { AsientoId = 120, Reservado = false, ObraId = 6, Num_Asiento = 20 },
    new Asiento { AsientoId = 121, Reservado = false, ObraId = 7, Num_Asiento = 1 },
    new Asiento { AsientoId = 122, Reservado = false, ObraId = 7, Num_Asiento = 2 },
    new Asiento { AsientoId = 123, Reservado = false, ObraId = 7, Num_Asiento = 3 },
    new Asiento { AsientoId = 124, Reservado = false, ObraId = 7, Num_Asiento = 4 },
    new Asiento { AsientoId = 125, Reservado = false, ObraId = 7, Num_Asiento = 5 },
    new Asiento { AsientoId = 126, Reservado = false, ObraId = 7, Num_Asiento = 6 },
    new Asiento { AsientoId = 127, Reservado = false, ObraId = 7, Num_Asiento = 7 },
    new Asiento { AsientoId = 128, Reservado = false, ObraId = 7, Num_Asiento = 8 },
    new Asiento { AsientoId = 129, Reservado = false, ObraId = 7, Num_Asiento = 9 },
    new Asiento { AsientoId = 130, Reservado = false, ObraId = 7, Num_Asiento = 10 },
    new Asiento { AsientoId = 131, Reservado = false, ObraId = 7, Num_Asiento = 11 },
    new Asiento { AsientoId = 132, Reservado = false, ObraId = 7, Num_Asiento = 12 },
    new Asiento { AsientoId = 133, Reservado = false, ObraId = 7, Num_Asiento = 13 },
    new Asiento { AsientoId = 134, Reservado = false, ObraId = 7, Num_Asiento = 14 },
    new Asiento { AsientoId = 135, Reservado = false, ObraId = 7, Num_Asiento = 15 },
    new Asiento { AsientoId = 136, Reservado = false, ObraId = 7, Num_Asiento = 16 },
    new Asiento { AsientoId = 137, Reservado = false, ObraId = 7, Num_Asiento = 17 },
    new Asiento { AsientoId = 138, Reservado = false, ObraId = 7, Num_Asiento = 18 },
    new Asiento { AsientoId = 139, Reservado = false, ObraId = 7, Num_Asiento = 19 },
    new Asiento { AsientoId = 140, Reservado = false, ObraId = 7, Num_Asiento = 20 },
    new Asiento { AsientoId = 141, Reservado = false, ObraId = 8, Num_Asiento = 1 },
    new Asiento { AsientoId = 142, Reservado = false, ObraId = 8, Num_Asiento = 2 },
    new Asiento { AsientoId = 143, Reservado = false, ObraId = 8, Num_Asiento = 3 },
    new Asiento { AsientoId = 144, Reservado = false, ObraId = 8, Num_Asiento = 4 },
    new Asiento { AsientoId = 145, Reservado = false, ObraId = 8, Num_Asiento = 5 },
    new Asiento { AsientoId = 146, Reservado = false, ObraId = 8, Num_Asiento = 6 },
    new Asiento { AsientoId = 147, Reservado = false, ObraId = 8, Num_Asiento = 7 },
    new Asiento { AsientoId = 148, Reservado = false, ObraId = 8, Num_Asiento = 8 },
    new Asiento { AsientoId = 149, Reservado = false, ObraId = 8, Num_Asiento = 9 },
    new Asiento { AsientoId = 150, Reservado = false, ObraId = 8, Num_Asiento = 10 },
    new Asiento { AsientoId = 151, Reservado = false, ObraId = 8, Num_Asiento = 11 },
    new Asiento { AsientoId = 152, Reservado = false, ObraId = 8, Num_Asiento = 12 },
    new Asiento { AsientoId = 153, Reservado = false, ObraId = 8, Num_Asiento = 13 },
    new Asiento { AsientoId = 154, Reservado = false, ObraId = 8, Num_Asiento = 14 },
    new Asiento { AsientoId = 155, Reservado = false, ObraId = 8, Num_Asiento = 15 },
    new Asiento { AsientoId = 156, Reservado = false, ObraId = 8, Num_Asiento = 16 },
    new Asiento { AsientoId = 157, Reservado = false, ObraId = 8, Num_Asiento = 17 },
    new Asiento { AsientoId = 158, Reservado = false, ObraId = 8, Num_Asiento = 18 },
    new Asiento { AsientoId = 159, Reservado = false, ObraId = 8, Num_Asiento = 19 },
    new Asiento { AsientoId = 160, Reservado = false, ObraId = 8, Num_Asiento = 20 },
    new Asiento { AsientoId = 161, Reservado = false, ObraId = 9, Num_Asiento = 1 },
    new Asiento { AsientoId = 162, Reservado = false, ObraId = 9, Num_Asiento = 2 },
    new Asiento { AsientoId = 163, Reservado = false, ObraId = 9, Num_Asiento = 3 },
    new Asiento { AsientoId = 164, Reservado = false, ObraId = 9, Num_Asiento = 4 },
    new Asiento { AsientoId = 165, Reservado = false, ObraId = 9, Num_Asiento = 5 },
    new Asiento { AsientoId = 166, Reservado = false, ObraId = 9, Num_Asiento = 6 },
    new Asiento { AsientoId = 167, Reservado = false, ObraId = 9, Num_Asiento = 7 },
    new Asiento { AsientoId = 168, Reservado = false, ObraId = 9, Num_Asiento = 8 },
    new Asiento { AsientoId = 169, Reservado = false, ObraId = 9, Num_Asiento = 9 },
    new Asiento { AsientoId = 170, Reservado = false, ObraId = 9, Num_Asiento = 10 },
    new Asiento { AsientoId = 171, Reservado = false, ObraId = 9, Num_Asiento = 11 },
    new Asiento { AsientoId = 172, Reservado = false, ObraId = 9, Num_Asiento = 12 },
    new Asiento { AsientoId = 173, Reservado = false, ObraId = 9, Num_Asiento = 13 },
    new Asiento { AsientoId = 174, Reservado = false, ObraId = 9, Num_Asiento = 14 },
    new Asiento { AsientoId = 175, Reservado = false, ObraId = 9, Num_Asiento = 15 },
    new Asiento { AsientoId = 176, Reservado = false, ObraId = 9, Num_Asiento = 16 },
    new Asiento { AsientoId = 177, Reservado = false, ObraId = 9, Num_Asiento = 17 },
    new Asiento { AsientoId = 178, Reservado = false, ObraId = 9, Num_Asiento = 18 },
    new Asiento { AsientoId = 179, Reservado = false, ObraId = 9, Num_Asiento = 19 },
    new Asiento { AsientoId = 180, Reservado = false, ObraId = 9, Num_Asiento = 20 },
    new Asiento { AsientoId = 181, Reservado = false, ObraId = 10, Num_Asiento = 1 },
    new Asiento { AsientoId = 182, Reservado = false, ObraId = 10, Num_Asiento = 2 },
    new Asiento { AsientoId = 183, Reservado = false, ObraId = 10, Num_Asiento = 3 },
    new Asiento { AsientoId = 184, Reservado = false, ObraId = 10, Num_Asiento = 4 },
    new Asiento { AsientoId = 185, Reservado = false, ObraId = 10, Num_Asiento = 5 },
    new Asiento { AsientoId = 186, Reservado = false, ObraId = 10, Num_Asiento = 6 },
    new Asiento { AsientoId = 187, Reservado = false, ObraId = 10, Num_Asiento = 7 },
    new Asiento { AsientoId = 188, Reservado = false, ObraId = 10, Num_Asiento = 8 },
    new Asiento { AsientoId = 189, Reservado = false, ObraId = 10, Num_Asiento = 9 },
    new Asiento { AsientoId = 190, Reservado = false, ObraId = 10, Num_Asiento = 10 },
    new Asiento { AsientoId = 191, Reservado = false, ObraId = 10, Num_Asiento = 11 },
    new Asiento { AsientoId = 192, Reservado = false, ObraId = 10, Num_Asiento = 12 },
    new Asiento { AsientoId = 193, Reservado = false, ObraId = 10, Num_Asiento = 13 },
    new Asiento { AsientoId = 194, Reservado = false, ObraId = 10, Num_Asiento = 14 },
    new Asiento { AsientoId = 195, Reservado = false, ObraId = 10, Num_Asiento = 15 },
    new Asiento { AsientoId = 196, Reservado = false, ObraId = 10, Num_Asiento = 16 },
    new Asiento { AsientoId = 197, Reservado = false, ObraId = 10, Num_Asiento = 17 },
    new Asiento { AsientoId = 198, Reservado = false, ObraId = 10, Num_Asiento = 18 },
    new Asiento { AsientoId = 199, Reservado = false, ObraId = 10, Num_Asiento = 19 },
    new Asiento { AsientoId = 200, Reservado = false, ObraId = 10, Num_Asiento = 20 }


);

/* modelBuilder.Entity<AsientosObra>().HasData(
                CreateAsientosObra(1).ToList() // Crea una nueva Asiento con AsientoId = 1 y Reservado = false
            ); */

modelBuilder.Entity<User>().HasData(
                new User { UserId = 1, Name = "Admin", Email = "admin@gmail.com", Password = "admin" },
                new User { UserId = 2, Name = "User1", Email = "user1@gmail.com", Password = "user1" }
            );

modelBuilder.Entity<Estreno>().HasData(
                new Estreno { EstrenoId = 1, Titulo = "Mary Poppins", Imagen = "admin@gmail.com" },
                new Estreno { EstrenoId = 2, Titulo = "La Celestina", Imagen = "user1@gmail.com" },
                 new Estreno { EstrenoId = 3, Titulo = "Bodas de sangre", Imagen = "user1@gmail.com" },
                  new Estreno { EstrenoId = 4, Titulo = "Tributo a coldplay", Imagen = "user1@gmail.com" }
            );

        }

        public DbSet<Obra> Obras {get; set;}

        public DbSet<Asiento> Asientos {get; set;}

        //public DbSet<AsientosObra> AsientosObras {get; set;}

        public DbSet<Sesion> Sesiones {get; set;}

        public DbSet<User> Users { get; set;}

        public DbSet<Estreno> Estrenos { get; set;}
    }
}