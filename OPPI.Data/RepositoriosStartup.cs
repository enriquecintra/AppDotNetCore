using Microsoft.Extensions.DependencyInjection;
using OPPI.Data.Repositorios;
using OPPI.Data.Repositorios.Interfaces;
using System.Linq;

namespace OPPI.Data
{
    public class RepositoriosStartup
    {
        public static void StartupRepositorios(IServiceCollection services)
        {
            var parentInterface = typeof(IRepositorio<>);
            var types = parentInterface.Assembly.GetTypes();
            var interfaces = types.Where(i => i.IsInterface).Where(s => s.GetInterfaces().Any(i => i.Name == parentInterface.Name));
            foreach (var i in interfaces)
            {
                var repositorio = types.Where(x => i.IsAssignableFrom(x) && x.IsClass && x.IsPublic && !x.IsAbstract).FirstOrDefault();
                services.AddScoped(i, repositorio);
            }
            services.AddScoped(typeof(IRepositorio<>), typeof(Repositorio<>));
        }
    }
}
