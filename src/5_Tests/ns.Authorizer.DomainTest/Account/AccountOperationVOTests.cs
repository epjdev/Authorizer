using Microsoft.VisualStudio.TestTools.UnitTesting;
using ns.Authorizer.Domain.Model.Account;
using ns.Authorizer.Domain.Model.Transaction;
using ns.Authorizer.Domain.Violations;
using System.Collections.Generic;

namespace ns.Authorizer.DomainTest.Account
{
    [TestClass]
    public class AccountOperationVOTests
    {
        [DataTestMethod]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(5)]
        public void AccountOperationVO_AddViolationTest(int violationsQuantity)
        {
            IViolation[] violations = AccountOperationVOOM.GetViolations(violationsQuantity);
            AccountOperationVO accountOperationVO = AccountOperationVOOM.CreateAccountOperation();

            foreach (IViolation violation in violations)
                accountOperationVO.AddViolation(violation);

            Assert.AreEqual(violationsQuantity, accountOperationVO.Violations.Count);
        }

        [TestMethod]
        public void AccountOperationVO_HasViolationsTest_NoViolations()
        {
            AccountOperationVO accountOperationVO = AccountOperationVOOM.CreateAccountOperation();

            bool currentResult = accountOperationVO.HasViolations();

            Assert.IsFalse(currentResult);
        }

        [TestMethod]
        public void AccountOperationVO_HasViolationsTest_HasViolations()
        {
            IViolation[] violations = AccountOperationVOOM.GetViolations(1);
            AccountOperationVO accountOperationVO = AccountOperationVOOM.CreateAccountOperation();

            accountOperationVO.AddViolation(violations[0]);
            bool currentResult = accountOperationVO.HasViolations();

            Assert.IsTrue(currentResult);
        }

        [TestMethod]
        public void AccountOperationVO_HasTransactionViolationsTest_NoViolations()
        {
            List<TransactionDetails> lastTransactions = AccountOperationVOOM.LastTransactions_NoViolations();
            TransactionDetails transactionDetails = AccountOperationVOOM.TransactionDetails_NoViolations();

            AccountOperationVO accountOperationVO = AccountOperationVOOM.CreateAccountOperation(true, 1500);
            bool currentResult = accountOperationVO.HasTransactionViolations(transactionDetails, lastTransactions);

            Assert.IsFalse(currentResult);
        }

        [TestMethod]
        public void AccountOperationVO_HasTransactionViolationsTest_HasViolations()
        {
            List<TransactionDetails> lastTransactions = AccountOperationVOOM.LastTransactions_HasViolations();
            TransactionDetails transactionDetails = AccountOperationVOOM.TransactionDetails_HasViolations();

            AccountOperationVO accountOperationVO = AccountOperationVOOM.CreateAccountOperation(true, 1000);
            bool currentResult = accountOperationVO.HasTransactionViolations(transactionDetails, lastTransactions);

            Assert.IsTrue(currentResult);
        }

        [TestMethod]
        public void AccountOperationVO_IsCardInactiveTest_Active()
        {
            AccountOperationVO accountOperationVO = AccountOperationVOOM.CreateAccountOperation(true, 100);

            bool currentResult = accountOperationVO.IsCardInactive();

            Assert.IsFalse(currentResult);
        }

        [TestMethod]
        public void AccountOperationVO_IsCardInactiveTest_Inactive()
        {
            AccountOperationVO accountOperationVO = AccountOperationVOOM.CreateAccountOperation(false, 100);

            bool currentResult = accountOperationVO.IsCardInactive();

            Assert.IsTrue(currentResult);
        }

        [TestMethod]
        public void AccountOperationVO_IsCardInactiveTest_Null()
        {
            AccountOperationVO accountOperationVO = AccountOperationVOOM.CreateAccountOperation();

            bool currentResult = accountOperationVO.IsCardInactive();

            Assert.IsTrue(currentResult);
        }

        [DataTestMethod]
        [DataRow(200, 100, 100)]
        [DataRow(150, 20, 130)]
        [DataRow(179, 28, 151)]
        [DataRow(23, 2, 21)]
        [DataRow(15, 7, 8)]
        [DataRow(5, 5, 0)]
        public void AccountOperationVO_ExecuteTransactionTest(long limit, long transactionAmount, long expectedLimit)
        {
            AccountOperationVO accountOperationVO = AccountOperationVOOM.CreateAccountOperation(true, limit);

            accountOperationVO.ExecuteTransaction(transactionAmount);

            Assert.AreEqual(expectedLimit, accountOperationVO.Account.AvailableLimit);
        }
    }
}
