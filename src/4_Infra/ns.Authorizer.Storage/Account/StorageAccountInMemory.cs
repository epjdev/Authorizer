using ns.Authorizer.Domain.Model.Account;
using ns.Authorizer.Domain.Violations;
using ns.Authorizer.ResultLib;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ns.Authorizer.Storage.Account
{
    internal class StorageAccountInMemory : IStorageAccount, IDisposable
    {
        private static List<AccountDetails> Accounts = new List<AccountDetails>();

        public Result<AccountDetails, IViolation> GetAccount()
        {
            if (!Accounts.Any())
                return Result<AccountDetails, IViolation>.Fail(new AccountNotInitialized());

            return Result<AccountDetails, IViolation>.Ok(Accounts.First());
        }

        public Result<AccountDetails, IViolation> SaveAccount(AccountDetails account)
        {
            if (Accounts.Any())
                return Result<AccountDetails, IViolation>.OkWithFail(Accounts.First(), new AccountAlreadyInitialized());

            Accounts.Add(account);

            return Result<AccountDetails, IViolation>.Ok(account);
        }

        public void Dispose()
        {
            Accounts.Clear();
        }
    }
}
