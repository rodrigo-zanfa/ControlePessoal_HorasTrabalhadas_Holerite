using System;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Polly;

namespace ControlePessoal.Api.Extensions
{
    public static class HostExtensions
    {
        public static IHost MigrateDbContext<TContext>(this IHost host, Action<TContext, IServiceProvider> seeder) where TContext : DbContext
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                var logger = services.GetRequiredService<ILogger<TContext>>();

                var context = services.GetService<TContext>();

                try
                {
                    logger.LogInformation($"Migrando banco de dados associado ao context {typeof(TContext).Name}.");

                    var retry = Policy.Handle<SqlException>()
                         .WaitAndRetry(new TimeSpan[]
                         {
                             TimeSpan.FromSeconds(5),
                             TimeSpan.FromSeconds(10),
                             TimeSpan.FromSeconds(15),
                         });

                    retry.Execute(() =>
                    {
                        context.Database
                        .Migrate();

                        seeder(context, services);
                    });

                    logger.LogInformation($"Migração do banco de dados associado ao context {typeof(TContext).Name}.");
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, $"Ocorreu um erro na migração do banco de dados associado ao context {typeof(TContext).Name}.");
                }
            }

            return host;
        }
    }
}
