using Influx.Utilities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Influx
{
    public static class InfluxStartup
    {
        public static void ConfigureSingleton(IConfiguration configuration, IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IInfluxService, InfluxService>();
            serviceCollection.Configure<InfluxSettings>(configuration.GetSection("Influx"));
        }
    }
}
