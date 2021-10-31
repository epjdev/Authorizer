using ns.Authorizer.Domain.Model.Account;
using ns.Authorizer.Domain.Violations;
using ns.Authorizer.ResultLib;
using ns.Authorizer.Storage.Account;

namespace ns.Authorizer.Application.Account
{
    internal class AccountOperatorImpl : IAccountOperator
    {
        IStorageAccount _storage;

        public AccountOperatorImpl(IStorageAccount storage)
        {
            _storage = storage;
        }

        public AccountOperationVO Execute(AccountOperationVO accountOperation)
        {
            Result<AccountDetails, IViolation> saveAccountResult = _storage.SaveAccount(accountOperation.Account);

            if (saveAccountResult.IsSuccess && saveAccountResult.IsFailure)
            {
                AccountOperationVO newAccountOperation = new AccountOperationVO(saveAccountResult.OkObject);
                newAccountOperation.AddViolation(saveAccountResult.FailObject);

                return newAccountOperation;
            }

            return accountOperation;
        }
    }
}
