using Microsoft.EntityFrameworkCore.Migrations;

namespace OPPI.Data.Migrations
{
    public partial class Migration_EnderecoComplemento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Complemento",
                table: "Endereco",
                type: "varchar(50)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Complemento",
                table: "Endereco");
        }
    }
}
