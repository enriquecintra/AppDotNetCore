using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using OPPI.Data;
using OPPI.Dominio.Attributes;
using OPPI.Servico;
using OPPI.Servico.Email;
using OPPI.WebApi.Filters;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace OPPI.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            StaticConfig = configuration;
        }

        public IConfiguration Configuration { get; }
        public static IConfiguration StaticConfig { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();

            services.AddControllers(options => {
                options.Filters.Add(typeof(ValidateModelAttribute));
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BackEnd", Version = "v1" });

                c.SchemaFilter<SwaggerIgnoreFilter>();

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"Bearer [apiToken]",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme {
                            Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header
                    },
                    new List<string>() }
                });

            });
            var key = Encoding.ASCII.GetBytes(Configuration.GetValue<string>("Settings:secretKey"));
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });


            services.AddDbContext<OppiContext>(options =>
                    options.UseNpgsql(
                        Configuration.GetConnectionString("DefaultConnection"),
                               sqlOptions => sqlOptions.MigrationsAssembly(typeof(OppiContext).GetTypeInfo().Assembly.GetName().Name)));

            ServicosStartup.StartupServicos(services);

            RepositoriosStartup.StartupRepositorios(services);

            services.Configure<SendGridEmailSenderOptions>(options =>
            {
                options.ApiKey = Configuration["SendGrid:ApiKey"];
                options.RemetenteEmail = Configuration["SendGrid:RemetenteEmail"];
                options.RemetenteNome = Configuration["SendGrid:RemetenteNome"];
            });

            AutoMapperStartup.Configure(services);






        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                //app.UseSwaggerUI(c =>
                //{
                //    c.RoutePrefix = "api-docs/swagger";
                //    c.SwaggerEndpoint("/swagger/v1/swagger.json", "BackEnd");
                //});
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BackEnd v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
