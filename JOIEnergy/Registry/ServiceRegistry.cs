using JOIEnergy.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JOIEnergy.Registry
{
    public class ServiceRegistry : IRegistry
    {
        public void Register(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IAccountService, AccountService>();
            services.AddSingleton<IMeterReadingService, MeterReadingService>();
            services.AddSingleton<IPricePlanService, PricePlanService>();
        }
    }
}
