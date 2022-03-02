using AutoMapper;
using OPPI.Dominio.Entidades;
using OPPI.Servico.DTO;

namespace OPPI.Servico.Mapeamento
{
    public class UsuarioMapping : Profile
    {
        public UsuarioMapping()
        {
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
        }
    }
}
