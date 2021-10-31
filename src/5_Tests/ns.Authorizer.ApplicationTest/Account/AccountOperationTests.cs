using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ns.Authorizer.Application.Service;

namespace ns.Authorizer.ApplicationTest.Account
{
    [TestClass]
    public class AccountOperationTests
    {
        [TestMethod]
        public void Create_Account_With_Success()
        {
            //arrange
            ServiceProvider services = Initializer.StartTests();
            IServiceAuthorizerOperations serviceAuthorizerOperations = services.GetService<IServiceAuthorizerOperations>();

            //execute
            string currentOutput = serviceAuthorizerOperations.Execute(AccountOperationOM.CreateAccountWithSuccess_Input);

            //assert
            Assert.AreEqual(AccountOperationOM.CreateAccountWithSuccess_Output, currentOutput);

            services.Dispose();
        }

        [TestMethod]
        public void Create_Account_With_AccountAlreadyInitialized()
        {
            //arrange
            ServiceProvider services = Initializer.StartTests();
            IServiceAuthorizerOperations serviceAuthorizerOperations = services.GetService<IServiceAuthorizerOperations>();

            //execute
            string currentOutput = serviceAuthorizerOperations.Execute(AccountOperationOM.CreateAccountWithAccountAlreadyInitialized_Input);

            //assert
            Assert.AreEqual(AccountOperationOM.CreateAccountWithAccountAlreadyInitialized_Output, currentOutput);

            services.Dispose();
        }
    }
}
