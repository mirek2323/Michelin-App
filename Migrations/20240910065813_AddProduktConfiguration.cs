using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductDosageApp.Migrations
{
    /// <inheritdoc />
    public partial class AddProduktConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProduktConfigurations",
                columns: table => new
                {
                    ProduktConfigurationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProduktID = table.Column<int>(type: "int", nullable: false),
                    Dos1BestandteilID = table.Column<int>(type: "int", nullable: true),
                    Dos2BestandteilID = table.Column<int>(type: "int", nullable: true),
                    Dos3BestandteilID = table.Column<int>(type: "int", nullable: true),
                    Dos4BestandteilID = table.Column<int>(type: "int", nullable: true),
                    Dos5BestandteilID = table.Column<int>(type: "int", nullable: true),
                    Dos6BestandteilID = table.Column<int>(type: "int", nullable: true),
                    Dos7BestandteilID = table.Column<int>(type: "int", nullable: true),
                    Dos9BestandteilID = table.Column<int>(type: "int", nullable: true),
                    Dos10BestandteilID = table.Column<int>(type: "int", nullable: true),
                    Dos11BestandteilID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProduktConfigurations", x => x.ProduktConfigurationID);
                    table.ForeignKey(
                        name: "FK_ProduktConfigurations_Bestandteile_Dos10BestandteilID",
                        column: x => x.Dos10BestandteilID,
                        principalTable: "Bestandteile",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProduktConfigurations_Bestandteile_Dos11BestandteilID",
                        column: x => x.Dos11BestandteilID,
                        principalTable: "Bestandteile",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProduktConfigurations_Bestandteile_Dos1BestandteilID",
                        column: x => x.Dos1BestandteilID,
                        principalTable: "Bestandteile",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProduktConfigurations_Bestandteile_Dos2BestandteilID",
                        column: x => x.Dos2BestandteilID,
                        principalTable: "Bestandteile",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProduktConfigurations_Bestandteile_Dos3BestandteilID",
                        column: x => x.Dos3BestandteilID,
                        principalTable: "Bestandteile",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProduktConfigurations_Bestandteile_Dos4BestandteilID",
                        column: x => x.Dos4BestandteilID,
                        principalTable: "Bestandteile",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProduktConfigurations_Bestandteile_Dos5BestandteilID",
                        column: x => x.Dos5BestandteilID,
                        principalTable: "Bestandteile",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProduktConfigurations_Bestandteile_Dos6BestandteilID",
                        column: x => x.Dos6BestandteilID,
                        principalTable: "Bestandteile",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProduktConfigurations_Bestandteile_Dos7BestandteilID",
                        column: x => x.Dos7BestandteilID,
                        principalTable: "Bestandteile",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProduktConfigurations_Bestandteile_Dos9BestandteilID",
                        column: x => x.Dos9BestandteilID,
                        principalTable: "Bestandteile",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProduktConfigurations_Produkts_ProduktID",
                        column: x => x.ProduktID,
                        principalTable: "Produkts",
                        principalColumn: "ProduktID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProduktConfigurations_Dos10BestandteilID",
                table: "ProduktConfigurations",
                column: "Dos10BestandteilID");

            migrationBuilder.CreateIndex(
                name: "IX_ProduktConfigurations_Dos11BestandteilID",
                table: "ProduktConfigurations",
                column: "Dos11BestandteilID");

            migrationBuilder.CreateIndex(
                name: "IX_ProduktConfigurations_Dos1BestandteilID",
                table: "ProduktConfigurations",
                column: "Dos1BestandteilID");

            migrationBuilder.CreateIndex(
                name: "IX_ProduktConfigurations_Dos2BestandteilID",
                table: "ProduktConfigurations",
                column: "Dos2BestandteilID");

            migrationBuilder.CreateIndex(
                name: "IX_ProduktConfigurations_Dos3BestandteilID",
                table: "ProduktConfigurations",
                column: "Dos3BestandteilID");

            migrationBuilder.CreateIndex(
                name: "IX_ProduktConfigurations_Dos4BestandteilID",
                table: "ProduktConfigurations",
                column: "Dos4BestandteilID");

            migrationBuilder.CreateIndex(
                name: "IX_ProduktConfigurations_Dos5BestandteilID",
                table: "ProduktConfigurations",
                column: "Dos5BestandteilID");

            migrationBuilder.CreateIndex(
                name: "IX_ProduktConfigurations_Dos6BestandteilID",
                table: "ProduktConfigurations",
                column: "Dos6BestandteilID");

            migrationBuilder.CreateIndex(
                name: "IX_ProduktConfigurations_Dos7BestandteilID",
                table: "ProduktConfigurations",
                column: "Dos7BestandteilID");

            migrationBuilder.CreateIndex(
                name: "IX_ProduktConfigurations_Dos9BestandteilID",
                table: "ProduktConfigurations",
                column: "Dos9BestandteilID");

            migrationBuilder.CreateIndex(
                name: "IX_ProduktConfigurations_ProduktID",
                table: "ProduktConfigurations",
                column: "ProduktID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProduktConfigurations");
        }
    }
}
