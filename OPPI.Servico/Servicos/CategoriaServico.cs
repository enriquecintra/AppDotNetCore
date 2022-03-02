using AutoMapper;
using OPPI.Data.Repositorios.Interfaces;
using OPPI.Dominio.Entidades;
using OPPI.Dominio.Enums;
using OPPI.Servico.DTO;
using OPPI.Servico.Servicos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OPPI.Servico.Servicos
{
    public class CategoriaServico : ServicoBase<CategoriaDTO, Categoria>, IServicoBase<CategoriaDTO, Categoria>
    {
        IRepositorio<Categoria> _repositorioCategoria;
        public CategoriaServico(IRepositorio<Categoria> repositorio, IMapper mapper) : base(repositorio, mapper)
        {
            _repositorioCategoria = repositorio;
        }

        public IEnumerable<CategoriaDTO> ListarPorTipo(TipoCategoriaEnum tipo, int pagina, int quantidade)
        {
            if (pagina < 0) pagina = 0;
            if (quantidade < 10) quantidade = 10;
            var pula = (pagina) * quantidade;

            var lista = _repositorioCategoria
                .ListarTodos(t => t.Tipo == tipo, i => i.Segmentos)
                .Skip(pagina).Take(quantidade);

            return _mapper.Map<IEnumerable<CategoriaDTO>>(lista);

        }
    }
}
