using GreenDiamond.Application.Interface.File;
using GreenDiamond.Domain.Interface.GreenDiaiondConnection;
using GreenDiamond.Domain.Interface.GreenDiamond;
using GreenDiamond.Domain.Interfaces.GreenDiamond;
using GreenDiamond.Domain.UnitOfWork;
using GreenDiamond.Infrastructure.ImageFile;
using GreenDiamond.Infrastructure.Repositories.CurrentService;
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
            // Register DbContext
            services.AddGreenDiamondDbContext(configuration);
            services.AddDbContext<GreenDiamondContext>();
            // Register repositories
            services.AddRepositories();
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
            #region Current  Service

            services.AddScoped<IConnection, Connection>();
            services.AddScoped<IImageStorageService, ImageStorageService>();

            #endregion Current  Service

            #region GreenDiamond

            services.AddScoped<IUnitOfWorkGreenDiamond, UnitOfWorkGreenDiamond>();
            services.AddScoped<IClassOfTradeRepository, ClassOfTradeRepository>();
            services.AddScoped<IClotheDisplayRepository, ClotheDisplayRepository>();
            services.AddScoped<ILoginRepository, LoginRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();

            #endregion GreenDiamond
        }
    }
}
