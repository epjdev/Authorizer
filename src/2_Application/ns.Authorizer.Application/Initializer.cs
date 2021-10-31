using Microsoft.Extensions.DependencyInjection;
using ns.Authorizer.Application.Account;
using ns.Authorizer.Application.Service;
using ns.Authorizer.Application.Transaction;

namespace ns.Authorizer.Application
{
    public static class Initializer
    {
        public static void StartApplication(this IServiceCollection services)
        {
            services.AddSingleton<IServiceAuthorizerOperations, ServiceAuthorizerOperationsImpl>();
            services.AddSingleton<IAccountOperator, AccountOperatorImpl>();
            services.AddSingleton<ITransactionOperator, TransactionOperatorImpl>();
        }
    }
}
