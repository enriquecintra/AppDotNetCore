
using AutoMapper;
using OPPI.Data.Repositorios.Interfaces;
using OPPI.Dominio.Entidades;
using OPPI.Servico.DTO;
using OPPI.Servico.Servicos.Interfaces;
using System;
using System.Threading.Tasks;

namespace OPPI.Servico.Servicos
{
    public class ProdutoServico : ServicoBase<ProdutoDTO, Produto>, IServicoBase<ProdutoDTO, Produto>
    {
        public ProdutoServico(IProdutoRepositorio repositorio, IMapper mapper) : base(repositorio, mapper)
        {

        }
    }
}
