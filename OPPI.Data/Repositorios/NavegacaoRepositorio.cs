using Microsoft.EntityFrameworkCore;
using OPPI.Data.Repositorios.Interfaces;
using OPPI.Dominio.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace OPPI.Data.Repositorios
{
    public class NavegacaoRepositorio : Repositorio<Navegacao>, INavegacaoRepositorio
    {
        public NavegacaoRepositorio(OppiContext dbContext) : base(dbContext)
        {

        }

        public IEnumerable<Navegacao> ListarNavegacaoPorUsuario(int usuarioId)
        {
            var lista = _dbContext.Navegacao
                    .Include(i => i.Loja)
                    .Include(i => i.Loja.Avaliacoes)
                    .Include(i => i.Loja.Telefones)
                    .Include(i => i.Loja.Endereco)
                    .Where(n => n.UsuarioId == usuarioId);

            return lista;
        }
    }
}
