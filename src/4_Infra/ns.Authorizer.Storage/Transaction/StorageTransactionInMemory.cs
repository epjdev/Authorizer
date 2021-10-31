using ns.Authorizer.Domain.Model.Transaction;
using System;
using System.Collections.Generic;

namespace ns.Authorizer.Storage.Transaction
{
    public class StorageTransactionInMemory : IStorageTransaction, IDisposable
    {
        List<TransactionDetails> Transactions = new List<TransactionDetails>();

        public List<TransactionDetails> GetTransactions()
        {
            return Transactions;
        }

        public void SaveTransaction(TransactionDetails transactionDetails)
        {
            Transactions.Add(transactionDetails);
        }

        public void Dispose()
        {
            Transactions.Clear();
        }
    }
}
