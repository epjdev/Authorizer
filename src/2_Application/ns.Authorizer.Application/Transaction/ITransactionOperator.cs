using ns.Authorizer.Domain.Model.Account;
using ns.Authorizer.Domain.Model.Transaction;

namespace ns.Authorizer.Application.Transaction
{
    public interface ITransactionOperator
    {
        AccountOperationVO Execute(TransactionOperationVO transactionOperation);
    }
}
