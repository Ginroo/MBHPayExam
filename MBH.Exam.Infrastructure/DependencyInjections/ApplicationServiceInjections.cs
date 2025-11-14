using MBH.Exam.Application.Interfaces;
using MBH.Exam.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace MBH.Exam.Infrastructure.DependencyInjections
{
    public static class ApplicationServiceInjections
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IClientSessionService, ClientSessionService>();
            return services;
        }
    }
}
