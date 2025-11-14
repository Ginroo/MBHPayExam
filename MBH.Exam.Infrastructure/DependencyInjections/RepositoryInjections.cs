using MBH.Exam.Application.Interfaces;
using MBH.Exam.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace MBH.Exam.Infrastructure.DependencyInjections
{
    public static class RepositoryInjections
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IClientSessionRepository, ClientSessionRepository>();
            return services;
        }
    }
}
