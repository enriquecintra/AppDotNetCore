using AutoMapper;
using OPPI.Dominio.Entidades;
using OPPI.Servico.DTO;

namespace OPPI.Servico.Mapeamento
{
    public class AvaliacaoMapping : Profile
    {
        public AvaliacaoMapping()
        {
            CreateMap<Avaliacao, AvaliacaoDTO>().ReverseMap();
        }
    }
}
