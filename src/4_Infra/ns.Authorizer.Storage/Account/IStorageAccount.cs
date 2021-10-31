using ns.Authorizer.Domain.Model.Account;
using ns.Authorizer.Domain.Violations;
using ns.Authorizer.ResultLib;

namespace ns.Authorizer.Storage.Account
{
    public interface IStorageAccount
    {
        public Result<AccountDetails, IViolation> SaveAccount(AccountDetails accountDetails);

        public Result<AccountDetails, IViolation> GetAccount();
    }
}
