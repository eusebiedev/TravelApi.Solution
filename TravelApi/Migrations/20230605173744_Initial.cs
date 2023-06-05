using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelApi.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Language = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Population = table.Column<int>(type: "int", nullable: false),
                    Climate = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryId", "Climate", "Language", "Name", "Population" },
                values: new object[,]
                {
                    { 1, "Shady and Sandy", "Shade", "Striped Umbrella", 4999999 },
                    { 2, "Cool and Sweet", "Peppermint", "Mint", 46001 },
                    { 3, "Harsh", "Chomp", "Agitated Badger", 450 },
                    { 4, "Sweltering and Lava", "Dragonian", "Western Democratic Coalition of Dragons", 3 },
                    { 5, "Gooey", "Swiss", "Cheese Island", 72 },
                    { 6, "Subtropical", "Flubber", "Pants", 7200 },
                    { 7, "Hot and Damp", "Sporkian", "Sporkonia", 840 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
