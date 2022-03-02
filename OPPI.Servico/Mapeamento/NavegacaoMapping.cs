using AutoMapper;
using OPPI.Dominio.Entidades;
using OPPI.Servico.DTO;

namespace OPPI.Servico.Mapeamento
{
    public class NavegacaoMapping : Profile
    {
        public NavegacaoMapping()
        {
            CreateMap<Navegacao, NavegacaoDTO>().ReverseMap();
        }
    }
}

