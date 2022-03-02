using Microsoft.EntityFrameworkCore.Migrations;

namespace OPPI.Data.Migrations
{
    public partial class Migration_Navegacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Navegacao_Produto_ProdutoId",
                table: "Navegacao");

            migrationBuilder.DropColumn(
                name: "Avaliacao",
                table: "Navegacao");

            migrationBuilder.DropColumn(
                name: "Preciacao",
                table: "Navegacao");

            migrationBuilder.RenameColumn(
                name: "ProdutoId",
                table: "Navegacao",
                newName: "LojaId");

            migrationBuilder.RenameIndex(
                name: "IX_Navegacao_ProdutoId",
                table: "Navegacao",
                newName: "IX_Navegacao_LojaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Navegacao_Loja_LojaId",
                table: "Navegacao",
                column: "LojaId",
                principalTable: "Loja",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Navegacao_Loja_LojaId",
                table: "Navegacao");

            migrationBuilder.RenameColumn(
                name: "LojaId",
                table: "Navegacao",
                newName: "ProdutoId");

            migrationBuilder.RenameIndex(
                name: "IX_Navegacao_LojaId",
                table: "Navegacao",
                newName: "IX_Navegacao_ProdutoId");

            migrationBuilder.AddColumn<int>(
                name: "Avaliacao",
                table: "Navegacao",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Preciacao",
                table: "Navegacao",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Navegacao_Produto_ProdutoId",
                table: "Navegacao",
                column: "ProdutoId",
                principalTable: "Produto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
