using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Odev03_MVC_VetClinic.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Species = table.Column<string>(type: "text", nullable: false),
                    Age = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vets", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Vets",
                columns: new[] { "Id", "Age", "Name", "Species" },
                values: new object[,]
                {
                    { 1, 5, "Karabaş", "Köpek" },
                    { 2, 3, "Pamuk", "Kedi" },
                    { 3, 2, "Maviş", "Kuş" },
                    { 4, 4, "Minnoş", "Kedi" },
                    { 5, 7, "Çakıl", "Köpek" },
                    { 6, 1, "Boncuk", "Tavşan" },
                    { 7, 2, "Fındık", "Hamster" },
                    { 8, 6, "Leo", "Köpek" },
                    { 9, 5, "Zeytin", "Kedi" },
                    { 10, 3, "Limon", "Papağan" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vets");
        }
    }
}
