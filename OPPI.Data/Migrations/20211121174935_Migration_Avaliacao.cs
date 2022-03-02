using Microsoft.EntityFrameworkCore.Migrations;

namespace OPPI.Data.Migrations
{
    public partial class Migration_Avaliacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Avaliacao_Loja_LojaId",
                table: "Avaliacao");

            migrationBuilder.AlterColumn<int>(
                name: "LojaId",
                table: "Avaliacao",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Avaliacao_Loja_LojaId",
                table: "Avaliacao",
                column: "LojaId",
                principalTable: "Loja",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Avaliacao_Loja_LojaId",
                table: "Avaliacao");

            migrationBuilder.AlterColumn<int>(
                name: "LojaId",
                table: "Avaliacao",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Avaliacao_Loja_LojaId",
                table: "Avaliacao",
                column: "LojaId",
                principalTable: "Loja",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
