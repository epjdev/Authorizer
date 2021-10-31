using ns.Authorizer.Domain.Model.Account;

namespace ns.Authorizer.Application.Account
{
    public interface IAccountOperator
    {
        AccountOperationVO Execute(AccountOperationVO accountOperation);
    }
}
