using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Odev02_MC_MovieArchive.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Director = table.Column<string>(type: "text", nullable: false),
                    ReleaseYear = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Director", "ReleaseYear", "Title" },
                values: new object[,]
                {
                    { 1, "Çağan Irmak", 2005, "Babam ve Oğlum" },
                    { 2, "Christopher Nolan", 2010, "Inception" },
                    { 3, "Lana Wachowski, Lilly Wachowski", 1999, "The Matrix" },
                    { 4, "Francis Ford Coppola", 1972, "The Godfather" },
                    { 5, "Ömer Faruk Sorak", 2004, "G.O.R.A." },
                    { 6, "Quentin Tarantino", 1994, "Pulp Fiction" },
                    { 7, "Yılmaz Erdoğan, Ömer Faruk Sorak", 2001, "Vizontele" },
                    { 8, "Christopher Nolan", 2008, "The Dark Knight" },
                    { 9, "Nuri Bilge Ceylan", 2011, "Bir Zamanlar Anadolu'da" },
                    { 10, "Christopher Nolan", 2014, "Interstellar" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
