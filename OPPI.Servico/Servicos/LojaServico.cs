using AutoMapper;
using OPPI.Data.Repositorios.Interfaces;
using OPPI.Dominio.Entidades;
using OPPI.Servico.DTO;
using OPPI.Servico.Servicos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OPPI.Servico.Servicos
{
    public class LojaServico : ServicoBase<LojaDTO, Loja>, IServicoBase<LojaDTO, Loja>
    {
        ILojaRepositorio _repositorioLoja;
        public LojaServico(ILojaRepositorio repositorio, IMapper mapper) : base(repositorio, mapper)
        {
            _repositorioLoja = repositorio;
        }

        public async Task InserirPlano(LojaPlanoPrecoDTO dto)
        {
            var entidade = _mapper.Map<LojaPlanoPreco>(dto);
            await _repositorioLoja.InserirPlano(entidade);
        }

        public async Task<IEnumerable<LojaDTO>> ListarPorCategoria(int categoriaId, int pagina, int quantidade)
        {
            var lista = await _repositorioLoja.ListarPorCategoria(categoriaId, pagina, quantidade);
 
            return _mapper.Map<IEnumerable<LojaDTO>>(lista);
        }

        public async Task<IEnumerable<LojaDTO>> Listar(int pagina, int quantidade)
        {
            var lista = await _repositorioLoja.Listar(pagina, quantidade);
            return _mapper.Map<IEnumerable<LojaDTO>>(lista);
        }

        public async Task<IEnumerable<LojaDTO>> ListarPorLocalizacao(decimal latitude, decimal longitude, int raio)
        {
            var lista = await _repositorioLoja.ListarPorLocalizacao(latitude, longitude, raio);
            return _mapper.Map<IEnumerable<LojaDTO>>(lista);
        }
    }
}
