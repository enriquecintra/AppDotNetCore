using AutoMapper;
using OPPI.Dominio.Entidades;
using OPPI.Servico.DTO;

namespace OPPI.Servico.Mapeamento
{
    public class ProdutoMapping : Profile
    {
        public ProdutoMapping()
        {
            CreateMap<Produto, ProdutoDTO>()
                .ForMember(d => d.Categoria, opt => opt.MapFrom(s => s.Segmento.Categoria.Nome))
                .ForMember(d => d.CategoriaId, opt => opt.MapFrom(s => s.Segmento.CategoriaId))
                .ForMember(d => d.Segmento, opt => opt.MapFrom(s => s.Segmento.Nome))
                ;

            CreateMap<ProdutoDTO, Produto>();
            CreateMap<ProdutoFoto, ProdutoFotoDTO>().ReverseMap();
        }
    }
}
