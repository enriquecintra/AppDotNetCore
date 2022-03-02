using OPPI.Dominio.Entidades;
using OPPI.Servico.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OPPI.Servico.Servicos.Interfaces
{
    public interface IServicoBase<T, TEntity> where T : DTOBase where TEntity : EntidadeBase
    {
        T ObterPeloId(object id);
        Task<T> ObterPeloIdAsync(object id);
        IEnumerable<T> ListarTodos();
        Task<IEnumerable<T>> ListarTodosAsync();
        Task<IEnumerable<T>> ListarCompleto();
        T Salvar(T entidade);
        Task<T> SalvarAsync(T entidade);
        IEnumerable<T> SalvarTodos(IEnumerable<T> entidades);
        Task<IEnumerable<T>> SalvarTodosAsync(IEnumerable<T> entidades);
        void Deletar(object id);
        Task DeletarAsync(object id);
        void DeletarTodos(IEnumerable<T> entidades);
        Task DeletarTodosAsync(IEnumerable<T> entidades);
    }
}
