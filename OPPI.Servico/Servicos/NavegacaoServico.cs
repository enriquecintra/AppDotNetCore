
using AutoMapper;
using OPPI.Data.Repositorios.Interfaces;
using OPPI.Dominio.Entidades;
using OPPI.Servico.DTO;
using OPPI.Servico.Servicos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using OPPI.Dominio.Enums;

namespace OPPI.Servico.Servicos
{
    public class NavegacaoServico : ServicoBase<NavegacaoDTO, Navegacao>, IServicoBase<NavegacaoDTO, Navegacao>
    {
        INavegacaoRepositorio _repositorioNavegacao;
        public NavegacaoServico(INavegacaoRepositorio repositorio, IMapper mapper) : base(repositorio, mapper)
        {
            _repositorioNavegacao = repositorio;
        }

        public async Task<NavegacaoDTO> ObterNavegacao(int usuarioId, int lojaId)
        {
            return _mapper.Map<NavegacaoDTO>(await _repositorio.Obter(o => o.UsuarioId == usuarioId && o.LojaId == lojaId));
        }

        public IEnumerable<NavegacaoDTO> ListarNavegacao(int usuarioId, NavegacaoEnum tipo, int pagina = 0, int quantidade = 10)
        {
            if (pagina < 0) pagina = 0;
            if (quantidade < 10) quantidade = 10;
            var pula = (pagina) * quantidade;

            var lista = _repositorioNavegacao.ListarNavegacaoPorUsuario(usuarioId);
            switch (tipo)
            {
                case NavegacaoEnum.Recentes:
                    lista = lista.OrderByDescending(o => o.DataAlteracao);
                    break;
                case NavegacaoEnum.MaisVistos:
                    lista = lista.OrderByDescending(o => o.QuantidadeAcesso);
                    break;
                case NavegacaoEnum.MelhorAvaliado:
                    lista = lista.OrderByDescending(o => o.Loja.Avaliacoes.Select(s => s.Nota));
                    break;
                case NavegacaoEnum.MelhorPreco:
                    lista = lista.OrderBy(o => o.Loja.Avaliacoes.Select(s => s.Preco));
                    break;
                default:
                    break;
            }
            lista = lista.Skip(pula).Take(quantidade);

            return _mapper.Map<IEnumerable<NavegacaoDTO>>(lista);
        }
    }
}
