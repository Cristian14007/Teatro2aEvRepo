using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEnd.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Obras",
                columns: table => new
                {
                    ObraId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Imagen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duracion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Director = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Interpretes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Obras", x => x.ObraId);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Sesiones",
                columns: table => new
                {
                    SesionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ObraId = table.Column<int>(type: "int", nullable: false),
                    DiaSesion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HoraSesion = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sesiones", x => x.SesionId);
                    table.ForeignKey(
                        name: "FK_Sesiones_Obras_ObraId",
                        column: x => x.ObraId,
                        principalTable: "Obras",
                        principalColumn: "ObraId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Asientos",
                columns: table => new
                {
                    AsientoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Reservado = table.Column<bool>(type: "bit", nullable: false),
                    SesionId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asientos", x => x.AsientoId);
                    table.ForeignKey(
                        name: "FK_Asientos_Sesiones_SesionId",
                        column: x => x.SesionId,
                        principalTable: "Sesiones",
                        principalColumn: "SesionId");
                    table.ForeignKey(
                        name: "FK_Asientos_Usuarios_UserId",
                        column: x => x.UserId,
                        principalTable: "Usuarios",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "AsientosObras",
                columns: table => new
                {
                    ObraId = table.Column<int>(type: "int", nullable: false),
                    AsientoId = table.Column<int>(type: "int", nullable: false),
                    Asiento_Obra_Id = table.Column<int>(type: "int", nullable: false),
                    Reservado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AsientosObras", x => new { x.ObraId, x.AsientoId });
                    table.ForeignKey(
                        name: "FK_AsientosObras_Asientos_AsientoId",
                        column: x => x.AsientoId,
                        principalTable: "Asientos",
                        principalColumn: "AsientoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AsientosObras_Obras_ObraId",
                        column: x => x.ObraId,
                        principalTable: "Obras",
                        principalColumn: "ObraId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Asientos",
                columns: new[] { "AsientoId", "Reservado", "SesionId", "UserId" },
                values: new object[,]
                {
                    { 1, false, null, null },
                    { 2, false, null, null },
                    { 3, false, null, null },
                    { 4, false, null, null },
                    { 5, false, null, null },
                    { 6, false, null, null },
                    { 7, false, null, null },
                    { 8, false, null, null },
                    { 9, false, null, null },
                    { 10, false, null, null },
                    { 11, false, null, null },
                    { 12, false, null, null },
                    { 13, false, null, null },
                    { 14, false, null, null },
                    { 15, false, null, null },
                    { 16, false, null, null },
                    { 17, false, null, null },
                    { 18, false, null, null },
                    { 19, false, null, null },
                    { 20, false, null, null },
                    { 21, false, null, null },
                    { 22, false, null, null },
                    { 23, false, null, null },
                    { 24, false, null, null },
                    { 25, false, null, null }
                });

            migrationBuilder.InsertData(
                table: "Obras",
                columns: new[] { "ObraId", "Descripcion", "Director", "Duracion", "Genero", "Imagen", "Interpretes", "Titulo" },
                values: new object[,]
                {
                    { 1, "Una obra de Shakespeare.", "Andres Torres", "120 mins", "Drama", "ruta imagen 1", "A.Torres, Cristian, Pablo.Pe, Ricardon, Albertos & Sofía", "Hamlet" },
                    { 2, "Un musical épico.", "Mutombo Martinez", "150 mins", "Musical", "ruta imagen 2", "Marta Soler, Luis Gomez, Ana Páez, Mario Ruiz", "El Rey León" },
                    { 3, "El clásico de Shakespeare sobre dos amantes desafortunados.", "Carlos Vidal", "130 mins", "Tragedia", "ruta imagen 3", "Elena Nuñez, Jorge Sanz", "Romeo y Julieta" },
                    { 4, "Una representación intensa de la obra maestra de Federico García Lorca.", "Irene Moya", "90 mins", "Drama", "ruta imagen 4", "Carmen Linares, Pilar Tena, Laura Ortega", "La Casa de Bernarda Alba" },
                    { 5, "Una obra clásica española, llena de romance y aventura.", "Roberto Gómez", "110 mins", "Drama", "ruta imagen 5", "Juan Martínez, Clara Ros, Miguel Ángel Jiménez", "Don Juan Tenorio" },
                    { 6, "El famoso musical de Andrew Lloyd Webber que ha encantado a audiencias de todo el mundo.", "Mónica García", "140 mins", "Musical", "ruta imagen 6", "Ana Belén, Luis Fonsi, Rosalía Vila", "Cats" },
                    { 7, "Un épico musical basado en la novela de Victor Hugo.", "Jaime Costa", "165 mins", "Musical", "ruta imagen 7", "Pedro Fernández, Diana Navarro, Sergio Dalma", "Les Misérables" },
                    { 8, "Una de las últimas obras maestras de Shakespeare, llena de magia y misterio.", "Lucía Hernández", "135 mins", "Comedia", "ruta imagen 7", "Carlos Sánchez, Marta Rivera, Daniel López", "La Tempestad" },
                    { 9, "El clásico musical inspirado en Romeo y Julieta, ambientado en Nueva York de los años 50.", "Roberto Álvarez", "160 mins", "Musical", "ruta imagen 7", "Ángela Ponce, Miguel Torres, Laura Jiménez", "West Side Story" },
                    { 10, "Un espectacular musical basado en la novela de Gaston Leroux.", "Sofía Martín", "150 mins", "Drama", "ruta imagen 7", "Javier Gómez, Raquel del Pozo, Mario Casas", "Phantom of the Opera" }
                });

            migrationBuilder.InsertData(
                table: "AsientosObras",
                columns: new[] { "AsientoId", "ObraId", "Asiento_Obra_Id", "Reservado" },
                values: new object[,]
                {
                    { 1, 1, 0, false },
                    { 2, 1, 0, false },
                    { 3, 1, 0, false },
                    { 4, 1, 0, false },
                    { 5, 1, 0, false },
                    { 6, 1, 0, false },
                    { 7, 1, 0, false },
                    { 8, 1, 0, false },
                    { 9, 1, 0, false },
                    { 10, 1, 0, false },
                    { 11, 1, 0, false },
                    { 12, 1, 0, false },
                    { 13, 1, 0, false },
                    { 14, 1, 0, false },
                    { 15, 1, 0, false },
                    { 16, 1, 0, false },
                    { 17, 1, 0, false },
                    { 18, 1, 0, false },
                    { 19, 1, 0, false },
                    { 20, 1, 0, false },
                    { 21, 1, 0, false },
                    { 22, 1, 0, false },
                    { 23, 1, 0, false },
                    { 24, 1, 0, false },
                    { 25, 1, 0, false }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Asientos_SesionId",
                table: "Asientos",
                column: "SesionId");

            migrationBuilder.CreateIndex(
                name: "IX_Asientos_UserId",
                table: "Asientos",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AsientosObras_AsientoId",
                table: "AsientosObras",
                column: "AsientoId");

            migrationBuilder.CreateIndex(
                name: "IX_Sesiones_ObraId",
                table: "Sesiones",
                column: "ObraId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AsientosObras");

            migrationBuilder.DropTable(
                name: "Asientos");

            migrationBuilder.DropTable(
                name: "Sesiones");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Obras");
        }
    }
}
