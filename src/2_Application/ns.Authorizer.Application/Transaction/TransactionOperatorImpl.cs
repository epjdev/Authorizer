using ns.Authorizer.Domain.Model.Account;
using ns.Authorizer.Domain.Model.Transaction;
using ns.Authorizer.Domain.Violations;
using ns.Authorizer.ResultLib;
using ns.Authorizer.Storage.Account;
using ns.Authorizer.Storage.Transaction;
using System.Collections.Generic;

namespace ns.Authorizer.Application.Transaction
{
    internal class TransactionOperatorImpl : ITransactionOperator
    {
        IStorageAccount _storageAccount;
        IStorageTransaction _storageTransaction;

        public TransactionOperatorImpl(IStorageAccount storageAccount, IStorageTransaction storageTransaction)
        {
            _storageAccount = storageAccount;
            _storageTransaction = storageTransaction;
        }

        public AccountOperationVO Execute(TransactionOperationVO transactionOperation)
        {
            AccountOperationVO accountOperation = GetAccount();

            if (accountOperation.HasViolations())
                return accountOperation;

            if (accountOperation.IsCardInactive())
                return accountOperation;

            List<TransactionDetails> lastTransactions = _storageTransaction.GetTransactions();
            if (accountOperation.HasTransactionViolations(transactionOperation.Transaction, lastTransactions))
                return accountOperation;

            accountOperation.ExecuteTransaction(transactionOperation.Transaction.Amount);
            _storageTransaction.SaveTransaction(transactionOperation.Transaction);

            return accountOperation;
        }

        private AccountOperationVO GetAccount()
        {
            AccountOperationVO accountOperation;

            Result<AccountDetails, IViolation> getAccountResult = _storageAccount.GetAccount();

            if (getAccountResult.IsFailure)
            {
                accountOperation = new AccountOperationVO();
                accountOperation.AddViolation(getAccountResult.FailObject);
                return accountOperation;
            }

            return new AccountOperationVO(getAccountResult.OkObject);
        }
    }
}
