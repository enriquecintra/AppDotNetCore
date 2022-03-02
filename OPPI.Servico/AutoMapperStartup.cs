using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using OPPI.Servico.Mapeamento;
using System;
using System.Linq;

namespace OPPI.Servico
{
    public class AutoMapperStartup
    {
        
        public static void Configure(IServiceCollection services)
        {
            //Não preciso ficar colocar um por um aqui 
            var profiles = typeof(UsuarioMapping).Assembly.GetTypes().Where(x => typeof(Profile).IsAssignableFrom(x));
            var config = new MapperConfiguration(cfg => {
                foreach (var profile in profiles) {
                    cfg.AddProfile(Activator.CreateInstance(profile) as Profile);
                }
            });
            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        }

    }
}
