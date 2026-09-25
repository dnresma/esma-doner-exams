using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Odev05_MVC_CafeMenu.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MenuItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Category = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItems", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "Id", "Category", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Sıcak İçecek", "Türk Kahvesi", 75 },
                    { 2, "Sıcak İçecek", "Espresso", 80 },
                    { 3, "Soğuk İçecek", "Iced Latte", 110 },
                    { 4, "Soğuk İçecek", "Ev Yapımı Limonata", 95 },
                    { 5, "Tatlı", "San Sebastian Cheesecake", 180 },
                    { 6, "Tatlı", "Tiramisu", 160 },
                    { 7, "Sıcak İçecek", "Demleme Çay", 35 },
                    { 8, "Soğuk İçecek", "Ice Americano", 100 },
                    { 9, "Sıcak İçecek", "Sıcak Çikolata", 120 },
                    { 10, "Tatlı", "Havuçlu Kek", 130 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MenuItems");
        }
    }
}
