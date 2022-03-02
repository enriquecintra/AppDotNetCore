using Microsoft.EntityFrameworkCore;
using OPPI.Data.Repositorios.Interfaces;
using OPPI.Dominio.Entidades;
using System.Threading.Tasks;

namespace OPPI.Data.Repositorios
{
    public class PlanoRepositorio : Repositorio<Plano>, IPlanoRepositorio
    {
        public PlanoRepositorio(OppiContext dbContext) : base(dbContext)
        {

        }

        public async Task InserirPreco(PlanoPreco entidade)
        {
            await _dbContext.PlanoPreco.AddAsync(entidade);
            await _dbContext.SaveChangesAsync();
        }
    }
}
