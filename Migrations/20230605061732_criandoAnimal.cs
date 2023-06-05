using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaAgroPop.Migrations
{
    /// <inheritdoc />
    public partial class criandoAnimal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    dataNascimento = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    nroRegistro = table.Column<int>(type: "int", nullable: false),
                    origem = table.Column<int>(type: "int", nullable: false),
                    cor = table.Column<int>(type: "int", nullable: false),
                    peso = table.Column<int>(type: "int", nullable: false),
                    racaid = table.Column<int>(type: "int", nullable: false),
                    fazendaid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.id);
                    table.ForeignKey(
                        name: "FK_Animals_Fazendas_fazendaid",
                        column: x => x.fazendaid,
                        principalTable: "Fazendas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Animals_Racas_racaid",
                        column: x => x.racaid,
                        principalTable: "Racas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Animals_fazendaid",
                table: "Animals",
                column: "fazendaid");

            migrationBuilder.CreateIndex(
                name: "IX_Animals_racaid",
                table: "Animals",
                column: "racaid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Animals");
        }
    }
}
