using Microsoft.EntityFrameworkCore;
using OPPI.Data.Repositorios.Interfaces;
using OPPI.Dominio.Entidades;
using OPPI.Dominio.Enums;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace OPPI.Data.Repositorios
{
    public class ProdutoRepositorio : Repositorio<Produto>, IProdutoRepositorio
    {
        public ProdutoRepositorio(OppiContext dbContext) : base(dbContext)
        {

        }

        public new async Task<Produto> ObterCompleto(object id)
        {
            return await _dbContext.Produto
                    .AsNoTracking()
                    .Include(i => i.ProdutoFotos)
                    .Include(i => i.Segmento).ThenInclude(i => i.Categoria)
                    .FirstOrDefaultAsync(u => u.Id == Convert.ToInt32(id));
        }
    }
}
