using Microsoft.Extensions.DependencyInjection;
using GreenDiamond.Application.Interface.GreenDiamond;
using GreenDiamond.Application.Service.GreenDiamond;

namespace GreenDiamond.Application
{
    public static class DependencyInjection
    {
        public static void AddApplicationService(this IServiceCollection services)
        {
            services.AddServices();
        }

        private static void AddServices(this IServiceCollection services)
        {
            #region GreenDiamond

            services.AddScoped<IClassOfTradeService, ClassOfTradeService>();
            #endregion GreenDiamond
        }
    }
}
