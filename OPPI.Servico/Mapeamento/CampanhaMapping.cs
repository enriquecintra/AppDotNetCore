using AutoMapper;
using OPPI.Dominio.Entidades;
using OPPI.Servico.DTO;

namespace OPPI.Servico.Mapeamento
{
    public class CampanhaMapping : Profile
    {
        public CampanhaMapping()
        {
            CreateMap<Campanha, CampanhaDTO>().ReverseMap();
        }
    }
}
