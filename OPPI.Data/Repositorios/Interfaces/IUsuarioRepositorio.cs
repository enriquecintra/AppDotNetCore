using OPPI.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPPI.Data.Repositorios.Interfaces
{
    public interface IUsuarioRepositorio : IRepositorio<Usuario>
    {
        Task<bool> Existe(int id, string email, string cpf);
    }
}
