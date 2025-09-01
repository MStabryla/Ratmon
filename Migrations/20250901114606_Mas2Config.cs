using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ratmon.Migrations
{
    /// <inheritdoc />
    public partial class Mas2Config : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mas2_Config",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    TemperatureThreshold = table.Column<float>(type: "REAL", nullable: false),
                    HumidityThreshold = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mas2_Config", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mas2_Config");
        }
    }
}
