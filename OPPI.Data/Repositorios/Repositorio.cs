using Microsoft.EntityFrameworkCore;
using OPPI.Data.Repositorios.Interfaces;
using OPPI.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace OPPI.Data.Repositorios
{
    public class Repositorio<TEntity> : IRepositorio<TEntity> where TEntity : EntidadeBase
    {
        public OppiContext _dbContext;

        protected DbSet<TEntity> DbSet { get; set; }

        public Repositorio(OppiContext dbContext)
        {
            _dbContext = dbContext;
            DbSet = _dbContext.Set<TEntity>();
        }

        public async Task<TEntity> Obter(Expression<Func<TEntity, bool>> predicate)
        {
            var dbSet = await DbSet.AsNoTracking().FirstOrDefaultAsync(predicate);
            return dbSet;
        }

        public async Task<IEnumerable<TEntity>> ObterTodos(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.Where(predicate).AsNoTracking().ToListAsync();
        }

        public void Deletar(object id)
        {
            _dbContext.Remove(ObterPeloId(id));
            _dbContext.SaveChanges();
        }
        public async Task DeletarAsync(object id)
        {
            var entidade = await ObterPeloIdAsync(id);
            _dbContext.Remove(entidade);
            await _dbContext.SaveChangesAsync();
        }
        public void DeletarTodos(IEnumerable<TEntity> entidades)
        {
            _dbContext.RemoveRange(entidades);
            _dbContext.SaveChanges();
        }
        public async Task DeletarTodosAsync(IEnumerable<TEntity> entidades)
        {
            _dbContext.RemoveRange(entidades);
            await _dbContext.SaveChangesAsync();
        }

        public IEnumerable<TEntity> ListarTodos()
        {
            return DbSet.AsNoTracking();
        }
        public async Task<IEnumerable<TEntity>> ListarTodosAsync()
        {
            return await DbSet.AsNoTracking().ToListAsync();
        }
        public IEnumerable<TEntity> ListarTodos(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
        {
            var dbSet = DbSet.AsNoTracking().Where(predicate);
            if (includes != null)
            {
                var query = dbSet.Include(includes[0]);
                for (int i = 1; i < includes.Length; i++)
                {
                    query = query.Include(includes[i]);
                }
                return query;
            }
            return dbSet;
        }

        public async Task<IEnumerable<TEntity>> ListarTodosAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
        {
            var dbSet = await DbSet.AsNoTracking().Where(predicate).ToListAsync();
            foreach (var include in includes)
            {
                await _dbContext.Entry(dbSet).Reference(include.Name).LoadAsync();
            }
            return dbSet;
        }
        public async Task<IEnumerable<TEntity>> ListarCompleto()
        {
            await Task.Run(() => { });
            throw new NotImplementedException();
        }

        public TEntity ObterPeloId(object id)
        {
            var entity = _dbContext.Find<TEntity>(id);
            _dbContext.Entry(entity).State = EntityState.Detached;
            return entity;
        }
        public async Task<TEntity> ObterPeloIdAsync(object id)
        {
            var entity = await _dbContext.FindAsync<TEntity>(id);
            if (entity == null)
                return null;
            
            _dbContext.Entry(entity).State = EntityState.Detached;
            return entity;
        }

        public void Salvar(TEntity entidade)
        {
            var data = DateTime.Now;
            if (entidade.Id == 0)
                entidade.DataCadastro = data;
            entidade.DataAlteracao = data;

            _dbContext.AddOrUpdate(entidade);
            _dbContext.SaveChanges();
        }
        public async Task SalvarAsync(TEntity entidade)
        {
            var data = DateTime.Now;
            if (entidade.Id == 0)
                entidade.DataCadastro = data;
            entidade.DataAlteracao = data;

            await _dbContext.AddOrUpdateAsync(entidade);
            await _dbContext.SaveChangesAsync();

        }

        public void SalvarTodos(IEnumerable<TEntity> entidades)
        {
            var data = DateTime.Now;
            foreach (var entidade in entidades)
            {
                if (entidade.Id == 0)
                    entidade.DataCadastro = data;
                entidade.DataAlteracao = data;
            }
            _dbContext.AddRange(entidades);
            _dbContext.SaveChanges();
        }
        public async Task SalvarTodosAsync(IEnumerable<TEntity> entidades)
        {
            var data = DateTime.Now;
            foreach (var entidade in entidades)
            {
                if (entidade.Id == 0)
                    entidade.DataCadastro = data;
                entidade.DataAlteracao = data;
            }
            await _dbContext.AddRangeAsync(entidades);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<TEntity> ObterCompleto(object id)
        {
            await Task.Run(() => { });
            throw new NotImplementedException();
        }
    }



    public static class ContextExtensions
    {
        public static void AddOrUpdate(this DbContext ctx, EntidadeBase entity)
        {
            var entry = ctx.Entry(entity);
            if (entry.State == EntityState.Detached && entity.Id > 0)
            {
                ctx.Attach(entity);
                entry.State = EntityState.Modified;
            }
            switch (entry.State)
            {
                case EntityState.Detached:
                    ctx.Add(entity);
                    break;
                case EntityState.Modified:
                    ctx.Update(entity);
                    break;
                case EntityState.Added:
                    ctx.Add(entity);
                    break;
                case EntityState.Unchanged:
                    //item already in db no need to do anything  
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        public async static Task AddOrUpdateAsync(this DbContext ctx, EntidadeBase entity)
        {
            var entry = ctx.Entry(entity);
            if (entry.State == EntityState.Detached && entity.Id > 0)
            {
                ctx.Attach(entity);
                entry.State = EntityState.Modified;
            }
            switch (entry.State)
            {
                case EntityState.Detached:
                    await ctx.AddAsync(entity);
                    break;
                case EntityState.Modified:
                    ctx.Update(entity);
                    break;
                case EntityState.Added:
                    await ctx.AddAsync(entity);
                    break;
                case EntityState.Unchanged:
                    //item already in db no need to do anything  
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
