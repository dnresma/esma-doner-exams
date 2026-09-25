using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Odev06_MVC_TravelGuide.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Places",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    EntryFee = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Places", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Places",
                columns: new[] { "Id", "City", "EntryFee", "Name" },
                values: new object[,]
                {
                    { 1, "İstanbul", 1500, "Topkapı Sarayı Müzesi" },
                    { 2, "Ankara", 0, "Anıtkabir" },
                    { 3, "İzmir", 1250, "Efes Antik Kenti" },
                    { 4, "İstanbul", 900, "Yerebatan Sarnıcı" },
                    { 5, "Trabzon", 450, "Sümela Manastırı" },
                    { 6, "Antalya", 50, "Düden Şelalesi" },
                    { 7, "Denizli", 700, "Pamukkale Travertenleri" },
                    { 8, "Ankara", 0, "Atatürk Orman Çiftliği" },
                    { 9, "Nevşehir", 1000, "Göreme Açık Hava Müzesi" },
                    { 10, "İstanbul", 0, "Emirgan Korusu" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Places");
        }
    }
}
