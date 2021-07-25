using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JOIEnergy.Registry
{
    public interface IRegistry
    {
        void Register(IServiceCollection services, IConfiguration configuration);
    }
}
