using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Odev04_MVC_GymMembers.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FullName = table.Column<string>(type: "text", nullable: false),
                    MemberShipType = table.Column<string>(type: "text", nullable: false),
                    Age = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "Id", "Age", "FullName", "MemberShipType" },
                values: new object[,]
                {
                    { 1, 28, "Ahmet Yılmaz", "Aylık" },
                    { 2, 34, "Ayşe Kaya", "Yıllık" },
                    { 3, 22, "Mehmet Demir", "3 Aylık" },
                    { 4, 41, "Zeynep Çelik", "Aylık" },
                    { 5, 29, "Can Öztürk", "Yıllık" },
                    { 6, 25, "Elif Şahin", "3 Aylık" },
                    { 7, 33, "Burak Arslan", "Aylık" },
                    { 8, 37, "Seda Aydın", "Yıllık" },
                    { 9, 20, "Emre Yıldız", "3 Aylık" },
                    { 10, 31, "Merve Koç", "Yıllık" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Members");
        }
    }
}
