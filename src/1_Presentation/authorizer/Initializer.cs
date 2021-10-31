using Microsoft.Extensions.DependencyInjection;
using ns.Authorizer.Application;
using ns.Authorizer.Storage;

namespace ns.Authorizer.ConsoleHost
{
    public static class Initializer
    {
        public static ServiceProvider Start()
        {
            IServiceCollection services = new ServiceCollection();
            services.StartApplication();
            services.StartInMemoryStorage();

            return services.BuildServiceProvider();
        }
    }
}
