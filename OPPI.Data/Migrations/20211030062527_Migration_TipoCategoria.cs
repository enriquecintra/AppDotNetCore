using Microsoft.EntityFrameworkCore.Migrations;

namespace OPPI.Data.Migrations
{
    public partial class Migration_TipoCategoria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoProduto",
                table: "Produto");

            migrationBuilder.AddColumn<string>(
                name: "Foto",
                table: "Categoria",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Tipo",
                table: "Categoria",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Foto",
                table: "Categoria");

            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "Categoria");

            migrationBuilder.AddColumn<int>(
                name: "TipoProduto",
                table: "Produto",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
