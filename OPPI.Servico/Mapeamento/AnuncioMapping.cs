using AutoMapper;
using OPPI.Dominio.Entidades;
using OPPI.Servico.DTO;

namespace OPPI.Servico.Mapeamento
{
    public class AnuncioMapping : Profile
    {
        public AnuncioMapping()
        {
            CreateMap<Anuncio, AnuncioDTO>().ReverseMap();
            CreateMap<AnuncioFoto, AnuncioFotoDTO>().ReverseMap();
        }
    }
}
