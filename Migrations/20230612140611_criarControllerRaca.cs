using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaAgroPop.Migrations
{
    /// <inheritdoc />
    public partial class criarControllerRaca : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Racas_Enderecos_enderecoid",
                table: "Racas");

            migrationBuilder.DropIndex(
                name: "IX_Racas_enderecoid",
                table: "Racas");

            migrationBuilder.DropColumn(
                name: "enderecoid",
                table: "Racas");

            migrationBuilder.AlterColumn<int>(
                name: "porte",
                table: "Racas",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "especie",
                table: "Racas",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "porte",
                table: "Racas",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "especie",
                table: "Racas",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "enderecoid",
                table: "Racas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Racas_enderecoid",
                table: "Racas",
                column: "enderecoid");

            migrationBuilder.AddForeignKey(
                name: "FK_Racas_Enderecos_enderecoid",
                table: "Racas",
                column: "enderecoid",
                principalTable: "Enderecos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
