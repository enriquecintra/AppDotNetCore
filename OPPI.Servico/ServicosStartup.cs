using Microsoft.Extensions.DependencyInjection;
using OPPI.Servico.Email;
using OPPI.Servico.Servicos;
using OPPI.Servico.Servicos.Interfaces;
using System.Linq;

namespace OPPI.Servico
{
    public class ServicosStartup
    {
        public static void StartupServicos(IServiceCollection services)
        {
            var parentInterface = typeof(IServicoBase<,>);
            var types = parentInterface.Assembly.GetTypes();
            var servicos = types.Where(s => s.GetInterfaces().Any(i => i.Name == parentInterface.Name) && !s.IsAbstract);
            foreach (var servico in servicos)
            {
                services.AddScoped(servico);
            }

            services.AddTransient<IEmailServico, EmailServico>();
        }
    }
}
