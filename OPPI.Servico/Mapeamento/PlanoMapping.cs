using AutoMapper;
using OPPI.Dominio.Entidades;
using OPPI.Servico.DTO;

namespace OPPI.Servico.Mapeamento
{
    public class PlanoMapping : Profile
    {
        public PlanoMapping()
        {
            CreateMap<Plano, PlanoDTO>().ReverseMap();
        }
    }
}
