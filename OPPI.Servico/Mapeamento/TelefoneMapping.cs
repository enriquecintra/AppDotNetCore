using AutoMapper;
using OPPI.Dominio.Entidades;
using OPPI.Servico.DTO;

namespace OPPI.Servico.Mapeamento
{
    public class TelefoneMapping : Profile
    {
        public TelefoneMapping()
        {
            CreateMap<Telefone, TelefoneDTO>().ReverseMap();
        }
    }
}
