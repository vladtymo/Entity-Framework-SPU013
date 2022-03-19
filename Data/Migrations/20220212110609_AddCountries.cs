using Microsoft.EntityFrameworkCore.Migrations;

namespace EF_Intro.Migrations
{
    public partial class AddCountries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "Workers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Ukraine" },
                    { 2, "Poland" },
                    { 3, "Italy" },
                    { 4, "Spain" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Workers_CountryId",
                table: "Workers",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Workers_Countries_CountryId",
                table: "Workers",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workers_Countries_CountryId",
                table: "Workers");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_Workers_CountryId",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Workers");
        }
    }
}
