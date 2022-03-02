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
    public class ProvedorServico : ServicoBase<ProvedorDTO, Provedor>, IServicoBase<ProvedorDTO, Provedor>
    {
        IProvedorRepositorio _repositorioProvedor;
        public ProvedorServico(IProvedorRepositorio repositorio, IMapper mapper) : base(repositorio, mapper)
        {
            _repositorioProvedor = repositorio;
        }

        public async Task<ProvedorDTO> ObterPeloCNPJ(string cnpj)
        {
            return _mapper.Map<ProvedorDTO>(await _repositorioProvedor.ObterPeloCNPJ(cnpj));
        }

        public async Task<IEnumerable<ProvedorDTO>> ListarPorUsuario(int usuarioId)
        {
            return _mapper.Map<IEnumerable<ProvedorDTO>>(await _repositorioProvedor.ObterTodos(p => p.UsuarioProvedores.Any(up => up.UsuarioId == usuarioId)));
        }

        public async Task InserirUsuario(int provedorId, int usuarioId)
        {
            await _repositorioProvedor.InserirUsuario(provedorId, usuarioId);
        }
    }
}
