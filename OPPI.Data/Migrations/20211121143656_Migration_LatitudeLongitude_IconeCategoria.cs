using Microsoft.EntityFrameworkCore.Migrations;

namespace OPPI.Data.Migrations
{
    public partial class Migration_LatitudeLongitude_IconeCategoria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Latitude",
                table: "Endereco",
                type: "numeric(10,8)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Longitude",
                table: "Endereco",
                type: "numeric(11,8)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Icone",
                table: "Categoria",
                type: "varchar(50)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Endereco");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Endereco");

            migrationBuilder.DropColumn(
                name: "Icone",
                table: "Categoria");
        }
    }
}
