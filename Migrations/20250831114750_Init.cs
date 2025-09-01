using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ratmon.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mas2Set",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    C = table.Column<double>(type: "REAL", nullable: false),
                    Humidity = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mas2Set", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mouse2_Config",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Threshold = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mouse2_Config", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mouse2B_Config",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Threshold = table.Column<float>(type: "REAL", nullable: false),
                    WireLength = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mouse2B_Config", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mouse2BSet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    V = table.Column<double>(type: "REAL", nullable: false),
                    Ω = table.Column<double>(type: "REAL", nullable: false),
                    LeakLocation = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mouse2BSet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mouse2Set",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    V = table.Column<double>(type: "REAL", nullable: false),
                    Ω = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mouse2Set", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MouseCombo_Config",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Threshold = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MouseCombo_Config", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MouseComboSet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    V = table.Column<double>(type: "REAL", nullable: false),
                    Ω = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MouseComboSet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reflectogram",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SeriesNumber = table.Column<ushort>(type: "INTEGER", nullable: false),
                    Bytes = table.Column<byte[]>(type: "BLOB", nullable: false),
                    MouseComboId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reflectogram", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reflectogram_MouseComboSet_MouseComboId",
                        column: x => x.MouseComboId,
                        principalTable: "MouseComboSet",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reflectogram_MouseComboId",
                table: "Reflectogram",
                column: "MouseComboId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mas2Set");

            migrationBuilder.DropTable(
                name: "Mouse2_Config");

            migrationBuilder.DropTable(
                name: "Mouse2B_Config");

            migrationBuilder.DropTable(
                name: "Mouse2BSet");

            migrationBuilder.DropTable(
                name: "Mouse2Set");

            migrationBuilder.DropTable(
                name: "MouseCombo_Config");

            migrationBuilder.DropTable(
                name: "Reflectogram");

            migrationBuilder.DropTable(
                name: "MouseComboSet");
        }
    }
}
