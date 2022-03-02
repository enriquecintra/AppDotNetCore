using AutoMapper;
using OPPI.Dominio.Entidades;
using OPPI.Servico.DTO;

namespace OPPI.Servico.Mapeamento
{
    public class LojaMapping : Profile
    {
        public LojaMapping()
        {
            CreateMap<Loja, LojaDTO>().ReverseMap();
            CreateMap<LojaFoto, LojaFotoDTO>().ReverseMap();

        }
    }
}
