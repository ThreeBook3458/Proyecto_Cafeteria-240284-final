using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Proyecto_Cafeteria_240284.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Username",
                keyValue: "admin");

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "Id", "Descripcion", "ImagenBase64", "ImagenUrl", "Nombre", "Precio", "Stock" },
                values: new object[,]
                {
                    { 1, "Café espresso diluido con agua caliente", null, "/images/CafeAmericano.jpg", "Café Americano", 35.00m, 100 },
                    { 2, "Espresso con leche vaporizada y espuma", null, "/images/cappuccinoAmericano.jpg", "Cappuccino", 45.00m, 80 },
                    { 3, "Café espresso con abundante leche", null, "/images/Latte.jpg", "Latte", 48.00m, 75 },
                    { 4, "Mezcla de café, chocolate y leche", null, "/images/Moka.jpg", "Moka", 52.00m, 60 },
                    { 5, "Té de hierbas verdes con hielos", null, "/images/Matcha.jpg", "Matcha", 120m, 25 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Username", "Password" },
                values: new object[] { "Aaronh", "huerta12.Ar" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Username",
                keyValue: "Aaronh");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Username", "Password" },
                values: new object[] { "admin", "admin123" });
        }
    }
}
