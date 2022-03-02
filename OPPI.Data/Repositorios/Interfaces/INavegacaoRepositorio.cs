using OPPI.Dominio.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OPPI.Data.Repositorios.Interfaces
{
    public interface INavegacaoRepositorio : IRepositorio<Navegacao>
    {
        IEnumerable<Navegacao> ListarNavegacaoPorUsuario(int usuarioId);
    }
}
