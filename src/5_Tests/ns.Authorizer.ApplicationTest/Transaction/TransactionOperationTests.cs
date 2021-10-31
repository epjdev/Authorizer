using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ns.Authorizer.Application.Service;

namespace ns.Authorizer.ApplicationTest.Transaction
{
    [TestClass]
    public class TransactionOperationTests
    {
        ServiceProvider _testServices;

        [TestInitialize]
        public void Initialize_Tests()
        {
            _testServices = Initializer.StartTests();
        }

        [TestCleanup]
        public void Cleanup_Tests()
        {
            _testServices.Dispose();
        }

        [TestMethod]
        public void Execute_Transaction_With_Success()
        {
            IServiceAuthorizerOperations serviceAuthorizerOperations = _testServices.GetService<IServiceAuthorizerOperations>();

            string currentOutput = serviceAuthorizerOperations.Execute(TransactionOperationOM.ExecuteTransactionWithSuccess_Input);

            Assert.AreEqual(TransactionOperationOM.ExecuteTransactionWithSuccess_Output, currentOutput);
        }

        [TestMethod]
        public void Execute_Transaction_With_AccountNotInitialized()
        {
            IServiceAuthorizerOperations serviceAuthorizerOperations = _testServices.GetService<IServiceAuthorizerOperations>();

            string currentOutput = serviceAuthorizerOperations.Execute(TransactionOperationOM.ExecuteTransactionWithAccountNotInitialized_Input);

            Assert.AreEqual(TransactionOperationOM.ExecuteTransactionWithAccountNotInitialized_Output, currentOutput);
        }

        [TestMethod]
        public void Execute_Transaction_With_CardNotActive()
        {
            IServiceAuthorizerOperations serviceAuthorizerOperations = _testServices.GetService<IServiceAuthorizerOperations>();

            string currentOutput = serviceAuthorizerOperations.Execute(TransactionOperationOM.ExecuteTransactionWithCardNotActive_Input);

            Assert.AreEqual(TransactionOperationOM.ExecuteTransactionWithCardNotActive_Output, currentOutput);
        }

        [TestMethod]
        public void Execute_Transaction_With_InsufficientLimit()
        {
            IServiceAuthorizerOperations serviceAuthorizerOperations = _testServices.GetService<IServiceAuthorizerOperations>();

            string currentOutput = serviceAuthorizerOperations.Execute(TransactionOperationOM.ExecuteTransactionWithInsufficientLimit_Input);

            Assert.AreEqual(TransactionOperationOM.ExecuteTransactionWithInsufficientLimit_Output, currentOutput);
        }

        [TestMethod]
        public void Execute_Transaction_With_HighFrequencySmallInterval()
        {
            IServiceAuthorizerOperations serviceAuthorizerOperations = _testServices.GetService<IServiceAuthorizerOperations>();

            string currentOutput = serviceAuthorizerOperations.Execute(TransactionOperationOM.ExecuteTransactionWithHighFrequencySmallInterval_Input);

            Assert.AreEqual(TransactionOperationOM.ExecuteTransactionWithHighFrequencySmallInterval_Output, currentOutput);
        }

        [TestMethod]
        public void Execute_Transaction_With_DoubledTransaction()
        {
            IServiceAuthorizerOperations serviceAuthorizerOperations = _testServices.GetService<IServiceAuthorizerOperations>();

            string currentOutput = serviceAuthorizerOperations.Execute(TransactionOperationOM.ExecuteTransactionWithDoubledTransaction_Input);

            Assert.AreEqual(TransactionOperationOM.ExecuteTransactionWithDoubledTransaction_Output, currentOutput);
        }

        [TestMethod]
        public void Execute_Transaction_With_MultipleViolations()
        {
            IServiceAuthorizerOperations serviceAuthorizerOperations = _testServices.GetService<IServiceAuthorizerOperations>();

            string currentOutput = serviceAuthorizerOperations.Execute(TransactionOperationOM.ExecuteTransactionWithMultipleViolations_Input);

            Assert.AreEqual(TransactionOperationOM.ExecuteTransactionWithMultipleViolations_Output, currentOutput);
        }

        [TestMethod]
        public void Execute_Transaction_With_ViolationsShouldNotBeStored()
        {
            IServiceAuthorizerOperations serviceAuthorizerOperations = _testServices.GetService<IServiceAuthorizerOperations>();

            string currentOutput = serviceAuthorizerOperations.Execute(TransactionOperationOM.ExecuteTransactionViolationsShouldNotBeStored_Input);

            Assert.AreEqual(TransactionOperationOM.ExecuteTransactionViolationsShouldNotBeStored_Output, currentOutput);
        }
    }
}
