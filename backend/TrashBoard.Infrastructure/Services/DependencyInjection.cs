using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TrashBoard.Application.Interfaces;
using TrashBoard.Infrastructure.Persistence;
using TrashBoard.Infrastructure.Persistence.Repositories;

namespace TrashBoard.Infrastructure.Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration, string? connectionString = null)
        {
            var conn = connectionString ?? configuration.GetConnectionString("Default")!;

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseNpgsql(conn);
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IThreadRepository, ThreadRepository>();
            services.AddScoped<IBoardRepository, BoardRepository>();
            services.AddScoped<IPageRepository, PageRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            return services;
        }
    }
}

