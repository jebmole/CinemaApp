using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaApp.Infrastructure.Migrations
{
    public partial class SeedingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Sala",
                columns: new[] { "IdSala", "Activa", "Capacidad", "EsDinamix", "Nomenclatura" },
                values: new object[] { 1, true, 20, false, "S1" });

            migrationBuilder.InsertData(
                table: "Sala",
                columns: new[] { "IdSala", "Activa", "Capacidad", "EsDinamix", "Nomenclatura" },
                values: new object[] { 2, true, 30, true, "S2" });

            migrationBuilder.InsertData(
                table: "Sala",
                columns: new[] { "IdSala", "Activa", "Capacidad", "EsDinamix", "Nomenclatura" },
                values: new object[] { 3, true, 25, false, "S3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Sala",
                keyColumn: "IdSala",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sala",
                keyColumn: "IdSala",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Sala",
                keyColumn: "IdSala",
                keyValue: 3);
        }
    }
}
