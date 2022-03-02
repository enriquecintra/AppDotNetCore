
using AutoMapper;
using OPPI.Data.Repositorios.Interfaces;
using OPPI.Dominio.Entidades;
using OPPI.Servico.DTO;
using OPPI.Servico.Servicos.Interfaces;
using System;
using System.Threading.Tasks;

namespace OPPI.Servico.Servicos
{
    public class AnuncioServico : ServicoBase<AnuncioDTO, Anuncio>, IServicoBase<AnuncioDTO, Anuncio>
    {
        public AnuncioServico(IAnuncioRepositorio repositorio, IMapper mapper) : base(repositorio, mapper)
        {

        }
    }
}
