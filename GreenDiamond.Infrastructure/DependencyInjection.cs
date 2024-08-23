using GreenDiamond.Domain.Interfaces.GreenDiamond;
using GreenDiamond.Domain.UnitOfWork;
using GreenDiamond.Infrastructure.Repositories.GreenDiamond;
using GreenDiamond.Infrastructure.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GreenDiamond.Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddInfrastructureService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddGreenDiamondDbContext(configuration);
            services.AddRepositories();
            services.AddDbContext<GreenDiamondContext>();
        }

        public static void AddGreenDiamondDbContext(this IServiceCollection services, IConfiguration config)
        {
            var GreenDiamondDbConnection = config.GetConnectionString("GreenDiamondDbConnection");
            services.AddDbContext<GreenDiamondContext>(options =>
               options.UseSqlServer(GreenDiamondDbConnection,
                   builder => builder.MigrationsAssembly(typeof(GreenDiamondContext).Assembly.FullName)));
        }

        private static void AddRepositories(this IServiceCollection services)
        {

            #region GreenDiamond

            services.AddScoped<IUnitOfWorkGreenDiamond, UnitOfWorkGreenDiamond>();
            services.AddScoped<IClassOfTradeRepository, ClassOfTradeRepository>();

            #endregion GreenDiamond
        }
    }
}
