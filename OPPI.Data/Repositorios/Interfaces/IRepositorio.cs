using Microsoft.EntityFrameworkCore;
using OPPI.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OPPI.Data.Repositorios.Interfaces
{
    public interface IRepositorio<TEntity> where TEntity : EntidadeBase
    {
        Task<TEntity> Obter(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TEntity>> ObterTodos(Expression<Func<TEntity, bool>> predicate);
        TEntity ObterPeloId(object id);
        Task<TEntity> ObterPeloIdAsync(object id);
        IEnumerable<TEntity> ListarTodos();
        Task<IEnumerable<TEntity>> ListarTodosAsync();
        IEnumerable<TEntity> ListarTodos(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes);
        Task<TEntity> ObterCompleto(object id);
        Task<IEnumerable<TEntity>> ListarTodosAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes);
        Task<IEnumerable<TEntity>> ListarCompleto();
        void Salvar(TEntity entidade);
        Task SalvarAsync(TEntity entidade);
        void SalvarTodos(IEnumerable<TEntity> entidades);
        Task SalvarTodosAsync(IEnumerable<TEntity> entidades);
        void Deletar(object id);
        Task DeletarAsync(object id);
        void DeletarTodos(IEnumerable<TEntity> entidades);
        Task DeletarTodosAsync(IEnumerable<TEntity> entidades);
    }
}
