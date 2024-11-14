using Microsoft.Extensions.DependencyInjection;
using GreenDiamond.Application.Interface.GreenDiamond;
using GreenDiamond.Application.Service.GreenDiamond;
using GreenDiamond.Application.Interface.GreenDiamond.Authentication;
using GreenDiamond.Application.Service.Authentication;

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
            services.AddScoped<IClotheDisplayService, ClotheDisplayService>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<ICustomerService, CustomerService>();
            #endregion GreenDiamond
        }
    }
}
