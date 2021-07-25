using JOIEnergy.Base.DataManagement;
using JOIEnergy.Base.Validators;
using JOIEnergy.DataAccess;
using JOIEnergy.DataAccess.DataManagement;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JOIEnergy.Registry
{
    public class DatabaseRegistry : IRegistry
    {
        public void Register(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(typeof(DbContext), new DbContext());

            services.AddSingleton<IRepository, InMemoryRepository>();

            RegisterValidations(services);

            services.AddSingleton<AbstractTransaction, Transaction>();
        }

        private void RegisterValidations(IServiceCollection services)
        {
            services.AddSingleton<AbstractMeterReadingValidator, MeterReadingValidator>();
        }
    }
}
