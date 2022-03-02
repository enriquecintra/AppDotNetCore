using AutoMapper;
using OPPI.Dominio.Entidades;
using OPPI.Servico.DTO;

namespace OPPI.Servico.Mapeamento
{
    public class SegmentoMapping : Profile
    {
        public SegmentoMapping()
        {
            CreateMap<Segmento, SegmentoDTO>().ReverseMap();
        }
    }
}
