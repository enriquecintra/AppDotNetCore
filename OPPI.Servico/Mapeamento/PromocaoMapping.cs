using AutoMapper;
using OPPI.Dominio.Entidades;
using OPPI.Servico.DTO;

namespace OPPI.Servico.Mapeamento
{
    public class PromocaoMapping : Profile
    {
        public PromocaoMapping()
        {
            CreateMap<Promocao, PromocaoDTO>().ReverseMap();
        }
    }
}
