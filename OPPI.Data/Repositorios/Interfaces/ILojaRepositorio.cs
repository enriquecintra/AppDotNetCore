using OPPI.Dominio.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OPPI.Data.Repositorios.Interfaces
{
    public interface ILojaRepositorio : IRepositorio<Loja>
    {
        Task InserirPlano(LojaPlanoPreco entidade);
        Task<IEnumerable<Loja>> Listar(int pagina, int quantidade);
        Task<IEnumerable<Loja>> ListarPorCategoria(int categoriaId, int pagina, int quantidade);
        Task<IEnumerable<Loja>> ListarPorLocalizacao(decimal latitude, decimal longitude, int raio);
    }
}
