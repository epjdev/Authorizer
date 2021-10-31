using Microsoft.Extensions.DependencyInjection;
using ns.Authorizer.Storage.Account;
using ns.Authorizer.Storage.Transaction;

namespace ns.Authorizer.Storage
{
    public static class Initializer
    {
        public static void StartInMemoryStorage(this IServiceCollection services)
        {
            services.AddScoped<IStorageAccount, StorageAccountInMemory>();
            services.AddScoped<IStorageTransaction, StorageTransactionInMemory>();
        }
    }
}
