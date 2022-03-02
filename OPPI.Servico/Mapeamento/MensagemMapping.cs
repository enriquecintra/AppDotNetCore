using AutoMapper;
using OPPI.Dominio.Entidades;
using OPPI.Servico.DTO;

namespace OPPI.Servico.Mapeamento
{
    public class MensagemMapping : Profile
    {
        public MensagemMapping()
        {
            CreateMap<Mensagem, MensagemDTO>().ReverseMap();
        }
    }
}
