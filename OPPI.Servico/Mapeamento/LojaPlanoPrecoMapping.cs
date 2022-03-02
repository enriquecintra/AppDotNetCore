using AutoMapper;
using OPPI.Dominio.Entidades;
using OPPI.Servico.DTO;

namespace OPPI.Servico.Mapeamento
{
    public class LojaPlanoPrecoMapping : Profile
    {
        public LojaPlanoPrecoMapping()
        {
            CreateMap<LojaPlanoPreco, LojaPlanoPrecoDTO>().ReverseMap();
        }
    }
}
