
using AutoMapper;
using OPPI.Data.Repositorios.Interfaces;
using OPPI.Dominio.Entidades;
using OPPI.Servico.DTO;
using OPPI.Servico.Servicos.Interfaces;

namespace OPPI.Servico.Servicos
{
    public class PromocaoServico : ServicoBase<PromocaoDTO, Promocao>, IServicoBase<PromocaoDTO, Promocao>
    {
        public PromocaoServico(IRepositorio<Promocao> repositorio, IMapper mapper) : base(repositorio, mapper)
        {

        }

    }
}
