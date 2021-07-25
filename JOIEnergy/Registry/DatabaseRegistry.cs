using JOIEnergy.Base.DataManagement;
using JOIEnergy.DataAccess.DataManagement;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JOIEnergy.Registry
{
    public class DatabaseRegistry : IRegistry
    {
        public void Register(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IRepository, InMemoryRepository>();
        }
    }
}
