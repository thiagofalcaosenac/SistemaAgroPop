using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaAgroPop.Migrations
{
    /// <inheritdoc />
    public partial class NovosCamposEndereco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "bairro",
                table: "Enderecos",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "cidade",
                table: "Enderecos",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "complemento",
                table: "Enderecos",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "estado",
                table: "Enderecos",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "numero",
                table: "Enderecos",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "rua",
                table: "Enderecos",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "bairro",
                table: "Enderecos");

            migrationBuilder.DropColumn(
                name: "cidade",
                table: "Enderecos");

            migrationBuilder.DropColumn(
                name: "complemento",
                table: "Enderecos");

            migrationBuilder.DropColumn(
                name: "estado",
                table: "Enderecos");

            migrationBuilder.DropColumn(
                name: "numero",
                table: "Enderecos");

            migrationBuilder.DropColumn(
                name: "rua",
                table: "Enderecos");
        }
    }
}
