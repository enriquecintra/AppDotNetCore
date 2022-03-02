using AutoMapper;
using OPPI.Data.Repositorios.Interfaces;
using OPPI.Dominio.Entidades;
using OPPI.Servico.DTO;
using OPPI.Servico.Servicos.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OPPI.Servico.Servicos
{
    public abstract class ServicoBase<T, TEntity> : IServicoBase<T, TEntity> where T : DTOBase where TEntity : EntidadeBase
    {
        public IRepositorio<TEntity> _repositorio;
        public IMapper _mapper;
        public ServicoBase(IRepositorio<TEntity> repositorio, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        public async Task<T> ObterCompleto(object id)
        {
            var entidade = await _repositorio.ObterCompleto(id);
            return _mapper.Map<T>(entidade);
        }

        public T ObterPeloId(object id)
        {
            return _mapper.Map<T>(_repositorio.ObterPeloId(id));
        }
        public async Task<T> ObterPeloIdAsync(object id)
        {
            return _mapper.Map<T>(await _repositorio.ObterPeloIdAsync(id));
        }
        public IEnumerable<T> ListarTodos()
        {
            return _mapper.Map<IEnumerable<T>>(_repositorio.ListarTodos());
        }
        public async Task<IEnumerable<T>> ListarTodosAsync()
        {
            return _mapper.Map<IEnumerable<T>>(await _repositorio.ListarTodosAsync());
        }
        public async Task<IEnumerable<T>> ListarCompleto()
        {
            var entidade = await _repositorio.ListarCompleto();
            return _mapper.Map<IEnumerable<T>>(entidade);
        }
        public T Salvar(T dto)
        {
            var entidade = _mapper.Map<TEntity>(dto);
            _repositorio.Salvar(entidade);
            return _mapper.Map<T>(entidade);
        }
        public async Task<T> SalvarAsync(T dto)
        {
            var entidade = _mapper.Map<TEntity>(dto);
            await _repositorio.SalvarAsync(entidade);
            return _mapper.Map<T>(entidade);
        }
        public IEnumerable<T> SalvarTodos(IEnumerable<T> dtos)
        {
            var entidades = _mapper.Map<IEnumerable<TEntity>>(dtos);
            _repositorio.SalvarTodos(entidades);
            return _mapper.Map<IEnumerable<T>>(entidades);
        }
        public async Task<IEnumerable<T>> SalvarTodosAsync(IEnumerable<T> dtos)
        {
            var entidades = _mapper.Map<IEnumerable<TEntity>>(dtos);
            await _repositorio.SalvarTodosAsync(entidades);
            return _mapper.Map<IEnumerable<T>>(entidades);
        }
        public void Deletar(object id)
        {
            _repositorio.Deletar(id);
        }
        public async Task DeletarAsync(object id)
        {
            await _repositorio.DeletarAsync(id);
        }
        public void DeletarTodos(IEnumerable<T> entidades)
        {
            _repositorio.DeletarTodos(_mapper.Map<IEnumerable<TEntity>>(entidades));
        }
        public async Task DeletarTodosAsync(IEnumerable<T> entidades)
        {
            await _repositorio.DeletarTodosAsync(_mapper.Map<IEnumerable<TEntity>>(entidades));
        }
    }
}
