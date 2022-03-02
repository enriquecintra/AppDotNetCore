
using AutoMapper;
using OPPI.Data.Repositorios.Interfaces;
using OPPI.Dominio.Entidades;
using OPPI.Dominio.Enums;
using OPPI.Servico.DTO;
using OPPI.Servico.Servicos.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace OPPI.Servico.Servicos
{
    public class UsuarioServico : ServicoBase<UsuarioDTO, Usuario>, IServicoBase<UsuarioDTO, Usuario>
    {
        IUsuarioRepositorio _repositorioUsuario;
        public UsuarioServico(IUsuarioRepositorio repositorio, IMapper mapper) : base(repositorio, mapper)
        {
            _repositorioUsuario = repositorio;
        }

        public async Task<UsuarioDTO> ObterCompleto(int id)
        {
            var usuario = await _repositorioUsuario.ObterCompleto(id);
            return _mapper.Map<UsuarioDTO>(usuario);
        }

        public async Task<UsuarioDTO> ObterPeloLogin(string login)
        {
            var usuario = await _repositorio.Obter(s => s.Email == login || (s.Documentos != null && s.Documentos.Any(d => d.TipoDocumento == TipoDocumentoEnum.CPF && d.Numero == login )));
            return _mapper.Map<UsuarioDTO>(usuario);
        }

        public async Task<bool> Existe(int id, string email, string cpf)
        {
            return await _repositorioUsuario.Existe(id, email, cpf);
        }
    }
}
