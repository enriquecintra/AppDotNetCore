using OPPI.Dominio.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OPPI.Data.Repositorios.Interfaces
{
    public interface IProvedorRepositorio : IRepositorio<Provedor>
    {
        Task<Provedor> ObterPeloCNPJ(string cnpj);
        Task InserirUsuario(int provedorId, int usuarioId);
    }
}
