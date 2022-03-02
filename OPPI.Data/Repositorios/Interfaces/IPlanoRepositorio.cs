using OPPI.Dominio.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OPPI.Data.Repositorios.Interfaces
{
    public interface IPlanoRepositorio : IRepositorio<Plano>
    {
        Task InserirPreco(PlanoPreco entidade);
    }
}
