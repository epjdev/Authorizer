using Microsoft.Extensions.DependencyInjection;
using ns.Authorizer.Application;
using ns.Authorizer.Storage;

namespace ns.Authorizer.ApplicationTest
{
    public static class Initializer
    {
        public static ServiceProvider StartTests()
        {
            IServiceCollection services = InitializeDefault();
            
            return services.BuildServiceProvider();
        }

        private static IServiceCollection InitializeDefault()
        {
            IServiceCollection services = new ServiceCollection();
            services.StartApplication();
            services.StartInMemoryStorage();

            return services;
        }
    }
}
