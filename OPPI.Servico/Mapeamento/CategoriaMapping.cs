using AutoMapper;
using OPPI.Dominio.Entidades;
using OPPI.Servico.DTO;

namespace OPPI.Servico.Mapeamento
{
    public class CategoriaMapping : Profile
    {
        public CategoriaMapping()
        {
            CreateMap<Categoria, CategoriaDTO>().ReverseMap();
        }
    }
}
