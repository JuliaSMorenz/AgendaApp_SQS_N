using AgendaApp.Domain.Interfaces.Repositories;
using AgendaApp.Domain.Interfaces.Services;
using AgendaApp.Domain.Services;
using AgendaApp.Infra.Data.Repositories;

namespace AgendaApp.API.Extensions
{
    /// <summary>
    /// Classe de extensão para configurar as injeções de dependência do projeto
    /// </summary>
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<ITarefaDomainService, TarefaDomainService>();
            services.AddScoped<ITarefaRepository, TarefaRepository>();

            return services;
        }
    }
}
