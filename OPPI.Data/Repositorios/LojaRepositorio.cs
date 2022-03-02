using Microsoft.EntityFrameworkCore;
using OPPI.Data.Repositorios.Interfaces;
using OPPI.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OPPI.Data.Helpers;

namespace OPPI.Data.Repositorios
{
    public class LojaRepositorio : Repositorio<Loja>, ILojaRepositorio
    {
        public LojaRepositorio(OppiContext dbContext) : base(dbContext)
        {

        }

        public async Task InserirPlano(LojaPlanoPreco entidade)
        {
            await _dbContext.LojaPlanoPreco.AddAsync(entidade);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Loja>> Listar(int pagina, int quantidade)
        {
            return await _dbContext.Loja
                .AsNoTracking()
                .OrderByDescending(o => o.TipoFornecedor)
                .Skip(pagina * quantidade)
                .Take(quantidade)
                .ToListAsync();
        }

        public async Task<IEnumerable<Loja>> ListarPorCategoria(int categoriaId, int pagina, int quantidade)
        {
            var lista = await _dbContext.Loja
                .Include(i => i.Endereco)
                .Include(i => i.Avaliacoes)
                .Include(i => i.Telefones)
                    .Where(x => x.Produtos.Any(c => c.Segmento.CategoriaId == categoriaId))
                    //.Include(i => i.Produtos).ThenInclude(i => i.Segmento)
                    .Skip(pagina).Take(quantidade).ToListAsync();

            return lista;
        }

        

        public new async Task<Loja> ObterCompleto(object id)
        {
            return await _dbContext.Loja
                .AsNoTracking()
                .Include(i => i.LojaFotos)
                .Include(i => i.Produtos).ThenInclude(i => i.Segmento).ThenInclude(i => i.Categoria)
                .Include(i => i.Telefones)
                .Include(i => i.Avaliacoes)
                .Include(i => i.Atendimentos)
                .Include(i => i.Endereco)
                .Include(i => i.Produtos).ThenInclude(i => i.ProdutoFotos).ThenInclude(i => i.Foto)
                .FirstOrDefaultAsync(x => x.Id == Convert.ToInt32(id));
        }
        public async Task<IEnumerable<Loja>> ListarPorLocalizacao(decimal latitude, decimal longitude, int raio)
        {

            var lat = latitude.ToString().Replace(",", ".");
            var lng = longitude.ToString().Replace(",", ".");

            var sql = $@"
	                        SELECT l.""Id"", l.""Nome"", l.""Descricao"", l.""Logo"",
                                e.""Latitude"",
                                e.""Longitude"",
                                Count(a.""Id"") as ""QuantidadeAvaliacoes"",
                                CASE WHEN Count(a.""Id"") > 0 THEN CAST((SUM(a.""Nota"") / Count(a.""Id"")) AS DECIMAL) ELSE CAST(0 AS DECIMAL) END as ""MediaAvaliacoes"",
                                CAST((6371 *
                                    acos(
                                        cos(radians({lat})) *
                                        cos(radians(""Latitude"")) *
                                        cos(radians({lng}) - radians(""Longitude"")) +
                                        sin(radians({lat})) *
                                        sin(radians(""Latitude""))
                                    )) AS DECIMAL) as ""Distancia""
                            FROM
                            public.""Loja"" as l
                            INNER JOIN public.""Endereco"" as e
                            ON l.""EnderecoId"" = e.""Id""
                            LEFT JOIN public.""Avaliacao"" as a
                            ON a.""LojaId"" = l.""Id""
                            WHERE
                                l.""Ativa"" = true
	                            AND (6371 *
                                    acos(
                                        cos(radians({lat})) *
					                    cos(radians(""Latitude"")) *
					                    cos(radians({lng}) - radians(""Longitude"")) +
					                    sin(radians({lat})) *
					                    sin(radians(""Latitude""))
				                    )) <= {raio}
                            GROUP BY l.""Id"", l.""Nome"", l.""Descricao"", l.""Logo"", l.""Ativa"",
			                            e.""Latitude"",
			                            e.""Longitude""
                            ";

            var lista = await _dbContext.RawSqlQueryAsync<Loja>(sql, x =>
                new Loja {
                    Id = (int)x[0],
                    Nome = (string)x[1],
                    Descricao = (string)x[2],
                    Logo = (string)x[3],
                    Latitude = (decimal)x[4],
                    Longitude = (decimal)x[5],
                    QuantidadeAvaliacoes = (long)(x[6]),
                    MediaAvaliacoes = (decimal)x[7],
                    Distancia = (decimal)x[8]
                });

            return lista;
        }

    }
}
