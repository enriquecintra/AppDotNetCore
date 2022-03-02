using Microsoft.EntityFrameworkCore;
using OPPI.Data.Repositorios.Interfaces;
using OPPI.Dominio.Entidades;
using OPPI.Dominio.Enums;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace OPPI.Data.Repositorios
{
    public class UsuarioRepositorio : Repositorio<Usuario>, IUsuarioRepositorio
    {
        public UsuarioRepositorio(OppiContext dbContext) : base(dbContext)
        {

        }

        public new async Task<Usuario> ObterCompleto(object id)
        {
            return await _dbContext.Usuario
                    .AsNoTracking()
                    .Include(i => i.Documentos)
                    .Include(i => i.Telefones)
                    .Include(i => i.Enderecos)
                    .FirstOrDefaultAsync(u => u.Id == Convert.ToInt32(id));
        }

        public async Task<bool> Existe(int id, string email, string cpf)
        {
            return await _dbContext.Usuario.AnyAsync(s =>
                        (s.Id != id)
                        &&
                        (s.Email == email || (s.Documentos != null && s.Documentos.Any(d => d.TipoDocumento == TipoDocumentoEnum.CPF && d.Numero == cpf))));
        }
    }
}
