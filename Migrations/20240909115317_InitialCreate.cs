using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductDosageApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bestandteile",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Bestand = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bestandteile", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dosages",
                columns: table => new
                {
                    DosageID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dos1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dos2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dos3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dos4 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dos5 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dos6 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dos7 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dos9 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dos10 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dos11 = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dosages", x => x.DosageID);
                });

            migrationBuilder.CreateTable(
                name: "Produkts",
                columns: table => new
                {
                    ProduktID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MKZ = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrapNr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZVar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Anzahl = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produkts", x => x.ProduktID);
                });

            migrationBuilder.CreateTable(
                name: "DosageBestandteile",
                columns: table => new
                {
                    DosageBestandteilID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DosageID = table.Column<int>(type: "int", nullable: false),
                    BestandteilID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DosageBestandteile", x => x.DosageBestandteilID);
                    table.ForeignKey(
                        name: "FK_DosageBestandteile_Bestandteile_BestandteilID",
                        column: x => x.BestandteilID,
                        principalTable: "Bestandteile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DosageBestandteile_Dosages_DosageID",
                        column: x => x.DosageID,
                        principalTable: "Dosages",
                        principalColumn: "DosageID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProduktDosages",
                columns: table => new
                {
                    ProduktDosageID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProduktID = table.Column<int>(type: "int", nullable: false),
                    DosageID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProduktDosages", x => x.ProduktDosageID);
                    table.ForeignKey(
                        name: "FK_ProduktDosages_Dosages_DosageID",
                        column: x => x.DosageID,
                        principalTable: "Dosages",
                        principalColumn: "DosageID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProduktDosages_Produkts_ProduktID",
                        column: x => x.ProduktID,
                        principalTable: "Produkts",
                        principalColumn: "ProduktID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DosageBestandteile_BestandteilID",
                table: "DosageBestandteile",
                column: "BestandteilID");

            migrationBuilder.CreateIndex(
                name: "IX_DosageBestandteile_DosageID",
                table: "DosageBestandteile",
                column: "DosageID");

            migrationBuilder.CreateIndex(
                name: "IX_ProduktDosages_DosageID",
                table: "ProduktDosages",
                column: "DosageID");

            migrationBuilder.CreateIndex(
                name: "IX_ProduktDosages_ProduktID",
                table: "ProduktDosages",
                column: "ProduktID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DosageBestandteile");

            migrationBuilder.DropTable(
                name: "ProduktDosages");

            migrationBuilder.DropTable(
                name: "Bestandteile");

            migrationBuilder.DropTable(
                name: "Dosages");

            migrationBuilder.DropTable(
                name: "Produkts");
        }
    }
}
