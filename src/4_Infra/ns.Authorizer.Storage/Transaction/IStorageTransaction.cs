using ns.Authorizer.Domain.Model.Transaction;
using System.Collections.Generic;

namespace ns.Authorizer.Storage.Transaction
{
    public interface IStorageTransaction
    {
        public void SaveTransaction(TransactionDetails transactionDetails);

        public List<TransactionDetails> GetTransactions();
    }
}
