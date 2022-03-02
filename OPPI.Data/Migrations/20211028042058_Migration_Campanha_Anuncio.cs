using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace OPPI.Data.Migrations
{
    public partial class Migration_Campanha_Anuncio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Destaque",
                table: "Produto",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Anuncio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LojaId = table.Column<int>(type: "integer", nullable: false),
                    Descricao = table.Column<string>(type: "text", nullable: true),
                    DataInicial = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DataFinal = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DataCadastro = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anuncio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Anuncio_Loja_LojaId",
                        column: x => x.LojaId,
                        principalTable: "Loja",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Campanha",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LojaId = table.Column<int>(type: "integer", nullable: false),
                    Descricao = table.Column<string>(type: "text", nullable: true),
                    DataInicial = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DataFinal = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DataCadastro = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campanha", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Campanha_Loja_LojaId",
                        column: x => x.LojaId,
                        principalTable: "Loja",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnuncioFoto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AnuncioId = table.Column<int>(type: "integer", nullable: false),
                    FotoId = table.Column<int>(type: "integer", nullable: false),
                    Ordem = table.Column<int>(type: "integer", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnuncioFoto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnuncioFoto_Anuncio_AnuncioId",
                        column: x => x.AnuncioId,
                        principalTable: "Anuncio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnuncioFoto_Foto_FotoId",
                        column: x => x.FotoId,
                        principalTable: "Foto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CampanhaFoto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CampanhaId = table.Column<int>(type: "integer", nullable: false),
                    FotoId = table.Column<int>(type: "integer", nullable: false),
                    Ordem = table.Column<int>(type: "integer", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampanhaFoto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CampanhaFoto_Campanha_CampanhaId",
                        column: x => x.CampanhaId,
                        principalTable: "Campanha",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CampanhaFoto_Foto_FotoId",
                        column: x => x.FotoId,
                        principalTable: "Foto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LojaCampanha",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LojaId = table.Column<int>(type: "integer", nullable: false),
                    CampanhaId = table.Column<int>(type: "integer", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LojaCampanha", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LojaCampanha_Campanha_CampanhaId",
                        column: x => x.CampanhaId,
                        principalTable: "Campanha",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LojaCampanha_Loja_LojaId",
                        column: x => x.LojaId,
                        principalTable: "Loja",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Anuncio_LojaId",
                table: "Anuncio",
                column: "LojaId");

            migrationBuilder.CreateIndex(
                name: "IX_AnuncioFoto_AnuncioId",
                table: "AnuncioFoto",
                column: "AnuncioId");

            migrationBuilder.CreateIndex(
                name: "IX_AnuncioFoto_FotoId",
                table: "AnuncioFoto",
                column: "FotoId");

            migrationBuilder.CreateIndex(
                name: "IX_Campanha_LojaId",
                table: "Campanha",
                column: "LojaId");

            migrationBuilder.CreateIndex(
                name: "IX_CampanhaFoto_CampanhaId",
                table: "CampanhaFoto",
                column: "CampanhaId");

            migrationBuilder.CreateIndex(
                name: "IX_CampanhaFoto_FotoId",
                table: "CampanhaFoto",
                column: "FotoId");

            migrationBuilder.CreateIndex(
                name: "IX_LojaCampanha_CampanhaId",
                table: "LojaCampanha",
                column: "CampanhaId");

            migrationBuilder.CreateIndex(
                name: "IX_LojaCampanha_LojaId",
                table: "LojaCampanha",
                column: "LojaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnuncioFoto");

            migrationBuilder.DropTable(
                name: "CampanhaFoto");

            migrationBuilder.DropTable(
                name: "LojaCampanha");

            migrationBuilder.DropTable(
                name: "Anuncio");

            migrationBuilder.DropTable(
                name: "Campanha");

            migrationBuilder.DropColumn(
                name: "Destaque",
                table: "Produto");
        }
    }
}
