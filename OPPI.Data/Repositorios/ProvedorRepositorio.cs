using Microsoft.EntityFrameworkCore;
using OPPI.Data.Repositorios.Interfaces;
using OPPI.Dominio.Entidades;
using System.Threading.Tasks;

namespace OPPI.Data.Repositorios
{
    public class ProvedorRepositorio : Repositorio<Provedor>, IProvedorRepositorio
    {
        public ProvedorRepositorio(OppiContext dbContext) : base(dbContext)
        {

        }

        public async Task InserirUsuario(int provedorId, int usuarioId)
        {
            await _dbContext.UsuarioProvedor.AddAsync(new UsuarioProvedor(provedorId, usuarioId));
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Provedor> ObterPeloCNPJ(string cnpj)
        {
            return await _dbContext.Provedor
                    .Include(i => i.Telefones)
                    .Include(i => i.Endereco)
                    .FirstOrDefaultAsync(u => u.CNPJ == cnpj);
        }
    }
}
