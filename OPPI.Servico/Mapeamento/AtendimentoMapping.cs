using AutoMapper;
using OPPI.Dominio.Entidades;
using OPPI.Servico.DTO;

namespace OPPI.Servico.Mapeamento
{
    public class AtendimentoMapping : Profile
    {
        public AtendimentoMapping()
        {
            CreateMap<Atendimento, AtendimentoDTO>().ReverseMap();
        }
    }
}
