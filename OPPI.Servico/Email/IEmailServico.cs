using System.Collections.Generic;
using System.Threading.Tasks;

namespace OPPI.Servico.Email
{
    public interface IEmailServico
    {
        Task EnviarEmailAsync(string email, string assunto, string mensagem);
        Task EnviarEmailAsync(List<string> email, string assunto, string mensagem);
    }
}
