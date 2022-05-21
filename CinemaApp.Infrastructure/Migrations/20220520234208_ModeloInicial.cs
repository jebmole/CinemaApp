using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaApp.Infrastructure.Migrations
{
    public partial class ModeloInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    IdCliente = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    Nombres = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Apellidos = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Email = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Celular = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.IdCliente);
                });

            migrationBuilder.CreateTable(
                name: "Pelicula",
                columns: table => new
                {
                    IdPelicula = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    Sinopsis = table.Column<string>(unicode: false, maxLength: 500, nullable: false),
                    Duracion = table.Column<int>(nullable: false),
                    Director = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    ActorPrincipal = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    Disponible = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pelicula", x => x.IdPelicula);
                });

            migrationBuilder.CreateTable(
                name: "Sala",
                columns: table => new
                {
                    IdSala = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nomenclatura = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Capacidad = table.Column<int>(nullable: false),
                    EsDinamix = table.Column<bool>(nullable: false),
                    Activa = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sala", x => x.IdSala);
                });

            migrationBuilder.CreateTable(
                name: "Funcion",
                columns: table => new
                {
                    IdFuncion = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPelicula = table.Column<int>(nullable: false),
                    IdSala = table.Column<int>(nullable: false),
                    Fecha = table.Column<DateTime>(type: "date", nullable: false),
                    HoraInicio = table.Column<TimeSpan>(nullable: false),
                    HoraFin = table.Column<TimeSpan>(nullable: false),
                    CapacidadMaxima = table.Column<int>(nullable: false),
                    AsientosDisponibles = table.Column<int>(nullable: false),
                    PrecioBoleta = table.Column<decimal>(type: "decimal(18, 0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcion", x => x.IdFuncion);
                    table.ForeignKey(
                        name: "FK_Funcion_Pelicula",
                        column: x => x.IdPelicula,
                        principalTable: "Pelicula",
                        principalColumn: "IdPelicula",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Funcion_Sala",
                        column: x => x.IdSala,
                        principalTable: "Sala",
                        principalColumn: "IdSala",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Factura",
                columns: table => new
                {
                    IdFactura = table.Column<int>(nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime", nullable: false),
                    IdCliente = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    IdFuncion = table.Column<int>(nullable: false),
                    ValorBruto = table.Column<decimal>(type: "decimal(18, 0)", nullable: false),
                    ValorServicio = table.Column<decimal>(type: "decimal(18, 0)", nullable: false),
                    ValorIva = table.Column<decimal>(type: "decimal(18, 0)", nullable: false),
                    ValorNeto = table.Column<decimal>(type: "decimal(18, 0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factura", x => x.IdFactura);
                    table.ForeignKey(
                        name: "FK_Factura_Cliente",
                        column: x => x.IdCliente,
                        principalTable: "Cliente",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Factura_Funcion",
                        column: x => x.IdFuncion,
                        principalTable: "Funcion",
                        principalColumn: "IdFuncion",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DetalleFactura",
                columns: table => new
                {
                    IdDetalleFactura = table.Column<int>(nullable: false),
                    IdFactura = table.Column<int>(nullable: false),
                    IdentificadorBoleta = table.Column<Guid>(nullable: false),
                    Redimida = table.Column<bool>(nullable: false),
                    FechaUso = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleFactura", x => x.IdDetalleFactura);
                    table.ForeignKey(
                        name: "FK_DetalleFactura_Factura",
                        column: x => x.IdFactura,
                        principalTable: "Factura",
                        principalColumn: "IdFactura",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetalleFactura_IdFactura",
                table: "DetalleFactura",
                column: "IdFactura");

            migrationBuilder.CreateIndex(
                name: "IX_Factura_IdCliente",
                table: "Factura",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Factura_IdFuncion",
                table: "Factura",
                column: "IdFuncion");

            migrationBuilder.CreateIndex(
                name: "IX_Funcion_IdPelicula",
                table: "Funcion",
                column: "IdPelicula");

            migrationBuilder.CreateIndex(
                name: "IX_Funcion_IdSala",
                table: "Funcion",
                column: "IdSala");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetalleFactura");

            migrationBuilder.DropTable(
                name: "Factura");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Funcion");

            migrationBuilder.DropTable(
                name: "Pelicula");

            migrationBuilder.DropTable(
                name: "Sala");
        }
    }
}
