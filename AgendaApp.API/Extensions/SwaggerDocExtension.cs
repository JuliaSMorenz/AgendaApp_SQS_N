using Microsoft.OpenApi.Models;

namespace AgendaApp.API.Extensions
{
    /// <summary>
    /// Classe de extensão para configurar as preferências
    /// de documentação da biblioteca Swagger.
    /// </summary>
    public static class SwaggerDocExtension
    {
        public static IServiceCollection AddSwaggerDoc(this IServiceCollection services)
        {
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options => 
            {
                options.SwaggerDoc("v1", new OpenApiInfo 
                { 
                    Title = "AgendaApp - API para controle de agenda de tarefas",
                    Description = "Treinamento C# WebDeveloper - COTI Informática",
                    Version = "1.0",
                    Contact = new OpenApiContact
                    {
                        Name = "COTI Informática",
                        Email = "contato@cotiinformatica.com.br",
                        Url = new Uri("http://www.cotiinformatica.com.br")
                    }
                });
            });

            return services;
        }
    }
}
