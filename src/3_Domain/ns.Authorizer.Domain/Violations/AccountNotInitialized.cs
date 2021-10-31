namespace ns.Authorizer.Domain.Violations
{
    public class AccountNotInitialized : IViolation
    {
        public string Message() => "account-not-initialized";
    }
}
