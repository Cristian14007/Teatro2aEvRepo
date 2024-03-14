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
                name: "Estrenos",
                columns: table => new
                {
                    EstrenoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Imagen = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estrenos", x => x.EstrenoId);
                });

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
                    Interpretes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fecha_Estreno_1 = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fecha_Estreno_2 = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sala = table.Column<int>(type: "int", nullable: false),
                    Valoracion = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Obras", x => x.ObraId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
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
                    ObraId = table.Column<int>(type: "int", nullable: false),
                    Num_Asiento = table.Column<int>(type: "int", nullable: false),
                    SesionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asientos", x => x.AsientoId);
                    table.ForeignKey(
                        name: "FK_Asientos_Obras_ObraId",
                        column: x => x.ObraId,
                        principalTable: "Obras",
                        principalColumn: "ObraId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Asientos_Sesiones_SesionId",
                        column: x => x.SesionId,
                        principalTable: "Sesiones",
                        principalColumn: "SesionId");
                });

            migrationBuilder.InsertData(
                table: "Estrenos",
                columns: new[] { "EstrenoId", "Imagen", "Titulo" },
                values: new object[,]
                {
                    { 1, "admin@gmail.com", "Mary Poppins" },
                    { 2, "user1@gmail.com", "La Celestina" },
                    { 3, "user1@gmail.com", "Bodas de sangre" },
                    { 4, "user1@gmail.com", "Tributo a coldplay" }
                });

            migrationBuilder.InsertData(
                table: "Obras",
                columns: new[] { "ObraId", "Descripcion", "Director", "Duracion", "Fecha", "Fecha_Estreno_1", "Fecha_Estreno_2", "Genero", "Imagen", "Interpretes", "Precio", "Sala", "Titulo", "Valoracion" },
                values: new object[,]
                {
                    { 1, "Una obra de Shakespeare.", "Andres Torres", "120 mins", new DateTime(2024, 3, 20, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 8, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 5, 22, 30, 0, 0, DateTimeKind.Unspecified), "Drama", "ruta imagen 1", "A.Torres, Cristian, Pablo.Pe, Ricardon, Albertos & Sofía", 30, 1, "Hamlet", 4 },
                    { 2, "Un musical épico.", "Mutombo Martinez", "150 mins", new DateTime(2024, 3, 22, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 15, 22, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 7, 21, 30, 0, 0, DateTimeKind.Unspecified), "Musical", "ruta imagen 2", "Marta Soler, Luis Gomez, Ana Páez, Mario Ruiz", 25, 2, "El Rey León", 5 },
                    { 3, "El clásico de Shakespeare sobre dos amantes desafortunados.", "Carlos Vidal", "130 mins", new DateTime(2024, 3, 19, 22, 15, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 9, 21, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 5, 22, 30, 0, 0, DateTimeKind.Unspecified), "Tragedia", "ruta imagen 3", "Elena Nuñez, Jorge Sanz", 20, 3, "Romeo y Julieta", 4 },
                    { 4, "Una representación intensa de la obra maestra de Federico García Lorca.", "Irene Moya", "90 mins", new DateTime(2024, 3, 20, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 12, 21, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 8, 19, 30, 0, 0, DateTimeKind.Unspecified), "Drama", "ruta imagen 4", "Carmen Linares, Pilar Tena, Laura Ortega", 30, 4, "La Casa de Bernarda Alba", 5 },
                    { 5, "Una obra clásica española, llena de romance y aventura.", "Roberto Gómez", "110 mins", new DateTime(2024, 3, 22, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 16, 22, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 17, 20, 30, 0, 0, DateTimeKind.Unspecified), "Drama", "ruta imagen 5", "Juan Martínez, Clara Ros, Miguel Ángel Jiménez", 20, 3, "Don Juan Tenorio", 2 },
                    { 6, "El famoso musical de Andrew Lloyd Webber que ha encantado a audiencias de todo el mundo.", "Mónica García", "140 mins", new DateTime(2024, 3, 22, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 18, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 8, 22, 30, 0, 0, DateTimeKind.Unspecified), "Musical", "ruta imagen 6", "Ana Belén, Luis Fonsi, Rosalía Vila", 25, 1, "Cats", 5 },
                    { 7, "Un épico musical basado en la novela de Victor Hugo.", "Jaime Costa", "165 mins", new DateTime(2024, 3, 22, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 15, 22, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 7, 21, 30, 0, 0, DateTimeKind.Unspecified), "Musical", "ruta imagen 7", "Pedro Fernández, Diana Navarro, Sergio Dalma", 25, 3, "Les Misérables", 3 },
                    { 8, "Una de las últimas obras maestras de Shakespeare, llena de magia y misterio.", "Lucía Hernández", "135 mins", new DateTime(2024, 3, 23, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 20, 21, 15, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 14, 20, 30, 0, 0, DateTimeKind.Unspecified), "Comedia", "ruta imagen 7", "Carlos Sánchez, Marta Rivera, Daniel López", 20, 3, "La Tempestad", 4 },
                    { 9, "El clásico musical inspirado en Romeo y Julieta, ambientado en Nueva York de los años 50.", "Roberto Álvarez", "160 mins", new DateTime(2024, 3, 19, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 16, 21, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 17, 20, 30, 0, 0, DateTimeKind.Unspecified), "Musical", "ruta imagen 7", "Ángela Ponce, Miguel Torres, Laura Jiménez", 25, 3, "West Side Story", 3 },
                    { 10, "Un espectacular musical basado en la novela de Gaston Leroux.", "Sofía Martín", "150 mins", new DateTime(2024, 3, 21, 22, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 16, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 28, 20, 30, 0, 0, DateTimeKind.Unspecified), "Drama", "ruta imagen 7", "Javier Gómez, Raquel del Pozo, Mario Casas", 30, 4, "Phantom of the Opera", 5 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "Name", "Password" },
                values: new object[,]
                {
                    { 1, "admin@gmail.com", "Admin", "admin" },
                    { 2, "user1@gmail.com", "User1", "user1" }
                });

            migrationBuilder.InsertData(
                table: "Asientos",
                columns: new[] { "AsientoId", "Num_Asiento", "ObraId", "Reservado", "SesionId" },
                values: new object[,]
                {
                    { 1, 1, 1, false, null },
                    { 2, 2, 1, false, null },
                    { 3, 3, 1, false, null },
                    { 4, 4, 1, false, null },
                    { 5, 5, 1, false, null },
                    { 6, 6, 1, false, null },
                    { 7, 7, 1, false, null },
                    { 8, 8, 1, false, null },
                    { 9, 9, 1, false, null },
                    { 10, 10, 1, false, null },
                    { 11, 11, 1, false, null },
                    { 12, 12, 1, false, null },
                    { 13, 13, 1, false, null },
                    { 14, 14, 1, false, null },
                    { 15, 15, 1, false, null },
                    { 16, 16, 1, false, null },
                    { 17, 17, 1, false, null },
                    { 18, 18, 1, false, null },
                    { 19, 19, 1, false, null },
                    { 20, 20, 1, false, null },
                    { 21, 1, 2, false, null },
                    { 22, 2, 2, false, null },
                    { 23, 3, 2, false, null },
                    { 24, 4, 2, false, null },
                    { 25, 5, 2, false, null },
                    { 26, 6, 2, false, null },
                    { 27, 7, 2, false, null },
                    { 28, 8, 2, false, null },
                    { 29, 9, 2, false, null },
                    { 30, 10, 2, false, null },
                    { 31, 11, 2, false, null },
                    { 32, 12, 2, false, null },
                    { 33, 13, 2, false, null },
                    { 34, 14, 2, false, null },
                    { 35, 15, 2, false, null },
                    { 36, 16, 2, false, null },
                    { 37, 17, 2, false, null },
                    { 38, 18, 2, false, null },
                    { 39, 19, 2, false, null },
                    { 40, 20, 2, false, null },
                    { 41, 1, 3, false, null },
                    { 42, 2, 3, false, null }
                });

            migrationBuilder.InsertData(
                table: "Asientos",
                columns: new[] { "AsientoId", "Num_Asiento", "ObraId", "Reservado", "SesionId" },
                values: new object[,]
                {
                    { 43, 3, 3, false, null },
                    { 44, 4, 3, false, null },
                    { 45, 5, 3, false, null },
                    { 46, 6, 3, false, null },
                    { 47, 7, 3, false, null },
                    { 48, 8, 3, false, null },
                    { 49, 9, 3, false, null },
                    { 50, 10, 3, false, null },
                    { 51, 11, 3, false, null },
                    { 52, 12, 3, false, null },
                    { 53, 13, 3, false, null },
                    { 54, 14, 3, false, null },
                    { 55, 15, 3, false, null },
                    { 56, 16, 3, false, null },
                    { 57, 17, 3, false, null },
                    { 58, 18, 3, false, null },
                    { 59, 19, 3, false, null },
                    { 60, 20, 3, false, null },
                    { 61, 1, 4, false, null },
                    { 62, 2, 4, false, null },
                    { 63, 3, 4, false, null },
                    { 64, 4, 4, false, null },
                    { 65, 5, 4, false, null },
                    { 66, 6, 4, false, null },
                    { 67, 7, 4, false, null },
                    { 68, 8, 4, false, null },
                    { 69, 9, 4, false, null },
                    { 70, 10, 4, false, null },
                    { 71, 11, 4, false, null },
                    { 72, 12, 4, false, null },
                    { 73, 13, 4, false, null },
                    { 74, 14, 4, false, null },
                    { 75, 15, 4, false, null },
                    { 76, 16, 4, false, null },
                    { 77, 17, 4, false, null },
                    { 78, 18, 4, false, null },
                    { 79, 19, 4, false, null },
                    { 80, 20, 4, false, null },
                    { 81, 1, 5, false, null },
                    { 82, 2, 5, false, null },
                    { 83, 3, 5, false, null },
                    { 84, 4, 5, false, null }
                });

            migrationBuilder.InsertData(
                table: "Asientos",
                columns: new[] { "AsientoId", "Num_Asiento", "ObraId", "Reservado", "SesionId" },
                values: new object[,]
                {
                    { 85, 5, 5, false, null },
                    { 86, 6, 5, false, null },
                    { 87, 7, 5, false, null },
                    { 88, 8, 5, false, null },
                    { 89, 9, 5, false, null },
                    { 90, 10, 5, false, null },
                    { 91, 11, 5, false, null },
                    { 92, 12, 5, false, null },
                    { 93, 13, 5, false, null },
                    { 94, 14, 5, false, null },
                    { 95, 15, 5, false, null },
                    { 96, 16, 5, false, null },
                    { 97, 17, 5, false, null },
                    { 98, 18, 5, false, null },
                    { 99, 19, 5, false, null },
                    { 100, 20, 5, false, null },
                    { 101, 1, 6, false, null },
                    { 102, 2, 6, false, null },
                    { 103, 3, 6, false, null },
                    { 104, 4, 6, false, null },
                    { 105, 5, 6, false, null },
                    { 106, 6, 6, false, null },
                    { 107, 7, 6, false, null },
                    { 108, 8, 6, false, null },
                    { 109, 9, 6, false, null },
                    { 110, 10, 6, false, null },
                    { 111, 11, 6, false, null },
                    { 112, 12, 6, false, null },
                    { 113, 13, 6, false, null },
                    { 114, 14, 6, false, null },
                    { 115, 15, 6, false, null },
                    { 116, 16, 6, false, null },
                    { 117, 17, 6, false, null },
                    { 118, 18, 6, false, null },
                    { 119, 19, 6, false, null },
                    { 120, 20, 6, false, null },
                    { 121, 1, 7, false, null },
                    { 122, 2, 7, false, null },
                    { 123, 3, 7, false, null },
                    { 124, 4, 7, false, null },
                    { 125, 5, 7, false, null },
                    { 126, 6, 7, false, null }
                });

            migrationBuilder.InsertData(
                table: "Asientos",
                columns: new[] { "AsientoId", "Num_Asiento", "ObraId", "Reservado", "SesionId" },
                values: new object[,]
                {
                    { 127, 7, 7, false, null },
                    { 128, 8, 7, false, null },
                    { 129, 9, 7, false, null },
                    { 130, 10, 7, false, null },
                    { 131, 11, 7, false, null },
                    { 132, 12, 7, false, null },
                    { 133, 13, 7, false, null },
                    { 134, 14, 7, false, null },
                    { 135, 15, 7, false, null },
                    { 136, 16, 7, false, null },
                    { 137, 17, 7, false, null },
                    { 138, 18, 7, false, null },
                    { 139, 19, 7, false, null },
                    { 140, 20, 7, false, null },
                    { 141, 1, 8, false, null },
                    { 142, 2, 8, false, null },
                    { 143, 3, 8, false, null },
                    { 144, 4, 8, false, null },
                    { 145, 5, 8, false, null },
                    { 146, 6, 8, false, null },
                    { 147, 7, 8, false, null },
                    { 148, 8, 8, false, null },
                    { 149, 9, 8, false, null },
                    { 150, 10, 8, false, null },
                    { 151, 11, 8, false, null },
                    { 152, 12, 8, false, null },
                    { 153, 13, 8, false, null },
                    { 154, 14, 8, false, null },
                    { 155, 15, 8, false, null },
                    { 156, 16, 8, false, null },
                    { 157, 17, 8, false, null },
                    { 158, 18, 8, false, null },
                    { 159, 19, 8, false, null },
                    { 160, 20, 8, false, null },
                    { 161, 1, 9, false, null },
                    { 162, 2, 9, false, null },
                    { 163, 3, 9, false, null },
                    { 164, 4, 9, false, null },
                    { 165, 5, 9, false, null },
                    { 166, 6, 9, false, null },
                    { 167, 7, 9, false, null },
                    { 168, 8, 9, false, null }
                });

            migrationBuilder.InsertData(
                table: "Asientos",
                columns: new[] { "AsientoId", "Num_Asiento", "ObraId", "Reservado", "SesionId" },
                values: new object[,]
                {
                    { 169, 9, 9, false, null },
                    { 170, 10, 9, false, null },
                    { 171, 11, 9, false, null },
                    { 172, 12, 9, false, null },
                    { 173, 13, 9, false, null },
                    { 174, 14, 9, false, null },
                    { 175, 15, 9, false, null },
                    { 176, 16, 9, false, null },
                    { 177, 17, 9, false, null },
                    { 178, 18, 9, false, null },
                    { 179, 19, 9, false, null },
                    { 180, 20, 9, false, null },
                    { 181, 1, 10, false, null },
                    { 182, 2, 10, false, null },
                    { 183, 3, 10, false, null },
                    { 184, 4, 10, false, null },
                    { 185, 5, 10, false, null },
                    { 186, 6, 10, false, null },
                    { 187, 7, 10, false, null },
                    { 188, 8, 10, false, null },
                    { 189, 9, 10, false, null },
                    { 190, 10, 10, false, null },
                    { 191, 11, 10, false, null },
                    { 192, 12, 10, false, null },
                    { 193, 13, 10, false, null },
                    { 194, 14, 10, false, null },
                    { 195, 15, 10, false, null },
                    { 196, 16, 10, false, null },
                    { 197, 17, 10, false, null },
                    { 198, 18, 10, false, null },
                    { 199, 19, 10, false, null },
                    { 200, 20, 10, false, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Asientos_ObraId",
                table: "Asientos",
                column: "ObraId");

            migrationBuilder.CreateIndex(
                name: "IX_Asientos_SesionId",
                table: "Asientos",
                column: "SesionId");

            migrationBuilder.CreateIndex(
                name: "IX_Sesiones_ObraId",
                table: "Sesiones",
                column: "ObraId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Asientos");

            migrationBuilder.DropTable(
                name: "Estrenos");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Sesiones");

            migrationBuilder.DropTable(
                name: "Obras");
        }
    }
}
