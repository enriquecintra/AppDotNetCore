using AutoMapper;
using OPPI.Dominio.Entidades;
using OPPI.Servico.DTO;

namespace OPPI.Servico.Mapeamento
{
    public class DocumentoMapping : Profile
    {
        public DocumentoMapping()
        {
            CreateMap<Documento, DocumentoDTO>().ReverseMap();
        }
    }
}
