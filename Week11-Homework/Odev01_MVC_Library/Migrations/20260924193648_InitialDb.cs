using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Odev01_MVC_Library.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Author = table.Column<string>(type: "text", nullable: false),
                    PageCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "PageCount", "Title" },
                values: new object[,]
                {
                    { 1, "Mustafa Kemal Atatürk", 543, "Nutuk" },
                    { 2, "Fyodor Dostoyevski", 704, "Suç ve Ceza" },
                    { 3, "Victor Hugo", 1724, "Sefiller" },
                    { 4, "George Orwell", 352, "1984" },
                    { 5, "José Mauro de Vasconcelos", 200, "Şeker Portakalı" },
                    { 6, "Sabahattin Ali", 160, "Kürk Mantolu Madonna" },
                    { 7, "Paulo Coelho", 184, "Simyacı" },
                    { 8, "Antoine de Saint-Exupéry", 112, "Küçük Prens" },
                    { 9, "Franz Kafka", 104, "Dönüşüm" },
                    { 10, "Oğuz Atay", 724, "Tutunamayanlar" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
