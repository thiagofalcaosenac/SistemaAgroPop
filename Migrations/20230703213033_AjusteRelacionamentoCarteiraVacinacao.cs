using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaAgroPop.Migrations
{
    /// <inheritdoc />
    public partial class AjusteRelacionamentoCarteiraVacinacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarteiraVacinacoes_Animals_Animalid",
                table: "CarteiraVacinacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_CarteiraVacinacoes_Fornecedors_Fornecedorid",
                table: "CarteiraVacinacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_VacinaFornecidas_Fornecedors_Fornecedorid",
                table: "VacinaFornecidas");

            migrationBuilder.DropForeignKey(
                name: "FK_VacinaFornecidas_Vacinas_VacinaId",
                table: "VacinaFornecidas");

            migrationBuilder.RenameColumn(
                name: "VacinaId",
                table: "VacinaFornecidas",
                newName: "vacinaId");

            migrationBuilder.RenameColumn(
                name: "Fornecedorid",
                table: "VacinaFornecidas",
                newName: "fornecedorId");

            migrationBuilder.RenameIndex(
                name: "IX_VacinaFornecidas_VacinaId",
                table: "VacinaFornecidas",
                newName: "IX_VacinaFornecidas_vacinaId");

            migrationBuilder.RenameIndex(
                name: "IX_VacinaFornecidas_Fornecedorid",
                table: "VacinaFornecidas",
                newName: "IX_VacinaFornecidas_fornecedorId");

            migrationBuilder.RenameColumn(
                name: "Fornecedorid",
                table: "CarteiraVacinacoes",
                newName: "FornecedorId");

            migrationBuilder.RenameColumn(
                name: "Animalid",
                table: "CarteiraVacinacoes",
                newName: "AnimalId");

            migrationBuilder.RenameIndex(
                name: "IX_CarteiraVacinacoes_Fornecedorid",
                table: "CarteiraVacinacoes",
                newName: "IX_CarteiraVacinacoes_FornecedorId");

            migrationBuilder.RenameIndex(
                name: "IX_CarteiraVacinacoes_Animalid",
                table: "CarteiraVacinacoes",
                newName: "IX_CarteiraVacinacoes_AnimalId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarteiraVacinacoes_Animals_AnimalId",
                table: "CarteiraVacinacoes",
                column: "AnimalId",
                principalTable: "Animals",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarteiraVacinacoes_Fornecedors_FornecedorId",
                table: "CarteiraVacinacoes",
                column: "FornecedorId",
                principalTable: "Fornecedors",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VacinaFornecidas_Fornecedors_fornecedorId",
                table: "VacinaFornecidas",
                column: "fornecedorId",
                principalTable: "Fornecedors",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VacinaFornecidas_Vacinas_vacinaId",
                table: "VacinaFornecidas",
                column: "vacinaId",
                principalTable: "Vacinas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarteiraVacinacoes_Animals_AnimalId",
                table: "CarteiraVacinacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_CarteiraVacinacoes_Fornecedors_FornecedorId",
                table: "CarteiraVacinacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_VacinaFornecidas_Fornecedors_fornecedorId",
                table: "VacinaFornecidas");

            migrationBuilder.DropForeignKey(
                name: "FK_VacinaFornecidas_Vacinas_vacinaId",
                table: "VacinaFornecidas");

            migrationBuilder.RenameColumn(
                name: "vacinaId",
                table: "VacinaFornecidas",
                newName: "VacinaId");

            migrationBuilder.RenameColumn(
                name: "fornecedorId",
                table: "VacinaFornecidas",
                newName: "Fornecedorid");

            migrationBuilder.RenameIndex(
                name: "IX_VacinaFornecidas_vacinaId",
                table: "VacinaFornecidas",
                newName: "IX_VacinaFornecidas_VacinaId");

            migrationBuilder.RenameIndex(
                name: "IX_VacinaFornecidas_fornecedorId",
                table: "VacinaFornecidas",
                newName: "IX_VacinaFornecidas_Fornecedorid");

            migrationBuilder.RenameColumn(
                name: "FornecedorId",
                table: "CarteiraVacinacoes",
                newName: "Fornecedorid");

            migrationBuilder.RenameColumn(
                name: "AnimalId",
                table: "CarteiraVacinacoes",
                newName: "Animalid");

            migrationBuilder.RenameIndex(
                name: "IX_CarteiraVacinacoes_FornecedorId",
                table: "CarteiraVacinacoes",
                newName: "IX_CarteiraVacinacoes_Fornecedorid");

            migrationBuilder.RenameIndex(
                name: "IX_CarteiraVacinacoes_AnimalId",
                table: "CarteiraVacinacoes",
                newName: "IX_CarteiraVacinacoes_Animalid");

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
    }
}
