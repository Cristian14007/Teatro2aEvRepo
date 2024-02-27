﻿// <auto-generated />
using System;
using BackEnd.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BackEnd.Data.Migrations
{
    [DbContext(typeof(ObraContext))]
    partial class ObraContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BackEnd.Models.Asiento", b =>
                {
                    b.Property<int>("AsientoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AsientoId"), 1L, 1);

                    b.Property<bool>("Reservado")
                        .HasColumnType("bit");

                    b.Property<int?>("SesionId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("AsientoId");

                    b.HasIndex("SesionId");

                    b.HasIndex("UserId");

                    b.ToTable("Asientos");

                    b.HasData(
                        new
                        {
                            AsientoId = 1,
                            Reservado = false
                        },
                        new
                        {
                            AsientoId = 2,
                            Reservado = false
                        },
                        new
                        {
                            AsientoId = 3,
                            Reservado = false
                        },
                        new
                        {
                            AsientoId = 4,
                            Reservado = false
                        },
                        new
                        {
                            AsientoId = 5,
                            Reservado = false
                        },
                        new
                        {
                            AsientoId = 6,
                            Reservado = false
                        },
                        new
                        {
                            AsientoId = 7,
                            Reservado = false
                        },
                        new
                        {
                            AsientoId = 8,
                            Reservado = false
                        },
                        new
                        {
                            AsientoId = 9,
                            Reservado = false
                        },
                        new
                        {
                            AsientoId = 10,
                            Reservado = false
                        },
                        new
                        {
                            AsientoId = 11,
                            Reservado = false
                        },
                        new
                        {
                            AsientoId = 12,
                            Reservado = false
                        },
                        new
                        {
                            AsientoId = 13,
                            Reservado = false
                        },
                        new
                        {
                            AsientoId = 14,
                            Reservado = false
                        },
                        new
                        {
                            AsientoId = 15,
                            Reservado = false
                        },
                        new
                        {
                            AsientoId = 16,
                            Reservado = false
                        },
                        new
                        {
                            AsientoId = 17,
                            Reservado = false
                        },
                        new
                        {
                            AsientoId = 18,
                            Reservado = false
                        },
                        new
                        {
                            AsientoId = 19,
                            Reservado = false
                        },
                        new
                        {
                            AsientoId = 20,
                            Reservado = false
                        },
                        new
                        {
                            AsientoId = 21,
                            Reservado = false
                        },
                        new
                        {
                            AsientoId = 22,
                            Reservado = false
                        },
                        new
                        {
                            AsientoId = 23,
                            Reservado = false
                        },
                        new
                        {
                            AsientoId = 24,
                            Reservado = false
                        },
                        new
                        {
                            AsientoId = 25,
                            Reservado = false
                        });
                });

            modelBuilder.Entity("BackEnd.Models.AsientosObra", b =>
                {
                    b.Property<int>("ObraId")
                        .HasColumnType("int");

                    b.Property<int>("AsientoId")
                        .HasColumnType("int");

                    b.Property<int>("Asiento_Obra_Id")
                        .HasColumnType("int");

                    b.Property<bool>("Reservado")
                        .HasColumnType("bit");

                    b.HasKey("ObraId", "AsientoId");

                    b.HasIndex("AsientoId");

                    b.ToTable("AsientosObras");

                    b.HasData(
                        new
                        {
                            ObraId = 1,
                            AsientoId = 1,
                            Asiento_Obra_Id = 0,
                            Reservado = false
                        },
                        new
                        {
                            ObraId = 1,
                            AsientoId = 2,
                            Asiento_Obra_Id = 0,
                            Reservado = false
                        },
                        new
                        {
                            ObraId = 1,
                            AsientoId = 3,
                            Asiento_Obra_Id = 0,
                            Reservado = false
                        },
                        new
                        {
                            ObraId = 1,
                            AsientoId = 4,
                            Asiento_Obra_Id = 0,
                            Reservado = false
                        },
                        new
                        {
                            ObraId = 1,
                            AsientoId = 5,
                            Asiento_Obra_Id = 0,
                            Reservado = false
                        },
                        new
                        {
                            ObraId = 1,
                            AsientoId = 6,
                            Asiento_Obra_Id = 0,
                            Reservado = false
                        },
                        new
                        {
                            ObraId = 1,
                            AsientoId = 7,
                            Asiento_Obra_Id = 0,
                            Reservado = false
                        },
                        new
                        {
                            ObraId = 1,
                            AsientoId = 8,
                            Asiento_Obra_Id = 0,
                            Reservado = false
                        },
                        new
                        {
                            ObraId = 1,
                            AsientoId = 9,
                            Asiento_Obra_Id = 0,
                            Reservado = false
                        },
                        new
                        {
                            ObraId = 1,
                            AsientoId = 10,
                            Asiento_Obra_Id = 0,
                            Reservado = false
                        },
                        new
                        {
                            ObraId = 1,
                            AsientoId = 11,
                            Asiento_Obra_Id = 0,
                            Reservado = false
                        },
                        new
                        {
                            ObraId = 1,
                            AsientoId = 12,
                            Asiento_Obra_Id = 0,
                            Reservado = false
                        },
                        new
                        {
                            ObraId = 1,
                            AsientoId = 13,
                            Asiento_Obra_Id = 0,
                            Reservado = false
                        },
                        new
                        {
                            ObraId = 1,
                            AsientoId = 14,
                            Asiento_Obra_Id = 0,
                            Reservado = false
                        },
                        new
                        {
                            ObraId = 1,
                            AsientoId = 15,
                            Asiento_Obra_Id = 0,
                            Reservado = false
                        },
                        new
                        {
                            ObraId = 1,
                            AsientoId = 16,
                            Asiento_Obra_Id = 0,
                            Reservado = false
                        },
                        new
                        {
                            ObraId = 1,
                            AsientoId = 17,
                            Asiento_Obra_Id = 0,
                            Reservado = false
                        },
                        new
                        {
                            ObraId = 1,
                            AsientoId = 18,
                            Asiento_Obra_Id = 0,
                            Reservado = false
                        },
                        new
                        {
                            ObraId = 1,
                            AsientoId = 19,
                            Asiento_Obra_Id = 0,
                            Reservado = false
                        },
                        new
                        {
                            ObraId = 1,
                            AsientoId = 20,
                            Asiento_Obra_Id = 0,
                            Reservado = false
                        },
                        new
                        {
                            ObraId = 1,
                            AsientoId = 21,
                            Asiento_Obra_Id = 0,
                            Reservado = false
                        },
                        new
                        {
                            ObraId = 1,
                            AsientoId = 22,
                            Asiento_Obra_Id = 0,
                            Reservado = false
                        },
                        new
                        {
                            ObraId = 1,
                            AsientoId = 23,
                            Asiento_Obra_Id = 0,
                            Reservado = false
                        },
                        new
                        {
                            ObraId = 1,
                            AsientoId = 24,
                            Asiento_Obra_Id = 0,
                            Reservado = false
                        },
                        new
                        {
                            ObraId = 1,
                            AsientoId = 25,
                            Asiento_Obra_Id = 0,
                            Reservado = false
                        });
                });

            modelBuilder.Entity("BackEnd.Models.Obra", b =>
                {
                    b.Property<int>("ObraId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ObraId"), 1L, 1);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Director")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Duracion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Genero")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Imagen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Interpretes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ObraId");

                    b.ToTable("Obras");

                    b.HasData(
                        new
                        {
                            ObraId = 1,
                            Descripcion = "Una obra de Shakespeare.",
                            Director = "Andres Torres",
                            Duracion = "120 mins",
                            Genero = "Drama",
                            Imagen = "ruta imagen 1",
                            Interpretes = "A.Torres, Cristian, Pablo.Pe, Ricardon, Albertos & Sofía",
                            Titulo = "Hamlet"
                        },
                        new
                        {
                            ObraId = 2,
                            Descripcion = "Un musical épico.",
                            Director = "Mutombo Martinez",
                            Duracion = "150 mins",
                            Genero = "Musical",
                            Imagen = "ruta imagen 2",
                            Interpretes = "Marta Soler, Luis Gomez, Ana Páez, Mario Ruiz",
                            Titulo = "El Rey León"
                        },
                        new
                        {
                            ObraId = 3,
                            Descripcion = "El clásico de Shakespeare sobre dos amantes desafortunados.",
                            Director = "Carlos Vidal",
                            Duracion = "130 mins",
                            Genero = "Tragedia",
                            Imagen = "ruta imagen 3",
                            Interpretes = "Elena Nuñez, Jorge Sanz",
                            Titulo = "Romeo y Julieta"
                        },
                        new
                        {
                            ObraId = 4,
                            Descripcion = "Una representación intensa de la obra maestra de Federico García Lorca.",
                            Director = "Irene Moya",
                            Duracion = "90 mins",
                            Genero = "Drama",
                            Imagen = "ruta imagen 4",
                            Interpretes = "Carmen Linares, Pilar Tena, Laura Ortega",
                            Titulo = "La Casa de Bernarda Alba"
                        },
                        new
                        {
                            ObraId = 5,
                            Descripcion = "Una obra clásica española, llena de romance y aventura.",
                            Director = "Roberto Gómez",
                            Duracion = "110 mins",
                            Genero = "Drama",
                            Imagen = "ruta imagen 5",
                            Interpretes = "Juan Martínez, Clara Ros, Miguel Ángel Jiménez",
                            Titulo = "Don Juan Tenorio"
                        },
                        new
                        {
                            ObraId = 6,
                            Descripcion = "El famoso musical de Andrew Lloyd Webber que ha encantado a audiencias de todo el mundo.",
                            Director = "Mónica García",
                            Duracion = "140 mins",
                            Genero = "Musical",
                            Imagen = "ruta imagen 6",
                            Interpretes = "Ana Belén, Luis Fonsi, Rosalía Vila",
                            Titulo = "Cats"
                        },
                        new
                        {
                            ObraId = 7,
                            Descripcion = "Un épico musical basado en la novela de Victor Hugo.",
                            Director = "Jaime Costa",
                            Duracion = "165 mins",
                            Genero = "Musical",
                            Imagen = "ruta imagen 7",
                            Interpretes = "Pedro Fernández, Diana Navarro, Sergio Dalma",
                            Titulo = "Les Misérables"
                        },
                        new
                        {
                            ObraId = 8,
                            Descripcion = "Una de las últimas obras maestras de Shakespeare, llena de magia y misterio.",
                            Director = "Lucía Hernández",
                            Duracion = "135 mins",
                            Genero = "Comedia",
                            Imagen = "ruta imagen 7",
                            Interpretes = "Carlos Sánchez, Marta Rivera, Daniel López",
                            Titulo = "La Tempestad"
                        },
                        new
                        {
                            ObraId = 9,
                            Descripcion = "El clásico musical inspirado en Romeo y Julieta, ambientado en Nueva York de los años 50.",
                            Director = "Roberto Álvarez",
                            Duracion = "160 mins",
                            Genero = "Musical",
                            Imagen = "ruta imagen 7",
                            Interpretes = "Ángela Ponce, Miguel Torres, Laura Jiménez",
                            Titulo = "West Side Story"
                        },
                        new
                        {
                            ObraId = 10,
                            Descripcion = "Un espectacular musical basado en la novela de Gaston Leroux.",
                            Director = "Sofía Martín",
                            Duracion = "150 mins",
                            Genero = "Drama",
                            Imagen = "ruta imagen 7",
                            Interpretes = "Javier Gómez, Raquel del Pozo, Mario Casas",
                            Titulo = "Phantom of the Opera"
                        });
                });

            modelBuilder.Entity("BackEnd.Models.Sesion", b =>
                {
                    b.Property<int>("SesionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SesionId"), 1L, 1);

                    b.Property<DateTime>("DiaSesion")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan>("HoraSesion")
                        .HasColumnType("time");

                    b.Property<int>("ObraId")
                        .HasColumnType("int");

                    b.HasKey("SesionId");

                    b.HasIndex("ObraId");

                    b.ToTable("Sesiones");
                });

            modelBuilder.Entity("BackEnd.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("BackEnd.Models.Asiento", b =>
                {
                    b.HasOne("BackEnd.Models.Sesion", null)
                        .WithMany("Asientos")
                        .HasForeignKey("SesionId");

                    b.HasOne("BackEnd.Models.User", null)
                        .WithMany("Asientos")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("BackEnd.Models.AsientosObra", b =>
                {
                    b.HasOne("BackEnd.Models.Asiento", "Asiento")
                        .WithMany("ListAsientosObra")
                        .HasForeignKey("AsientoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BackEnd.Models.Obra", "Obra")
                        .WithMany("ListAsientosObra")
                        .HasForeignKey("ObraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Asiento");

                    b.Navigation("Obra");
                });

            modelBuilder.Entity("BackEnd.Models.Sesion", b =>
                {
                    b.HasOne("BackEnd.Models.Obra", "Obra")
                        .WithMany()
                        .HasForeignKey("ObraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Obra");
                });

            modelBuilder.Entity("BackEnd.Models.Asiento", b =>
                {
                    b.Navigation("ListAsientosObra");
                });

            modelBuilder.Entity("BackEnd.Models.Obra", b =>
                {
                    b.Navigation("ListAsientosObra");
                });

            modelBuilder.Entity("BackEnd.Models.Sesion", b =>
                {
                    b.Navigation("Asientos");
                });

            modelBuilder.Entity("BackEnd.Models.User", b =>
                {
                    b.Navigation("Asientos");
                });
#pragma warning restore 612, 618
        }
    }
}
