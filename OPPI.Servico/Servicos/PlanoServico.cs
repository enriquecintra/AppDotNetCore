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
    public class PlanoServico : ServicoBase<PlanoDTO, Plano>, IServicoBase<PlanoDTO, Plano>
    {
        IPlanoRepositorio _repositorioPlano;
        public PlanoServico(IPlanoRepositorio repositorio, IMapper mapper) : base(repositorio, mapper)
        {
            _repositorioPlano = repositorio;
        }

        public async Task InserirPreco(PlanoPrecoDTO request)
        {
            var entidade = _mapper.Map<PlanoPreco>(request);
            await _repositorioPlano.InserirPreco(entidade);
            
        }
    }
}
