using AutoMapper;
using OPPI.Dominio.Entidades;
using OPPI.Servico.DTO;

namespace OPPI.Servico.Mapeamento
{
    public class ProvedorMapping : Profile
    {
        public ProvedorMapping()
        {
            CreateMap<Provedor, ProvedorDTO>().ReverseMap();
        }
    }
}
