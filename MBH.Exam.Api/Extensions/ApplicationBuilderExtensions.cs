using MBH.Exam.Api.Middleware;
using MBH.Exam.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace MBH.Exam.Api.Extensions
{
    internal static class ApplicationBuilderExtensions
    {
        #region Public Methods

        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using IServiceScope scope = app.ApplicationServices.CreateScope();

            using ApplicationDbContext dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            dbContext.Database.Migrate();
        }

        public static void UseCustomExceptionHandler(this IApplicationBuilder app)
        {
            app.UseMiddleware<GlobalExceptionHandlerMiddleware>();
        }

        #endregion Public Methods
    }
}
