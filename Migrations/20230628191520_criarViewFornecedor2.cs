using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaAgroPop.Migrations
{
    /// <inheritdoc />
    public partial class criarViewFornecedor2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fazendas_Enderecos_enderecoid",
                table: "Fazendas");

            migrationBuilder.DropForeignKey(
                name: "FK_Fornecedors_Enderecos_enderecoid",
                table: "Fornecedors");

            migrationBuilder.RenameColumn(
                name: "enderecoid",
                table: "Fornecedors",
                newName: "enderecoId");

            migrationBuilder.RenameIndex(
                name: "IX_Fornecedors_enderecoid",
                table: "Fornecedors",
                newName: "IX_Fornecedors_enderecoId");

            migrationBuilder.RenameColumn(
                name: "enderecoid",
                table: "Fazendas",
                newName: "enderecoId");

            migrationBuilder.RenameIndex(
                name: "IX_Fazendas_enderecoid",
                table: "Fazendas",
                newName: "IX_Fazendas_enderecoId");

            migrationBuilder.AddColumn<int>(
                name: "Fornecedorid",
                table: "VacinaFornecidas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VacinaId",
                table: "VacinaFornecidas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Animalid",
                table: "CarteiraVacinacoes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Fornecedorid",
                table: "CarteiraVacinacoes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VacinaId",
                table: "CarteiraVacinacoes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_VacinaFornecidas_Fornecedorid",
                table: "VacinaFornecidas",
                column: "Fornecedorid");

            migrationBuilder.CreateIndex(
                name: "IX_VacinaFornecidas_VacinaId",
                table: "VacinaFornecidas",
                column: "VacinaId");

            migrationBuilder.CreateIndex(
                name: "IX_CarteiraVacinacoes_Animalid",
                table: "CarteiraVacinacoes",
                column: "Animalid");

            migrationBuilder.CreateIndex(
                name: "IX_CarteiraVacinacoes_Fornecedorid",
                table: "CarteiraVacinacoes",
                column: "Fornecedorid");

            migrationBuilder.CreateIndex(
                name: "IX_CarteiraVacinacoes_VacinaId",
                table: "CarteiraVacinacoes",
                column: "VacinaId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarteiraVacinacoes_Animals_Animalid",
                table: "CarteiraVacinacoes",
                column: "Animalid",
                principalTable: "Animals",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarteiraVacinacoes_Fornecedors_Fornecedorid",
                table: "CarteiraVacinacoes",
                column: "Fornecedorid",
                principalTable: "Fornecedors",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarteiraVacinacoes_Vacinas_VacinaId",
                table: "CarteiraVacinacoes",
                column: "VacinaId",
                principalTable: "Vacinas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Fazendas_Enderecos_enderecoId",
                table: "Fazendas",
                column: "enderecoId",
                principalTable: "Enderecos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Fornecedors_Enderecos_enderecoId",
                table: "Fornecedors",
                column: "enderecoId",
                principalTable: "Enderecos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VacinaFornecidas_Fornecedors_Fornecedorid",
                table: "VacinaFornecidas",
                column: "Fornecedorid",
                principalTable: "Fornecedors",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VacinaFornecidas_Vacinas_VacinaId",
                table: "VacinaFornecidas",
                column: "VacinaId",
                principalTable: "Vacinas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarteiraVacinacoes_Animals_Animalid",
                table: "CarteiraVacinacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_CarteiraVacinacoes_Fornecedors_Fornecedorid",
                table: "CarteiraVacinacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_CarteiraVacinacoes_Vacinas_VacinaId",
                table: "CarteiraVacinacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Fazendas_Enderecos_enderecoId",
                table: "Fazendas");

            migrationBuilder.DropForeignKey(
                name: "FK_Fornecedors_Enderecos_enderecoId",
                table: "Fornecedors");

            migrationBuilder.DropForeignKey(
                name: "FK_VacinaFornecidas_Fornecedors_Fornecedorid",
                table: "VacinaFornecidas");

            migrationBuilder.DropForeignKey(
                name: "FK_VacinaFornecidas_Vacinas_VacinaId",
                table: "VacinaFornecidas");

            migrationBuilder.DropIndex(
                name: "IX_VacinaFornecidas_Fornecedorid",
                table: "VacinaFornecidas");

            migrationBuilder.DropIndex(
                name: "IX_VacinaFornecidas_VacinaId",
                table: "VacinaFornecidas");

            migrationBuilder.DropIndex(
                name: "IX_CarteiraVacinacoes_Animalid",
                table: "CarteiraVacinacoes");

            migrationBuilder.DropIndex(
                name: "IX_CarteiraVacinacoes_Fornecedorid",
                table: "CarteiraVacinacoes");

            migrationBuilder.DropIndex(
                name: "IX_CarteiraVacinacoes_VacinaId",
                table: "CarteiraVacinacoes");

            migrationBuilder.DropColumn(
                name: "Fornecedorid",
                table: "VacinaFornecidas");

            migrationBuilder.DropColumn(
                name: "VacinaId",
                table: "VacinaFornecidas");

            migrationBuilder.DropColumn(
                name: "Animalid",
                table: "CarteiraVacinacoes");

            migrationBuilder.DropColumn(
                name: "Fornecedorid",
                table: "CarteiraVacinacoes");

            migrationBuilder.DropColumn(
                name: "VacinaId",
                table: "CarteiraVacinacoes");

            migrationBuilder.RenameColumn(
                name: "enderecoId",
                table: "Fornecedors",
                newName: "enderecoid");

            migrationBuilder.RenameIndex(
                name: "IX_Fornecedors_enderecoId",
                table: "Fornecedors",
                newName: "IX_Fornecedors_enderecoid");

            migrationBuilder.RenameColumn(
                name: "enderecoId",
                table: "Fazendas",
                newName: "enderecoid");

            migrationBuilder.RenameIndex(
                name: "IX_Fazendas_enderecoId",
                table: "Fazendas",
                newName: "IX_Fazendas_enderecoid");

            migrationBuilder.AddForeignKey(
                name: "FK_Fazendas_Enderecos_enderecoid",
                table: "Fazendas",
                column: "enderecoid",
                principalTable: "Enderecos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Fornecedors_Enderecos_enderecoid",
                table: "Fornecedors",
                column: "enderecoid",
                principalTable: "Enderecos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
