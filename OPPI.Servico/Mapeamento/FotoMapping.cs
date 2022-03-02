using AutoMapper;
using OPPI.Dominio.Entidades;
using OPPI.Servico.DTO;

namespace OPPI.Servico.Mapeamento
{
    public class FotoMapping : Profile
    {
        public FotoMapping()
        {
            CreateMap<Foto, FotoDTO>().ReverseMap();
        }
    }
}
