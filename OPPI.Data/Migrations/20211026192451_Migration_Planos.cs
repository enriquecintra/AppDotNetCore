using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace OPPI.Data.Migrations
{
    public partial class Migration_Planos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produto_Loja_LojaId",
                table: "Produto");

            migrationBuilder.AlterColumn<int>(
                name: "LojaId",
                table: "Produto",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CNPJ",
                table: "Loja",
                type: "varchar(14)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Plano",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TipoPlano = table.Column<int>(type: "integer", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: true),
                    Descricao = table.Column<string>(type: "text", nullable: true),
                    PeriodoGratuito = table.Column<int>(type: "integer", nullable: false),
                    Quantidade = table.Column<int>(type: "integer", nullable: false),
                    Comissao = table.Column<decimal>(type: "numeric", nullable: false),
                    TaxaFrete = table.Column<decimal>(type: "numeric", nullable: false),
                    ValorFreteGratis = table.Column<decimal>(type: "numeric", nullable: false),
                    Promocao = table.Column<bool>(type: "boolean", nullable: false),
                    Campanha = table.Column<bool>(type: "boolean", nullable: false),
                    Anuncio = table.Column<bool>(type: "boolean", nullable: false),
                    PagSeguro = table.Column<bool>(type: "boolean", nullable: false),
                    AtendimentoVIP = table.Column<bool>(type: "boolean", nullable: false),
                    CupomDesconto = table.Column<bool>(type: "boolean", nullable: false),
                    ValeCompra = table.Column<bool>(type: "boolean", nullable: false),
                    EmailMarketing = table.Column<bool>(type: "boolean", nullable: false),
                    EmailPersonalizado = table.Column<bool>(type: "boolean", nullable: false),
                    PaginaPersonalizada = table.Column<bool>(type: "boolean", nullable: false),
                    FormasEntrega = table.Column<bool>(type: "boolean", nullable: false),
                    GoogleShopping = table.Column<bool>(type: "boolean", nullable: false),
                    InteligenciaMercado = table.Column<bool>(type: "boolean", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plano", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlanoPreco",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PlanoId = table.Column<int>(type: "integer", nullable: false),
                    Valor = table.Column<decimal>(type: "numeric", nullable: false),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DataFim = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DataCadastro = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanoPreco", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanoPreco_Plano_PlanoId",
                        column: x => x.PlanoId,
                        principalTable: "Plano",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LojaPlanoPreco",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LojaId = table.Column<int>(type: "integer", nullable: false),
                    PlanoPrecoId = table.Column<int>(type: "integer", nullable: false),
                    DataInicioVigencia = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    RenovacaoAutomatica = table.Column<bool>(type: "boolean", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LojaPlanoPreco", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LojaPlanoPreco_Loja_LojaId",
                        column: x => x.LojaId,
                        principalTable: "Loja",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LojaPlanoPreco_PlanoPreco_PlanoPrecoId",
                        column: x => x.PlanoPrecoId,
                        principalTable: "PlanoPreco",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LojaPlanoPreco_LojaId",
                table: "LojaPlanoPreco",
                column: "LojaId");

            migrationBuilder.CreateIndex(
                name: "IX_LojaPlanoPreco_PlanoPrecoId",
                table: "LojaPlanoPreco",
                column: "PlanoPrecoId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanoPreco_PlanoId",
                table: "PlanoPreco",
                column: "PlanoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produto_Loja_LojaId",
                table: "Produto",
                column: "LojaId",
                principalTable: "Loja",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produto_Loja_LojaId",
                table: "Produto");

            migrationBuilder.DropTable(
                name: "LojaPlanoPreco");

            migrationBuilder.DropTable(
                name: "PlanoPreco");

            migrationBuilder.DropTable(
                name: "Plano");

            migrationBuilder.DropColumn(
                name: "CNPJ",
                table: "Loja");

            migrationBuilder.AlterColumn<int>(
                name: "LojaId",
                table: "Produto",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Produto_Loja_LojaId",
                table: "Produto",
                column: "LojaId",
                principalTable: "Loja",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
