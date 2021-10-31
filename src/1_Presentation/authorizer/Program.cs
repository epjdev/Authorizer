using Microsoft.Extensions.DependencyInjection;
using ns.Authorizer.Application.Service;
using System;
using System.IO;

namespace ns.Authorizer.ConsoleHost
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceProvider services = Initializer.Start();

            string operations = File.ReadAllText(args[0]);

            IServiceAuthorizerOperations service = services.GetService<IServiceAuthorizerOperations>();

            string operationsResult = service.Execute(operations);

            Console.WriteLine(operationsResult);

            services.Dispose();
        }
    }
}
